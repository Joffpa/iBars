using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.Globals;
using ExhibitGrid.ViewModel;

namespace ExhibitGrid.Processes
{
    public class CalcGridProcess
    {
        /// <summary>
        /// Runs Calcs for a grid. Will retrieve the GridVm from the DB and build the viewmodel using ExhibitVmProcess.GetGridVmForMidtierCalcs().
        /// </summary>
        /// <param name="gridCode">The grid to retreive from the DB and run calcs against.</param>
        public static void Process(string gridCode)
        {
            try
            {
                using (var db = new DEV_AF())
                {
                    var exhibitVm = ExhibitVmProcess.GetGridVmForMidtierCalcs(gridCode);
                    RunCalcs(db, exhibitVm, gridCode);
                    //SaveAllCellValues(db, exhibitVm);
                }
            }
            catch (Exception e)
            {
                LogError(e);
            }
        }

        /// <summary>
        /// Runs Calcs for a grid, where the GridVm has been previously been built and is added to an ExhibitVm.
        /// </summary>
        /// <param name="exhibitVm">The ExhibitVm which contains the GridVm to run calcs on</param>
        /// <param name="gridCode">The GridVm in the ExhibitVm to run calcs for. If the grid is not found in the ExhibitVm, then the method returns without runnign any calcs.</param>
        public static void Process(ExhibitVm exhibitVm, string gridCode)
        {
            try
            {
                using (var db = new DEV_AF())
                {
                    RunCalcs(db, exhibitVm, gridCode);
                }
            }
            catch(Exception e)
            {
                LogError(e);
            }
        }
        
