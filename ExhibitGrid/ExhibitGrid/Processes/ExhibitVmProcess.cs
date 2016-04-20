using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.Extensions;
using ExhibitGrid.Globals;
using ExhibitGrid.ViewModel;
using WebGrease.Css.Extensions;

namespace ExhibitGrid.Processes
{
    public class ExhibitVmProcess
    {
        public static ExhibitVm GetExhibitVmWithoutCalcs(string gridCode)
        {
            var exhibit = InitializeNewExhibit(gridCode);
            var grid = InitializeNewGrid(gridCode);
            exhibit.Grids.Add(grid);
            try
            {
                using (var db = new DEV_AF())
                {
                    var attribs = db.UspGetAttribVal(gridCode).ToList();
                    var rowRelations = db.UspGetRowRelationship(gridCode, null).ToList();
                    var cellDictionary = new Dictionary<string, Attributes>();
                    foreach (var attrib in attribs)
                    {
                        if (!string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            cellDictionary.Add(attrib.GridCode + attrib.RowCode + attrib.ColCode, attrib);
                        }
                        else if (string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            grid.Columns.Add(BuildColVmFromAttributes(attrib));
                        }
                        else if (!string.IsNullOrEmpty(attrib.RowCode) && string.IsNullOrEmpty(attrib.ColCode))
                        {
                            AddVirtualColsFromRowAttribs(grid, attrib);

                            grid.Rows.Add(BuildRowVmFromAttributes(attrib, rowRelations));
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
                            var cell = BuildCellVmFromAttributes(grid, row, col, cellAttrib);
                            
                            row.Cells.Add(cell);
                            col.Cells.Add(cell);
                            grid.Cells.Add(cell);
                        }
                    }
                }
            }catch (Exception e)
            {
                
            }
            return exhibit;
        }

