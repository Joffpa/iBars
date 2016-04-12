using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.Globals;
using ExhibitGrid.ViewModel;
using WebGrease.Css.Extensions;

namespace ExhibitGrid.Processes
{
    public class GetGridVmProcess
    {
        public static GridVm GetVmWithoutCalcs(string gridCode)
        {
            var grid = InitializeNewGrid(gridCode);
            try
            {
                using (var db = new DEV_AF())
                {
                    var attribs = db.UspGetAttribVal(gridCode).ToList();
                    var cellDictionary = new Dictionary<string, Attributes>();
                    foreach (var attrib in attribs)
                    {
                        if (!string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            cellDictionary.Add(attrib.GridCode + attrib.RowCode + attrib.ColCode, attrib);
                        }
                        else if (string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            grid.Columns.Add(BuildColVm(attrib));
                        }
                        else if (!string.IsNullOrEmpty(attrib.RowCode) && string.IsNullOrEmpty(attrib.ColCode))
                        {
                            AddVirtualColsFromRowAttribs(grid, attrib);

                            grid.Rows.Add(BuildRowVm(attrib));
                        }
                        else
                        {
                            //grid.IsEditable = attrib.IsEditable ?? true;   TODO - add this back in later
                            grid.DisplayText = attrib.DisplayText;
                        }
                    }
                    foreach (var row in grid.Rows)
                    {
                        foreach (var col in grid.Columns.Where(c => c.Level == 0).OrderBy(c => c.DisplayOrder))
                        {
                            var cellAttrib = cellDictionary[grid.GridCode + row.RowCode + col.ColCode];
                            var cell = BuildCellVm(grid, row, col, cellAttrib);
                            
                            row.Cells.Add(cell);
                            col.Cells.Add(cell);
                            grid.Cells.Add(cell);
                        }
                    }
                }
            }catch (Exception e)
            {
                
            }

            return grid;
        }
        