        private static void RunCalcs(DEV_AF db, ExhibitVm exhibit, string gridCode)
        {
            var grid = exhibit.Grids.FirstOrDefault(g => g.GridCode == gridCode);
            if (grid == null) return;
            var calcs = db.UspGetCalcs(grid.GridCode);
            var rowCalcResults = new List<UspGetCalcs_Result>();
            var colCalcResults = new List<UspGetCalcs_Result>();
            var cellCalcResults = new List<UspGetCalcs_Result>();
            var externalDependantCells = new List<CellVm>(); 
            //Separate ColCalcs, RowCalcs, and CellCalcs
            foreach (var calc in calcs)
            {
                if (string.IsNullOrEmpty(calc.TargetColCode) && calc.TargetGridCode == grid.GridCode)
                {
                    rowCalcResults.Add(calc);
                }
                else if (string.IsNullOrEmpty(calc.TargetRowCode) && calc.TargetGridCode == grid.GridCode)
                {
                    colCalcResults.Add(calc);
                }
                else
                {
                    cellCalcResults.Add(calc);
                }
                //identify external cells
                if (calc.TargetGridCode != grid.GridCode && !externalDependantCells.Any(ec => ec.GridCode == calc.TargetGridCode && ec.RowCode == calc.TargetRowCode && ec.ColCode == calc.TargetColCode))
                {
                    externalDependantCells.Add(new CellVm
                    {
                        GridCode = calc.TargetGridCode,
                        RowCode = calc.TargetRowCode,
                        ColCode = calc.TargetColCode
                    });
                }
                //Both target and operand may be external
                if (calc.GridCode != grid.GridCode && !externalDependantCells.Any(ec => ec.GridCode == calc.GridCode && ec.RowCode == calc.RowCode && ec.ColCode == calc.ColCode))
                {
                    externalDependantCells.Add(new CellVm
                    {
                        GridCode = calc.GridCode,
                        RowCode = calc.RowCode,
                        ColCode = calc.ColCode
                    });
                }
            }
            

            if (externalDependantCells.Any())
            {
                //Remove any external cells that are already in the VM.
                //Assumes that the VM in memory has the most up to date values for cells
                for (int i = 0; i < externalDependantCells.Count; i++)
                {
                    var externalDependantCell = externalDependantCells[i];
                    var externallGrid = exhibit.Grids.FirstOrDefault(g => g.GridCode == externalDependantCell.GridCode);
                    if (externallGrid == null) continue;
                    var externalRow = externallGrid.Rows.FirstOrDefault(r => r.RowCode == externalDependantCell.RowCode);
                    if (externalRow == null) continue;
                    var externalcell = externalRow.Cells.FirstOrDefault(r => r.RowCode == externalDependantCell.RowCode);
                    if (externalcell == null) continue;
                    externalDependantCells.RemoveAt(i);
                }
                ExhibitVmProcess.GetExternalCells(exhibit, externalDependantCells, db, cellCalcResults, null, null, null);
            }

            //Run Parent Child Calcs distinguished by RowRelationship (Context = total)
            //Get all Parent Rows (rows that have any children)
            var allParentRows = grid.Rows.Select(r => r.TotalParentRowCode).ToList();
            if (allParentRows.Any())
            {
                //Get all parent rows (rows that have any children) whose children are not themselves parents (all children are not found in the collection of all parents 'allParentRows')
                //This is done to start the cascade of parent row calcs at the lowest level of ancestry, and work our way up to the topmost parent
                var startingRowSumCalcs = grid.Rows.Where(r => r.TotalChildrenRowCodes.Any() && r.TotalChildrenRowCodes.All(c => !allParentRows.Contains(c)));
                
                foreach (var row in startingRowSumCalcs)
                {
                    RunRowCalcSumChildrenLoop(row, grid);
                }
            }
            
            //Run all Row Calcs
            var rowCalcs = new List<CalcExpressionVm>();
            if (rowCalcResults.Any())
            {
                //Take the list of GetCalcs_Results and transform into a list of CalcExpressionVm
                rowCalcs = GroupCalcResultsIntoVm(rowCalcResults);
                
                //get colCalcs whose targets are not operands of other colCals, these will be run first, Calcs that have operands that update from running the first calcs are considered dependant calcs
                //  Upon performing the calc, recursively call "cascaded" calculations that are dependant on this calc
                var startingRowCalcs = rowCalcs.Where(rc => CalcOperandsAreNotTargetsOfOtherCalcs(rc, rowCalcs));

                foreach (var calc in startingRowCalcs)
                {
                    //run calcs
                    foreach (var col in grid.Columns.Where(c => c.Level == 0 && ColumnIsNumericOrPercent(c)))
                    {
                        RunRowCalcRecursive(calc, rowCalcs, col);
                    }
                }
            }

            //Run all Column Calcs
            var colCalcs = new List<CalcExpressionVm>();
            // pass in colCalcResults and grid
            if (colCalcResults.Any())
            {
                //Take the list of GetCalcs_Results and transform into a list of CalcExpressionVm
                colCalcs = GroupCalcResultsIntoVm(colCalcResults);

                //get colCalcs whose targets are not operands of other colCals, these will be run first, Calcs that have operands that update from running the first calcs are considered dependant calcs
                //  Upon performing the calc, recursively call "cascaded" calculations that are dependant on this calc
                var startingColCalcs = colCalcs.Where(cc => CalcOperandsAreNotTargetsOfOtherCalcs(cc, colCalcs));

                foreach (var calc in startingColCalcs)
                {
                    //run col calcs for every row
                    foreach (var row in grid.Rows)
                    {
                        RunColCalcRecursive(calc, colCalcs, row);
                    }
                }
            }
            
            //Run all Cell Calcs
            if(cellCalcResults.Any())
            {
                //Take the list of GetCalcs_Results and transform into a list of CalcExpressionVm
                var cellCalcs = GroupCalcResultsIntoVm(cellCalcResults);
                //Cell Value Calcs run first
                //Get Cell Calcs that are not targets of other calcs. These are the inital calcs that start the "Calc Cascade"
                var startingCellCalcs = cellCalcs.Where(cc => UpdateContextIsCellValue(cc.UpdateContext) && CalcOperandsAreNotTargetsOfOtherCalcs(cc, cellCalcs));
                //Run all the starting Calcs, these will recursively call the other calcs that have operands which are targets of the starting calcs
                foreach (var calc in startingCellCalcs)
                {
                    RunCellCalcRecursive(calc, cellCalcs, exhibit, rowCalcs, colCalcs);
                }
                //Delta Check calcs run last
                //No cascade happens with delta checks, all cell values should be correct at this point
                var deltaChecks = cellCalcs.Where(cc => UpdateContextIsDeltaCheck(cc.UpdateContext));
                //Even though delta checks will not cause a "cascade", we can still use the same recursive method to run the calcs, the recusion case will never trigger here
                foreach (var calc in deltaChecks)
                {
                    RunCellCalcRecursive(calc, cellCalcs, exhibit, rowCalcs, colCalcs);
                }
            }
        }