        public static ExhibitVm GetExhibitVmWithCalcs(string gridCode, ExhibitVm exhibit = null)
        {
            if (exhibit == null)
            {
                exhibit = InitializeNewExhibit(gridCode);
            }
            var grid = InitializeNewGrid(gridCode);
            exhibit.Grids.Add(grid);
            try
            {
                using (var db = new DEV_AF())
                {
                    var calcs = db.GetCalcs(gridCode).ToList();
                    var rowRelations = db.UspGetRowRelationship(gridCode, null).ToList();
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
                    GetExternalCells(exhibit, externalDependantCells, db);

					var calcExpressions = new List<CalcExpressionVm>();
                    calcExpressions.AddRange(
                        cellCalcResults.GroupBy(
                            r => new {r.CalcExpressionId, r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression},
                            (key, group) => new CalcExpressionVm()
                            {
                                CalcExpressionId = key.CalcExpressionId,
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
                            grid.Columns.Add(BuildColVmFromAttributes(attrib));

                            //For Numeric columns expand the row calcs for every column and add to cell calcs
                            if (attrib.Type == Literals.ColCellType.Numeric || attrib.Type == Literals.ColCellType.Percent)
                                cellCalcsExpandedFromRowCalcs.AddRange(
                                    rowCalcResults.Select(rowCalc => new GetCalcs_Result()
                                    {
                                        CalcExpressionId = rowCalc.CalcExpressionId,
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
                                    })
                                    .Where(rc => !cellCalcResults.Any(cc => cc.TargetGridCode == rc.TargetGridCode && cc.TargetRowCode == rc.TargetRowCode && cc.TargetColCode == rc.TargetColCode))
);
                        }
                        else if (!string.IsNullOrEmpty(attrib.RowCode) && string.IsNullOrEmpty(attrib.ColCode))
                        {
                            AddVirtualColsFromRowAttribs(grid, attrib);

                            grid.Rows.Add(BuildRowVmFromAttributes(attrib, rowRelations));


                            if (attrib.Type != Literals.RowType.Header || attrib.Type != Literals.RowType.Blank)
                                cellCalcsExpandedFromColCalcs.AddRange(
                                    colCalcResults.Select(colCalc => new GetCalcs_Result()
                                    {
                                        CalcExpressionId = colCalc.CalcExpressionId,
                                        TargetGridCode = colCalc.TargetGridCode,
                                        TargetRowCode = attrib.RowCode,
                                        TargetColCode = colCalc.TargetColCode,
                                        Expression =
                                            colCalc.Expression.Split('.')
                                                .Aggregate((c, n) => n == "" ? c + "." + attrib.RowCode + n : c + "." + n),
                                        GridCode = colCalc.GridCode,
                                        RowCode = attrib.RowCode,
                                        ColCode = colCalc.ColCode
                                    })
                                    .Where(rc => !cellCalcResults.Any(cc => cc.TargetGridCode == rc.TargetGridCode && cc.TargetRowCode == rc.TargetRowCode && cc.TargetColCode == rc.TargetColCode)));
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
                            r => new { r.CalcExpressionId, r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression },
                            (key, group) => new CalcExpressionVm()
                            {
                                CalcExpressionId = key.CalcExpressionId,
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
                            r => new { r.CalcExpressionId, r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression },
                            (key, group) => new CalcExpressionVm()
                            {
                                CalcExpressionId = key.CalcExpressionId,
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
                    
                    //Convert all calcs into dictionaries for easy lookup when building individual cells
                    var cellCalcDic = calcExpressions.ToDictionary(calc => calc.CalcExpressionId + "." + calc.TargetGridCode + "." + calc.TargetRowCode + "." + calc.TargetColCode, source => source);
                    var colCalcDic = colCalcExpressions.ToDictionary(calc => calc.CalcExpressionId + "." + calc.TargetGridCode + "." + calc.TargetRowCode + "." + calc.TargetColCode, source => source);
                    var rowCalcDic = rowCalcExpressions.ToDictionary(calc => calc.CalcExpressionId + "." + calc.TargetGridCode + "." + calc.TargetRowCode + "." + calc.TargetColCode, source => source);

                    //remove expanded row and col calcs that target the same cell as a cell calc
                    //colCalcDic = colCalcDic.Where(cc => !cellCalcDic.Keys.Contains(cc.Key)).ToDictionary(source => source.Key, source => source.Value);
                    //rowCalcDic = rowCalcDic.Where(cc => !cellCalcDic.Keys.Contains(cc.Key)).ToDictionary(source => source.Key, source => source.Value);

                    foreach (var row in grid.Rows)
                    {
                        foreach (var col in grid.Columns.Where(c => c.Level == 0).OrderBy(c => c.DisplayOrder))
                        {
                            var cellAttrib = cellDictionary[grid.GridCode + row.RowCode + col.ColCode];

                            var cell = BuildCellVmFromAttributes(grid, row, col, cellAttrib);

                            cell.Calcs = col.Type == Literals.ColCellType.Numeric || col.Type == Literals.ColCellType.Percent
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
            return exhibit;
        }

        public static void GetExternalCells(ExhibitVm exhibit, List<CellVm> cells, DEV_AF db)
        {
            try
            {
                var cellParms = cells.Select(cell => new CellValue()
                {
                    GridCode = cell.GridCode,
                    RowCode = cell.RowCode,
                    ColCode = cell.ColCode
                }).ToList();
                var result = db.UspGetCellVal(cellParms);
                foreach (var cellResult in result)
                {
                    var grid = exhibit.Grids.FirstOrDefault(g => g.GridCode == cellResult.GridCode);
                    if (grid == null)
                    {
                        grid = InitializeNewGrid(cellResult.GridCode);
                        exhibit.Grids.Add(grid);
                    }
                    var row = grid.Rows.FirstOrDefault(r => r.RowCode == cellResult.RowCode);
                    if (row == null)
                    {
                        row = BuildRowVmForExternalGrid(cellResult.GridCode, cellResult.RowCode);
                        grid.Rows.Add(row);
                    }
                    var cellvm = row.Cells.FirstOrDefault(r => r.ColCode == cellResult.ColCode);
                    if (cellvm == null)
                    {
                        cellvm = BuildCellVmForExternalGrid(cellResult.GridCode, cellResult.RowCode, cellResult.ColCode, cellResult.Val);
                        row.Cells.Add(cellvm);
                        grid.Cells.Add(cellvm);
                    }
                    else
                    {
                        double parseResult;
                        cellvm.Value = cellResult.Val;
                        cellvm.NumValue = double.TryParse(cellResult.Val, out parseResult) ? parseResult : 0;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        #region Build Vms
        private static ExhibitVm InitializeNewExhibit(string gridCode)
        {
            return new ExhibitVm()
            {
                Grids = new List<GridVm>(),
                PrimaryGridCode = gridCode
            };
        }

        private static GridVm InitializeNewGrid(string gridCode)
        {
            return new GridVm()
            {
                GridCode = gridCode,
                Columns = new List<ColumnVm>(),
                Rows = new List<RowVm>(),
                Cells = new List<CellVm>(),
                IsEditable = true,
                HasSelectCol = false,
                HasCollapseCol = false,
                HasAddCol = false,
                HasDeleteCol = false
            };
        }

        private static ColumnVm BuildColVmFromAttributes(Attributes attrib)
        {
            return new ColumnVm()
            {
                ColCode = attrib.ColCode,
                ColSpan = attrib.ColSpan ?? 1,
                Type = attrib.Type,
                DisplayOrder = attrib.DisplayOrder ?? new decimal(1.0),
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

        private static RowVm BuildRowVmFromAttributes(Attributes attrib, List<UspGetRowRelationship_Result> relations)
        {
            var parentTotalRowCode = "";
            var parentTotalRealtion = relations.FirstOrDefault(r => r.ChRowCode == attrib.RowCode && r.Context == Literals.RowRelationshipContext.Total);
            if (parentTotalRealtion != null)
            {
                parentTotalRowCode = parentTotalRealtion.ParRowCode;
            }
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
                IsCollapsed = relations.Any(r => r.ChRowCode ==attrib.RowCode &&  r.Context == Literals.RowRelationshipContext.Collapse),
                IsHidden = attrib.IsHidden ?? false,
                IsEditable = attrib.IsEditable ?? false,
                CollapseableChildren = relations.Where(r => r.ParRowCode == attrib.RowCode && r.Context == Literals.RowRelationshipContext.Collapse).Select(r => r.ChRowCode).ToList(),
                TotalChildrenRowCodes = relations.Where(r => r.ParRowCode == attrib.RowCode && r.Context == Literals.RowRelationshipContext.Total).Select(r => r.ChRowCode).ToList(),
                TotalParentRowCode = parentTotalRowCode
            };
        }

        private static CellVm BuildCellVmFromAttributes(GridVm grid, RowVm row, ColumnVm col, Attributes cellAttrib)
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
                Type = col.Type, //!string.IsNullOrEmpty(cellAttrib.Type) ? cellAttrib.Type : col.Type,
                IsBlank = cellAttrib.Type == Literals.ColCellType.Blank,
                ColSpan = GetCellSpan(grid, row, col, cellAttrib.ColSpan),
                ColumnHeader = col.DisplayText,
                Indent = cellAttrib.Indent ?? 0,
                IsEditable = (cellAttrib.IsEditable ?? false) && row.IsEditable && col.IsEditable && grid.IsEditable,
                IsHidden = cellAttrib.IsHidden ?? false,
                Value = cellVal,
                NumValue = valParsed ? numval : 0,
                Width = (span == 1 ? col.Width : "100%"),
                Alignment = cellAttrib.Alignment,
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

        private static CellVm BuildCellVmForExternalGrid(string gridCode, string rowCode, string colCode, string value)
        {
            double parseResult;
            return new CellVm()
            {
                GridCode = gridCode,
                RowCode = rowCode,
                ColCode = colCode,
                Value = value,
                NumValue = double.TryParse(value, out parseResult) ? parseResult : 0
            };
        }

        private static RowVm BuildRowVmForExternalGrid(string gridCode, string rowCode)
        {
            return new RowVm()
            {
                GridCode = gridCode,
                RowCode = rowCode,
                Cells = new List<CellVm>()
            };
        }
        #endregion
        
        private static List<CalcExpressionVm> GetCalcsForCell(List<GetCalcs_Result> allExpandedCalcs, Dictionary<string, CalcExpressionVm> cellCalcDic, Dictionary<string, CalcExpressionVm> colCalcDic, Dictionary<string, CalcExpressionVm> rowCalcDic, string gridCode, string rowCode, string colCode)
        {
            var thisCellsCalcTargets = allExpandedCalcs.Where(cc => cc.GridCode == gridCode && cc.RowCode == rowCode && cc.ColCode == colCode).Select(ac => ac.CalcExpressionId + "." + ac.TargetGridCode + "." + ac.TargetRowCode + "." + ac.TargetColCode);
            var thisCellsCalcs = new List<CalcExpressionVm>();
            thisCellsCalcs.AddRange(cellCalcDic.Where(dc => thisCellsCalcTargets.Contains(dc.Key)).Select(dc => dc.Value).ToList());
            thisCellsCalcs.AddRange(colCalcDic.Where(dc => thisCellsCalcTargets.Contains(dc.Key)).Select(dc => dc.Value).ToList());
            thisCellsCalcs.AddRange(rowCalcDic.Where(dc => thisCellsCalcTargets.Contains(dc.Key)).Select(dc => dc.Value).ToList());
            return thisCellsCalcs;
        }
    }
}