        public static GridVm GetVmWithCalcs(string gridCode)
        {
            var grid = InitializeNewGrid(gridCode);
            try
            {
                using (var db = new DEV_AF())
                {
                    var calcs = db.GetCalcs(gridCode).ToList();
                    List<GetCalcs_Result> rowCalcResults = new List<GetCalcs_Result>();
                    List<GetCalcs_Result> cellCalcsExpandedFromRowCalcs = new List<GetCalcs_Result>();
                    List<GetCalcs_Result> colCalcResults = new List<GetCalcs_Result>();
                    List<GetCalcs_Result> cellCalcsExpandedFromColCalcs = new List<GetCalcs_Result>();
                    List<GetCalcs_Result> cellCalcResults = new List<GetCalcs_Result>();
                    var externalDependantCells = new List<CellVm>(); 
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
                            externalDependantCells.Add(new CellVm()
                            {
                                GridCode = calc.TargetGridCode,
                                RowCode = calc.TargetRowCode,
                                ColCode = calc.TargetColCode
                            });
                        }
                        //Both target and operand may be external
                        if (calc.GridCode != grid.GridCode && !externalDependantCells.Any(ec => ec.GridCode == calc.GridCode && ec.RowCode == calc.RowCode && ec.ColCode == calc.ColCode))
                        {
                            externalDependantCells.Add(new CellVm()
                            {
                                GridCode = calc.GridCode,
                                RowCode = calc.RowCode,
                                ColCode = calc.ColCode
                            });
                        }
                    }
					
					var calcExpressions = new List<CalcExpressionVm>();
                    calcExpressions.AddRange(
                        cellCalcResults.GroupBy(
                            r => new {r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression},
                            (key, group) => new CalcExpressionVm()
                            {
                                TargetGridCode = key.TargetGridCode,
                                TargetRowCode = key.TargetRowCode,
                                TargetColCode = key.TargetColCode,
                                Expression = key.Expression,
                                Operands =
                                    group.Select(
                                        g =>
                                            new CalcOperandVm()
                                            {
                                                GridCode = g.GridCode,
                                                RowCode = g.RowCode,
                                                ColCode = g.ColCode
                                            }).ToList()
                            }).ToList());
					

                    grid.ExternalDependantCells = externalDependantCells;

                    var attribs = db.UspGetAttribVal(gridCode).ToList();
                    var cellDictionary = new Dictionary<string, Attributes>();
                    foreach (var attrib in attribs)
                    {
                        if (!string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            cellDictionary.Add(attrib.GridCode + attrib.RowCode + attrib.ColCode, attrib);
                        }
                        else if (string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            grid.Columns.Add(BuildColVm(attrib));

                            //For Numeric columns expand the row calcs for every column and add to cell calcs
                            if (attrib.Type == Literals.ColCellType.Numeric)
                                cellCalcsExpandedFromRowCalcs.AddRange(
                                    rowCalcResults.Select(rowCalc => new GetCalcs_Result()
                                    {
                                        TargetGridCode = rowCalc.TargetGridCode,
                                        TargetRowCode = rowCalc.TargetRowCode,
                                        TargetColCode = attrib.ColCode,
                                        Expression =
                                            rowCalc.Expression.Split('.')
                                                .Aggregate(
                                                    (c, n) => n == "" ? c + "." + attrib.ColCode + n : c + "." + n),
                                        GridCode = rowCalc.GridCode,
                                        RowCode = rowCalc.RowCode,
                                        ColCode = attrib.ColCode
                                    }));
                        }
                        else if (!string.IsNullOrEmpty(attrib.RowCode) && string.IsNullOrEmpty(attrib.ColCode))
                        {
                            AddVirtualColsFromRowAttribs(grid, attrib);

                            grid.Rows.Add(BuildRowVm(attrib));

                            cellCalcsExpandedFromColCalcs.AddRange(
                                colCalcResults.Select(colCalc => new GetCalcs_Result()
                                {
                                    TargetGridCode = colCalc.TargetGridCode,
                                    TargetRowCode = attrib.RowCode,
                                    TargetColCode = colCalc.TargetColCode,
                                    Expression =
                                        colCalc.Expression.Split('.')
                                            .Aggregate((c, n) => n == "" ? c + "." + attrib.RowCode + n : c + "." + n),
                                    GridCode = colCalc.GridCode,
                                    RowCode = attrib.RowCode,
                                    ColCode = colCalc.ColCode
                                }));
                        }
                        else
                        {
                            //grid.IsEditable = attrib.IsEditable ?? true;   TODO - add this back in later
                            grid.DisplayText = attrib.DisplayText;
                        }
                    }



                    var colCalcExpressions = new List<CalcExpressionVm>();
                    colCalcExpressions.AddRange(
                        cellCalcsExpandedFromColCalcs.GroupBy(
                            r => new {r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression},
                            (key, group) => new CalcExpressionVm()
                            {
                                TargetGridCode = key.TargetGridCode,
                                TargetRowCode = key.TargetRowCode,
                                TargetColCode = key.TargetColCode,
                                Expression = key.Expression,
                                Operands =
                                    group.Select(
                                        g =>
                                            new CalcOperandVm()
                                            {
                                                GridCode = g.GridCode,
                                                RowCode = g.RowCode,
                                                ColCode = g.ColCode
                                            }).ToList()
                            }));

                    var rowCalcExpressions = new List<CalcExpressionVm>();
                    rowCalcExpressions.AddRange(
                        cellCalcsExpandedFromRowCalcs.GroupBy(
                            r => new {r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression},
                            (key, group) => new CalcExpressionVm()
                            {
                                TargetGridCode = key.TargetGridCode,
                                TargetRowCode = key.TargetRowCode,
                                TargetColCode = key.TargetColCode,
                                Expression = key.Expression,
                                Operands =
                                    group.Select(
                                        g =>
                                            new CalcOperandVm()
                                            {
                                                GridCode = g.GridCode,
                                                RowCode = g.RowCode,
                                                ColCode = g.ColCode
                                            }).ToList()
                            }));

                    var allExpandedCalcs = new List<GetCalcs_Result>();
                    allExpandedCalcs.AddRange(cellCalcResults);
                    allExpandedCalcs.AddRange(cellCalcsExpandedFromRowCalcs);
                    allExpandedCalcs.AddRange(cellCalcsExpandedFromColCalcs);

                    var cellCalcDic = calcExpressions.ToDictionary(calc => calc.TargetGridCode + "." + calc.TargetRowCode + "." + calc.TargetColCode, source => source);
                    var colCalcDic = colCalcExpressions.ToDictionary(calc => calc.TargetGridCode + "." + calc.TargetRowCode + "." + calc.TargetColCode, source => source);
                    var rowCalcDic = rowCalcExpressions.ToDictionary(calc => calc.TargetGridCode + "." + calc.TargetRowCode + "." + calc.TargetColCode, source => source);

                    colCalcDic = colCalcDic.Where(cc => !cellCalcDic.Keys.Contains(cc.Key)).ToDictionary(source => source.Key, source => source.Value);
                    rowCalcDic = rowCalcDic.Where(cc => !cellCalcDic.Keys.Contains(cc.Key)).ToDictionary(source => source.Key, source => source.Value);

                    foreach (var row in grid.Rows)
                    {
                        foreach (var col in grid.Columns.Where(c => c.Level == 0).OrderBy(c => c.DisplayOrder))
                        {
                            var cellAttrib = cellDictionary[grid.GridCode + row.RowCode + col.ColCode];

                            var cell = BuildCellVm(grid, row, col, cellAttrib);

                            cell.Calcs = col.Type == Literals.ColCellType.Numeric
                                ? GetCalcsForCell(allExpandedCalcs, cellCalcDic, colCalcDic, rowCalcDic,
                                    grid.GridCode, row.RowCode,
                                    col.ColCode)
                                : null;

                            row.Cells.Add(cell);
                            col.Cells.Add(cell);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var x = e;
            }

            return grid;
        }

        #region Build Vms
        private static GridVm InitializeNewGrid(string gridCode)
        {
            return new GridVm()
            {
                GridCode = gridCode,
                Columns = new List<ColumnVm>(),
                Rows = new List<RowVm>(),
                Cells = new List<CellVm>(),
                ExternalDependantCells = new List<CellVm>(),
                IsEditable = true,
                HasSelectCol = false,
                HasCollapseCol = false,
                HasAddCol = false,
                HasDeleteCol = false
            };
        }

        private static ColumnVm BuildColVm(Attributes attrib)
        {
            return new ColumnVm()
            {
                ColCode = attrib.ColCode,
                ColSpan = attrib.ColSpan ?? 1,
                Type = attrib.Type,
                DisplayOrder = attrib.DisplayOrder ?? 1,
                DisplayText = attrib.DisplayText,
                HasHeader = attrib.HasHeader ?? true,
                IsHidden = attrib.IsHidden ?? false,
                Level = attrib.Level ?? 0,
                Width = attrib.Width,
                IsEditable = attrib.IsEditable ?? false,
                Alignment = attrib.Alignment,
                Cells = new List<CellVm>()
            };
        }

        private static RowVm BuildRowVm(Attributes attrib)
        {
            return new RowVm()
            {
                GridCode = attrib.GridCode,
                RowCode = attrib.RowCode,
                Type = attrib.Type,
                CanSelect = attrib.CanSelect ?? false,
                CanCollapse = attrib.CanCollapse ?? false,
                CanAdd = attrib.CanAdd ?? false,
                CanDelete = attrib.CanDelete ?? false,
                Cells = new List<CellVm>(),
                Class = GetRowClassByType(attrib.Type),
                DisplayOrder = attrib.DisplayOrder ?? 0,
                IsSelected = false,
                IsCollapsed = false,
                IsHidden = attrib.IsHidden ?? false,
                IsEditable = attrib.IsEditable ?? false
            };
        }

        private static CellVm BuildCellVm(GridVm grid, RowVm row, ColumnVm col, Attributes cellAttrib)
        {
            double numval;
            var cellVal = "";
            if (row.Type != Literals.RowType.Blank) cellVal = cellAttrib.Value;
            var valParsed = double.TryParse(cellVal, out numval);
            var span = cellAttrib.ColSpan ?? col.ColSpan;
            return new CellVm()
            {
                GridCode = grid.GridCode,
                RowCode = row.RowCode,
                ColCode = col.ColCode,
                Type = !string.IsNullOrEmpty(cellAttrib.Type) ? cellAttrib.Type : col.Type,
                ColSpan = GetCellSpan(grid, row, col, cellAttrib.ColSpan),
                ColumnHeader = col.DisplayText,
                Indent = cellAttrib.Indent ?? 0,
                IsEditable = (cellAttrib.IsEditable ?? false) && row.IsEditable && col.IsEditable && grid.IsEditable,
                IsHidden = cellAttrib.IsHidden ?? false,
                Value = cellVal,
                NumValue = valParsed ? numval : 0,
                Width = (span == 1 ? col.Width : "100%"),
                Calcs = null
            };
        }
        #endregion

        #region Additional Attibute processing
        private static void AddVirtualColsFromRowAttribs(GridVm grid, Attributes rowAttrib)
        {
            grid.HasSelectCol = (rowAttrib.CanSelect ?? false) || grid.HasSelectCol;
            grid.HasCollapseCol = (rowAttrib.CanCollapse ?? false) || grid.HasCollapseCol;
            grid.HasAddCol = (rowAttrib.CanAdd ?? false) || grid.HasAddCol;
            grid.HasDeleteCol = (rowAttrib.CanDelete ?? false) || grid.HasDeleteCol;
        }
        
        private static string GetRowClassByType(string rowType)
        {
            switch (rowType)
            {
                case Literals.RowType.Header:
                    return "header-row";
                case Literals.RowType.Data:
                    return "data-row";
                case Literals.RowType.Total:
                    return "total-row";
                case Literals.RowType.Subtotal:
                    return "subtotal-row";
                case Literals.RowType.Blank:
                    return "blank-row";
                default :
                    return "default-row";
            }
        }

        private static int GetCellSpan(GridVm grid, RowVm row, ColumnVm col, int? cellSpanAttrib)
        {
            if (row.Type != Literals.RowType.Header && row.Type != Literals.RowType.Blank) return cellSpanAttrib ?? col.ColSpan;

            if (col.ColCode != Literals.UniversalColCode.RowText) return 0;

            var span = grid.Columns.Count(c => c.Level == 0 && !c.IsHidden);
            span += (grid.HasSelectCol ? 1 : 0) + (grid.HasCollapseCol ? 1 : 0) + (grid.HasAddCol ? 1 : 0) + (grid.HasDeleteCol ? 1 : 0);
            return span;
        }
        #endregion

        #region Calc Processing

        #endregion

        private static List<CalcExpressionVm> GetCalcsForCell(List<GetCalcs_Result> allExpandedCalcs, Dictionary<string, CalcExpressionVm> cellCalcDic, Dictionary<string, CalcExpressionVm> colCalcDic, Dictionary<string, CalcExpressionVm> rowCalcDic, string gridCode, string rowCode, string colCode)
        {
            var thisCellsCalcTargets = allExpandedCalcs.Where(cc => cc.GridCode == gridCode && cc.RowCode == rowCode && cc.ColCode == colCode).Select(ac => ac.TargetGridCode + "." + ac.TargetRowCode + "." + ac.TargetColCode);
            var thisCellsCalcs = new List<CalcExpressionVm>();
            thisCellsCalcs.AddRange(cellCalcDic.Where(dc => thisCellsCalcTargets.Contains(dc.Key)).Select(dc => dc.Value).ToList());
            thisCellsCalcs.AddRange(colCalcDic.Where(dc => thisCellsCalcTargets.Contains(dc.Key)).Select(dc => dc.Value).ToList());
            thisCellsCalcs.AddRange(rowCalcDic.Where(dc => thisCellsCalcTargets.Contains(dc.Key)).Select(dc => dc.Value).ToList());
            return thisCellsCalcs;
        }
    }
}