        private static List<CalcExpressionVm> GroupCalcResultsIntoVm(List<UspGetCalcs_Result> calcResults)
        {
            return calcResults.GroupBy(
                            source => new { source.TargetGridCode, source.TargetRowCode, source.TargetColCode, source.Expression, source.UpdateContext },
                            (key, source) => new CalcExpressionVm()
                            {
                                TargetGridCode = key.TargetGridCode,
                                TargetRowCode = key.TargetRowCode,
                                TargetColCode = key.TargetColCode,
                                Expression = key.Expression,
                                UpdateContext = key.UpdateContext,
                                Operands = source.Select(s => new CalcOperandVm()
                                {
                                    GridCode = s.GridCode,
                                    RowCode = s.RowCode,
                                    ColCode = s.ColCode
                                }).ToList()
                            }).ToList();
        }

        private static void RunRowCalcSumChildrenLoop(RowVm targetRow, GridVm grid)
        {
            while (true)
            {
                var resultDic = new Dictionary<string, double>();
                //Go through operand rows and add up numeric and percent cells, saving into dictionary
                foreach (var operandRowCode in targetRow.TotalChildrenRowCodes)
                {
                    var operandRow = grid.Rows.FirstOrDefault(r => r.RowCode == operandRowCode);
                    if (operandRow == null) continue;
                    foreach (var cell in operandRow.Cells.Where(CellIsNumericOrPercent))
                    {
                        if (resultDic.ContainsKey(cell.ColCode))
                        {
                            resultDic[cell.ColCode] = resultDic[cell.ColCode] + GetCellValue(cell);
                        }
                        else
                        {
                            resultDic.Add(cell.ColCode, GetCellValue(cell));
                        }
                    }
                }

                foreach (var cell in targetRow.Cells.Where(CellIsNumericOrPercent))
                {
                    if(resultDic.ContainsKey(cell.ColCode)) cell.Value = FormatCellValue(resultDic[cell.ColCode], cell);
                }

                if (!string.IsNullOrEmpty(targetRow.TotalParentRowCode))
                {
                    var parentRow = grid.Rows.FirstOrDefault(r => r.RowCode == targetRow.TotalParentRowCode);
                    if (parentRow != null)
                    {
                        targetRow = parentRow;
                        continue;
                    }
                }
                break;
            }
        }
        
        private static CalcExpressionVm ExpandRowCalcForCol(CalcExpressionVm rowCalc, ColumnVm col)
        {
            var calc =  new CalcExpressionVm()
            {
                TargetGridCode = rowCalc.TargetGridCode,
                TargetColCode = col.ColCode,
                TargetRowCode = rowCalc.TargetRowCode,
                Expression = rowCalc.Expression.Split('.').Aggregate((c, n) => n == "" ? c + "." + col.ColCode + n : c + "." + n),
                UpdateContext = rowCalc.UpdateContext,
                Operands = rowCalc.Operands.Select(o => new CalcOperandVm()
                {
                    GridCode = o.GridCode,
                    ColCode = col.ColCode,
                    RowCode = o.RowCode
                }).ToList()
            };
            foreach (var operand in calc.Operands)
            {
                var cell = col.Cells.FirstOrDefault(c => c.GridCode == operand.GridCode && c.RowCode == operand.RowCode && c.ColCode == operand.ColCode);
                var cellValue = GetCellValue(cell);
                var operandToken = GetCellToken(operand.GridCode, operand.RowCode, operand.ColCode);
                calc.Expression = calc.Expression.Replace(operandToken, cellValue.ToString());
            }
            return calc;
        }
        
