using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.Globals;
using ExhibitGrid.ViewModel;
using CalcEngine;
using WebGrease.Css.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExhibitGrid.Processes
{
    public class CalcGridProcess
    {
        public void Process(string gridCode)
        {
            var gridVm = GetGridVmProcess.GetVmWithoutCalcs(gridCode);
            RunCalcs(gridVm);
            foreach (var row in gridVm.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    Debug.WriteLine(cell.GridCode + ", " + cell.RowCode + ", " + cell.ColCode + ":    " + cell.Value);
                }
            }
        }
        
        private void RunCalcs(GridVm grid)
        {
            using (var db = new DEV_AF())
            {
                var calcs = db.GetCalcs(grid.GridCode);
                List<GetCalcs_Result> rowCalcResults = new List<GetCalcs_Result>();
                List<GetCalcs_Result> colCalcResults = new List<GetCalcs_Result>();
                List<GetCalcs_Result> cellCalcResults = new List<GetCalcs_Result>();

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
                    if (calc.TargetGridCode != grid.GridCode && !grid.ExternalDependantCells.Any(ec => ec.GridCode == calc.TargetGridCode && ec.RowCode == calc.TargetRowCode && ec.ColCode == calc.TargetColCode))
                    {
                        grid.ExternalDependantCells.Add(new CellVm()
                        {
                            GridCode = calc.TargetGridCode,
                            RowCode = calc.TargetRowCode,
                            ColCode = calc.TargetColCode
                        });
                    }
                    //Both target and operand may be external
                    if (calc.GridCode != grid.GridCode && !grid.ExternalDependantCells.Any(ec => ec.GridCode == calc.GridCode && ec.RowCode == calc.RowCode && ec.ColCode == calc.ColCode))
                    {
                        grid.ExternalDependantCells.Add(new CellVm()
                        {
                            GridCode = calc.GridCode,
                            RowCode = calc.RowCode,
                            ColCode = calc.ColCode
                        });
                    }
                }

                //TODO: get external cells!
                GetExternalCells(grid, db);

                if (rowCalcResults.Any())
                {
                    //Take the list of GetCalcs_Results and transform into a list of CalcExpressionVm
                    var rowCalcs = GroupCalcResultsIntoVm(rowCalcResults);
                    
                    //get colCalcs whose targets are not operands of other colCals, these will be run first, Calcs that have operands that update from running the first calcs are considered dependant calcs
                    //  Upon performing the calc, recursively call "cascaded" calculations that are dependant on this calc
                    var startingRowCalcs = rowCalcs.Where(rc1 => !rc1.Operands.Any(o => rowCalcs.Any(rc2 => rc2.TargetGridCode == o.GridCode && rc2.TargetRowCode == o.RowCode)));

                    foreach (var calc in startingRowCalcs)
                    {
                        //run calcs
                        foreach (var col in grid.Columns.Where(c => c.Level == 0 && c.Type == Literals.ColCellType.Numeric))
                        {
                            RunRowCalcCascade(calc, rowCalcs, col);
                        }
                    }
                }

                // pass in colCalcResults and grid
                if (colCalcResults.Any())
                {
                    //Take the list of GetCalcs_Results and transform into a list of CalcExpressionVm
                    var colCalcs = GroupCalcResultsIntoVm(colCalcResults);

                    //get colCalcs whose targets are not operands of other colCals, these will be run first, Calcs that have operands that update from running the first calcs are considered dependant calcs
                    //  Upon performing the calc, recursively call "cascaded" calculations that are dependant on this calc
                    var startingColCalcs = colCalcs.Where(cc1 => !cc1.Operands.Any(o => colCalcs.Any(cc2 => cc2.TargetGridCode == o.GridCode && cc2.TargetColCode == o.ColCode)));

                    foreach (var calc in startingColCalcs)
                    {
                        //run col calcs for every row
                        foreach (var row in grid.Rows)
                        {
                            RunColCalcCascade(calc, colCalcs, row);
                        }
                    }
                }

                if(cellCalcResults.Any())
                {
                    //Take the list of GetCalcs_Results and transform into a list of CalcExpressionVm
                    var cellCalcs = GroupCalcResultsIntoVm(cellCalcResults);
                    var startingCellCalcs = cellCalcs.Where(cc1 => !cc1.Operands.Any(o => cellCalcs.Any(cc2 => cc2.TargetGridCode == o.GridCode && cc2.TargetRowCode == o.RowCode && cc2.TargetColCode == o.ColCode)));

                    foreach (var calc in startingCellCalcs)
                    {
                        RunCellCalcCascade(calc, cellCalcs, grid);
                    }
                }
            }
        }

        private static List<CalcExpressionVm> GroupCalcResultsIntoVm(List<GetCalcs_Result> calcResults)
        {
            return calcResults.GroupBy(
                            source => new { source.TargetGridCode, source.TargetRowCode, source.TargetColCode, source.Expression },
                            (key, source) => new CalcExpressionVm()
                            {
                                TargetGridCode = key.TargetGridCode,
                                TargetRowCode = key.TargetRowCode,
                                TargetColCode = key.TargetColCode,
                                Expression = key.Expression,
                                Operands = source.Select(s => new CalcOperandVm()
                                {
                                    GridCode = s.GridCode,
                                    RowCode = s.RowCode,
                                    ColCode = s.ColCode
                                }).ToList()
                            }).ToList();
        } 

        private static CalcExpressionVm ExpandRowCalcForCol(CalcExpressionVm rowCalc, ColumnVm col)
        {
            return new CalcExpressionVm()
            {
                TargetGridCode = rowCalc.TargetGridCode,
                TargetColCode = col.ColCode,
                TargetRowCode = rowCalc.TargetRowCode,
                Expression = rowCalc.Expression.Split('.').Aggregate((c, n) => n == "" ? c + "." + col.ColCode + n : c + "." + n),
                Operands = rowCalc.Operands.Select(o => new CalcOperandVm()
                {
                    GridCode = o.GridCode,
                    ColCode = col.ColCode,
                    RowCode = o.RowCode
                }).ToList()
            };
        }
        
        private static void RunRowCalcCascade(CalcExpressionVm calcToRun, List<CalcExpressionVm> allRowCalcs, ColumnVm col)
        {
            try
            {
                var expandedRowCalc = ExpandRowCalcForCol(calcToRun, col);
                foreach (var operand in expandedRowCalc.Operands)
                {
                    var cellValue = col.Cells.FirstOrDefault(c => c.GridCode == operand.GridCode && c.RowCode == operand.RowCode && c.ColCode == operand.ColCode).NumValue;
                    var operandToken = "{" + operand.GridCode + "." + operand.RowCode + "." + operand.ColCode + ".}";
                    expandedRowCalc.Expression = expandedRowCalc.Expression.Replace(operandToken, cellValue.ToString());
                }
                var targetCell = col.Cells.FirstOrDefault(c => c.GridCode == expandedRowCalc.TargetGridCode && c.RowCode == expandedRowCalc.TargetRowCode && c.ColCode == expandedRowCalc.TargetColCode);
                EvaluateExpressionAndAssign(expandedRowCalc.Expression, targetCell);
                var cascadedRowCalcs = allRowCalcs.Where(c => c.Operands.Any(o => o.GridCode == targetCell.GridCode && o.RowCode == targetCell.RowCode)).ToList();
                if (cascadedRowCalcs.Any())
                {
                    cascadedRowCalcs.ForEach(cc =>
                    {
                        RunRowCalcCascade(cc, allRowCalcs, col);
                    });
                }

            }
            catch (NullReferenceException e)
            {

            }
        }
        
        private static CalcExpressionVm ExpandColCalcForRow(CalcExpressionVm colCalc, RowVm row)
        {
            return new CalcExpressionVm()
            {
                TargetGridCode = colCalc.TargetGridCode,
                TargetColCode = colCalc.TargetColCode,
                TargetRowCode = row.RowCode,
                Expression = colCalc.Expression.Split('.').Aggregate((c, n) => n == "" ? c + "." + row.RowCode + n : c + "." + n),
                Operands = colCalc.Operands.Select(o => new CalcOperandVm()
                {
                    GridCode = o.GridCode,
                    ColCode = o.ColCode,
                    RowCode = row.RowCode
                }).ToList()
            };
        }
        
        private static void RunColCalcCascade(CalcExpressionVm calcToRun, List<CalcExpressionVm> allColCalcs, RowVm row)
        {
            try
            {
                var expandedColCalc = ExpandColCalcForRow(calcToRun, row);
                foreach (var operand in expandedColCalc.Operands)
                {
                    var cellValue = row.Cells.FirstOrDefault(c => c.GridCode == operand.GridCode && c.RowCode == operand.RowCode && c.ColCode == operand.ColCode).NumValue;
                    var operandToken = "{" + operand.GridCode + "." + operand.RowCode + "." + operand.ColCode + ".}";
                    expandedColCalc.Expression = expandedColCalc.Expression.Replace(operandToken, cellValue.ToString());
                }
                var targetCell = row.Cells.FirstOrDefault(c => c.GridCode == expandedColCalc.TargetGridCode && c.RowCode == expandedColCalc.TargetRowCode && c.ColCode == expandedColCalc.TargetColCode);
                EvaluateExpressionAndAssign(expandedColCalc.Expression, targetCell);
                var cascadedColCalcs = allColCalcs.Where(c => c.Operands.Any(o => o.GridCode == targetCell.GridCode && o.ColCode == targetCell.ColCode)).ToList();
                if (cascadedColCalcs.Any())
                {
                    cascadedColCalcs.ForEach(cc =>
                    {
                        RunColCalcCascade(cc, allColCalcs, row);
                    });
                }

            }
            catch (NullReferenceException e)
            {

            }
        }

        private static void RunCellCalcCascade(CalcExpressionVm calcToRun, List<CalcExpressionVm> allCellCalcs, GridVm grid)
        {
            try
            {
                foreach (var operand in calcToRun.Operands)
                {
                    double cellValue;
                    if (operand.GridCode == grid.GridCode)
                    {
                        cellValue = grid.Cells.FirstOrDefault(c =>c.GridCode == operand.GridCode && c.RowCode == operand.RowCode && c.ColCode == operand.ColCode).NumValue;
                    }
                    else
                    {
                        cellValue = grid.ExternalDependantCells.FirstOrDefault(c => c.GridCode == operand.GridCode && c.RowCode == operand.RowCode && c.ColCode == operand.ColCode).NumValue;
                    }
                    var operandToken = "{" + operand.GridCode + "." + operand.RowCode + "." + operand.ColCode + ".}";
                    calcToRun.Expression = calcToRun.Expression.Replace(operandToken, cellValue.ToString());
                }
                CellVm targetCell;
                if (calcToRun.TargetGridCode == grid.GridCode)
                {
                    targetCell = grid.Cells.FirstOrDefault(c => c.GridCode == calcToRun.TargetGridCode && c.RowCode == calcToRun.TargetRowCode && c.ColCode == calcToRun.TargetColCode);
                }
                else
                {
                    targetCell = grid.ExternalDependantCells.FirstOrDefault(c => c.GridCode == calcToRun.TargetGridCode && c.RowCode == calcToRun.TargetRowCode && c.ColCode == calcToRun.TargetColCode);
                }
                EvaluateExpressionAndAssign(calcToRun.Expression, targetCell);
                var cascadedColCalcs = allCellCalcs.Where(c => c.Operands.Any(o => o.GridCode == targetCell.GridCode && o.RowCode == targetCell.RowCode && o.ColCode == targetCell.ColCode)).ToList();
                if (cascadedColCalcs.Any())
                {
                    cascadedColCalcs.ForEach(cc =>
                    {
                        RunCellCalcCascade(cc, allCellCalcs, grid);
                    });
                }
            }
            catch (NullReferenceException e)
            {

            }
        }

        private static void EvaluateExpressionAndAssign(string expression, CellVm targetCell)
        {
            var expr = new CalcEngine.CalcEngine();
            var result = (double)expr.Evaluate(expression);
            targetCell.NumValue = result;
            targetCell.Value = result.ToString(CultureInfo.CurrentCulture);
        }

        private static void GetExternalCells(GridVm grid, DbContext db)
        {
            try
            {
                ////Create table value parameter
                DataTable dt = new DataTable();
                dt.Columns.Add("GridCode");
                dt.Columns.Add("RowCode");
                dt.Columns.Add("ColCode");

                //foreach (var cell in grid.Cells)
                //{
                //    DataRow dr = dt.NewRow();
                //    dr["GridCode"] = cell.GridCode;
                //    dr["RowCode"] = cell.RowCode;
                //    dr["ColCode"] = cell.ColCode;
                //    dt.Rows.Add(dr);
                //}

                DataRow dr = dt.NewRow();
                dr["GridCode"] = "PBA12_ProgData1";
                dr["RowCode"] = "PBA12_ProgData_CommunSustBase";
                dr["ColCode"] = "Py";
                dt.Rows.Add(dr);
                DataRow dr2 = dt.NewRow();
                dr["GridCode"] = "PBA12_ProgData1";
                dr["RowCode"] = "PBA12_ProgData_CmdCntrlOpera";
                dr["ColCode"] = "Py";
                dt.Rows.Add(dr2);
                ////Use DbType.Structured for TVP
                var cells = new SqlParameter("@Cells", SqlDbType.Structured)
                {
                    Value = dt,
                    TypeName = "GridCells"
                };

                ////Parameter for SP output
                //var result = new SqlParameter("ResultList", SqlDbType.NVarChar, 4000);
                //result.Direction = ParameterDirection.Output;

                var result = db.Database.SqlQuery<CellValue>("EXEC UspGetCellVal @Cells", cells);

                var enu = result.GetEnumerator();
                if (!enu.MoveNext()) return;
                var curr = enu.Current;
            }
            catch (Exception e)
            {
                
            }
        }
    }

    //public static class Extensions
    //{
    //    /// <summary> 
    //    /// Creates data table from source data. 
    //    /// </summary> 
    //    public static DataTable ToDataTable<T>(this IEnumerable<T> source)
    //    {
    //        DataTable table = new DataTable();

    //        //// get properties of T 
    //        var binding = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty;
    //        var options = PropertyReflectionOptions.IgnoreEnumerable | PropertyReflectionOptions.IgnoreIndexer;

    //        var properties = ReflectionExtensions.GetProperties<T>(binding, options).ToList();

    //        //// create table schema based on properties 
    //        foreach (var property in properties)
    //        {
    //            table.Columns.Add(property.Name, property.PropertyType);
    //        }

    //        //// create table data from T instances 
    //        object[] values = new object[properties.Count];

    //        foreach (T item in source)
    //        {
    //            for (int i = 0; i < properties.Count; i++)
    //            {
    //                values[i] = properties[i].GetValue(item, null);
    //            }

    //            table.Rows.Add(values);
    //        }

    //        return table;
    //    }
    //}

}