        private static void RunRowCalcRecursive(CalcExpressionVm calcToRun, List<CalcExpressionVm> allRowCalcs, ColumnVm col)
        {
            var expandedRowCalc = ExpandRowCalcForCol(calcToRun, col);
            var targetCell = col.Cells.FirstOrDefault(c => c.GridCode == expandedRowCalc.TargetGridCode && c.RowCode == expandedRowCalc.TargetRowCode && c.ColCode == expandedRowCalc.TargetColCode);
            if (targetCell == null) return;
            EvaluateExpressionAndAssign(expandedRowCalc, targetCell);
            if (!UpdateContextIsCellValue(calcToRun.UpdateContext)) return;
            var cascadedRowCalcs = allRowCalcs.Where(c => c.Operands.Any(o => o.GridCode == targetCell.GridCode && o.RowCode == targetCell.RowCode)).ToList();
            if (cascadedRowCalcs.Any())
            {
                cascadedRowCalcs.ForEach(cc => 
                {
                    RunRowCalcRecursive(cc, allRowCalcs, col);
                });
            }
        }
        
        private static CalcExpressionVm ExpandColCalcForRow(CalcExpressionVm colCalc, RowVm row)
        {
            var calc =  new CalcExpressionVm()
            {
                TargetGridCode = colCalc.TargetGridCode,
                TargetColCode = colCalc.TargetColCode,
                TargetRowCode = row.RowCode,
                Expression = colCalc.Expression.Split('.').Aggregate((c, n) => n == "" ? c + "." + row.RowCode + n : c + "." + n),
                UpdateContext = colCalc.UpdateContext,
                Operands = colCalc.Operands.Select(o => new CalcOperandVm()
                {
                    GridCode = o.GridCode,
                    ColCode = o.ColCode,
                    RowCode = row.RowCode
                }).ToList()
            };
            foreach (var operand in calc.Operands)
            {
                var cell = row.Cells.FirstOrDefault(c => c.GridCode == operand.GridCode && c.RowCode == operand.RowCode && c.ColCode == operand.ColCode);
                var cellValue = GetCellValue(cell);
                var operandToken = GetCellToken(operand.GridCode, operand.RowCode, operand.ColCode);
                calc.Expression = calc.Expression.Replace(operandToken, cellValue.ToString(CultureInfo.CurrentCulture));
            }
            return calc;
        }
        
        private static void RunColCalcRecursive(CalcExpressionVm calcToRun, List<CalcExpressionVm> allColCalcs, RowVm row)
        {
            var expandedColCalc = ExpandColCalcForRow(calcToRun, row);
            var targetCell = row.Cells.FirstOrDefault(c => c.GridCode == expandedColCalc.TargetGridCode && c.RowCode == expandedColCalc.TargetRowCode && c.ColCode == expandedColCalc.TargetColCode);
            if (targetCell == null) return;
            EvaluateExpressionAndAssign(expandedColCalc, targetCell);
            if (!UpdateContextIsCellValue(calcToRun.UpdateContext)) return;
            var cascadedColCalcs = allColCalcs.Where(c => c.Operands.Any(o => o.GridCode == targetCell.GridCode && o.ColCode == targetCell.ColCode)).ToList();
            if (cascadedColCalcs.Any())
            {
                cascadedColCalcs.ForEach(cc =>
                {
                    RunColCalcRecursive(cc, allColCalcs, row);
                });
            }
        }

        private static void RunCellCalcRecursive(CalcExpressionVm calcToRun, List<CalcExpressionVm> allCellCalcs, ExhibitVm exhibit, List<CalcExpressionVm> allRowCalcs, List<CalcExpressionVm> allColCalcs)
        {
            foreach (var operand in calcToRun.Operands)
            {
                var grid = exhibit.Grids.FirstOrDefault(g => g.GridCode == operand.GridCode);
                var row = grid.Rows.FirstOrDefault(r => r.RowCode == operand.RowCode);
                var cell = row.Cells.FirstOrDefault(c => c.ColCode == operand.ColCode);
                var cellValue = GetCellValue(cell);
                var operandToken = GetCellToken(operand.GridCode, operand.RowCode, operand.ColCode);
                calcToRun.Expression = calcToRun.Expression.Replace(operandToken, cellValue.ToString(CultureInfo.CurrentCulture));
            }

            var targetGrid = exhibit.Grids.FirstOrDefault(g => g.GridCode == calcToRun.TargetGridCode);
            var targetRow = targetGrid.Rows.FirstOrDefault(r => r.RowCode == calcToRun.TargetRowCode);
            var targetCell = targetRow.Cells.FirstOrDefault(c => c.ColCode == calcToRun.TargetColCode);
            EvaluateExpressionAndAssign(calcToRun, targetCell);

            if (!UpdateContextIsCellValue(calcToRun.UpdateContext)) return;
            //There may be some additional row/col calcs to be run now that we've updated a single cell
            RunAllRowAndColCalcsForCellRecursive(targetCell, allRowCalcs, allColCalcs, targetGrid);
            //Cascade
            var cascadedCellCalcs = allCellCalcs.Where(c => c.Operands.Any(o => o.GridCode == targetCell.GridCode && o.RowCode == targetCell.RowCode && o.ColCode == targetCell.ColCode)).ToList();
            if (cascadedCellCalcs.Any())
            {
                cascadedCellCalcs.ForEach(cc =>
                {
                    RunCellCalcRecursive(cc, allCellCalcs, exhibit, allRowCalcs, allColCalcs);
                });
            }
        }
        
        private static void RunAllRowAndColCalcsForCellRecursive(CellVm cell, List<CalcExpressionVm> rowCalcs, List<CalcExpressionVm> colCalcs, GridVm grid)
        {
            var affectedRowCalcs = rowCalcs.Where(r => r.Operands.Any(o => o.RowCode == cell.RowCode && o.GridCode == cell.GridCode)).ToList();
            if (affectedRowCalcs.Any())
            {
                var col = grid.Columns.FirstOrDefault(c => c.ColCode == cell.ColCode);
                foreach (var rowCalc in affectedRowCalcs)
                {
                    var expandedRowCalc = ExpandRowCalcForCol(rowCalc, col);
                    var targetCell = col.Cells.FirstOrDefault(c => c.GridCode == expandedRowCalc.TargetGridCode && c.RowCode == expandedRowCalc.TargetRowCode);
                    EvaluateExpressionAndAssign(expandedRowCalc, targetCell);
                    if (UpdateContextIsCellValue(expandedRowCalc.UpdateContext))
                    {
                        RunAllRowAndColCalcsForCellRecursive(targetCell, rowCalcs, colCalcs, grid);
                    }
                }
            }
            var affectedColCalcs = colCalcs.Where(r => r.Operands.Any(o => o.ColCode == cell.ColCode && o.GridCode == cell.GridCode)).ToList();
            if (affectedColCalcs.Any())
            {
                var row = grid.Rows.FirstOrDefault(c => c.RowCode == cell.RowCode);
                foreach (var colCalc in affectedColCalcs)
                {
                    var expandedColCalc = ExpandColCalcForRow(colCalc, row);
                    var targetCell = row.Cells.FirstOrDefault(c => c.GridCode == expandedColCalc.TargetGridCode && c.ColCode == expandedColCalc.TargetColCode);
                    EvaluateExpressionAndAssign(expandedColCalc, targetCell);
                    if (UpdateContextIsCellValue(expandedColCalc.UpdateContext))
                    {
                        RunAllRowAndColCalcsForCellRecursive(targetCell, rowCalcs, colCalcs, grid);
                    }
                }
            }
        }
        
        private static double GetCellValue(CellVm cell)
        {
            if (cell == null) return 0;
            double cellValue;
            var parsed = double.TryParse(cell.Value, out cellValue);
            if (!parsed) return 0;
            if (String.Equals(cell.Type, Literals.Attribute.ColCellType.Percent, StringComparison.CurrentCultureIgnoreCase))
            {
                cellValue = cellValue / 100;
            }
            return cellValue;
        }

        private static string GetCellToken(string gridCode, string rowCode, string colCode)
        {
            return "{" + gridCode + "." + rowCode + "." + colCode + ".}";
        }

        private static void EvaluateExpressionAndAssign(CalcExpressionVm calcVm, CellVm targetCell)
        {
            var expr = new CalcEngine.CalcEngine();
            var result = (double)expr.Evaluate(calcVm.Expression);
            if (UpdateContextIsCellValue(calcVm.UpdateContext))
            {
                targetCell.Value = FormatCellValue(result, targetCell);
            }
            else
            {
                FormatCellHoverAddition(result, targetCell);
            }
        }

        private static void FormatCellHoverAddition(double value, CellVm cellVm)
        {
            var hoverAddition = "";
            var textColor = "";
            if (value == 0)
            {
                textColor = "blue";
                hoverAddition = "<div class='delta-balanced'>In Balance</div>";
            }
            else if (value < 0)
            {
                textColor = "red";
                hoverAddition = "<div class='delta-negative'>" + FormatCellValue(value, cellVm) + "</div>";
            }
            else
            {
                textColor = "red";
                hoverAddition = "<div class='delta-positive'>" + FormatCellValue(value, cellVm) + "</div>";
            }
            cellVm.TextColor = textColor;
            cellVm.HoverAddition = hoverAddition;
        }

        private static string FormatCellValue(double value, CellVm cellVm)
        {
            return cellVm.DecimalPlaces != null ? String.Format("{0:n" + cellVm.DecimalPlaces + "}", value) : String.Format("{0:n0}", value);
        }

        private static void SaveAllCellValues(DEV_AF db, ExhibitVm grid)
        {
            //TODO: save cells
        }

        private static void LogError(Exception e)
        {

        }

        #region Predicates
        private static bool CellIsNumericOrPercent(CellVm cell)
        {
            return
                String.Equals(cell.Type, Literals.Attribute.ColCellType.Numeric,
                    StringComparison.CurrentCultureIgnoreCase) ||
                String.Equals(cell.Type, Literals.Attribute.ColCellType.Numeric,
                    StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool ColumnIsNumericOrPercent(ColumnVm cell)
        {
            return
                String.Equals(cell.Type, Literals.Attribute.ColCellType.Numeric,
                    StringComparison.CurrentCultureIgnoreCase) ||
                String.Equals(cell.Type, Literals.Attribute.ColCellType.Percent,
                    StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool UpdateContextIsCellValue(string updateContext)
        {
            return String.Equals(updateContext, Literals.CalcUpdateContext.CellValue, StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool UpdateContextIsDeltaCheck(string updateContext)
        {
            return String.Equals(updateContext, Literals.CalcUpdateContext.DeltaCheck, StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool CalcOperandsAreNotTargetsOfOtherCalcs(CalcExpressionVm thisCalc, List<CalcExpressionVm> allCalcs)
        {
            return !thisCalc.Operands.Any(o => allCalcs.Any(cc2 => cc2.TargetGridCode == o.GridCode && cc2.TargetRowCode == o.RowCode &&cc2.TargetColCode == o.ColCode));
        }
        #endregion

    }
}