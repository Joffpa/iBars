using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.Globals;
using ExhibitGrid.ViewModel;

namespace ExhibitGrid.Processes
{
	public class GetGridVmProcess
	{
	    public static GridVm Process(string gridCode)
	    {
            var grid = new GridVm()
            {
                GridCode = gridCode,
                Columns = new List<ColumnVm>(),
                DataRows = new List<RowVm>(),
                IsEditable = true,
                HasSelectCol =  false,
                HasCollapseCol = false,
                HasAddCol = false,
                HasDeleteCol = false
            };
            try
            {
                using (var db = new DEV_AF())
                {
                    var calcs = db.GetCalcs(gridCode).ToList();
                    var thisGridsCalcs = calcs.Where(c => c.TargetGridCode == gridCode);
                    List<GetCalcs_Result> rowCalcResults = new List<GetCalcs_Result>();
                    List<GetCalcs_Result> cellCalcsExpandedFromRowCalcs = new List<GetCalcs_Result>();
                    List<GetCalcs_Result> colCalcResults = new List<GetCalcs_Result>();
                    List<GetCalcs_Result> cellCalcsExpandedFromColCalcs = new List<GetCalcs_Result>();
                    List<GetCalcs_Result> cellCalcResults = new List<GetCalcs_Result>();
                    foreach (var calc in thisGridsCalcs)
                    {
                        if (string.IsNullOrEmpty(calc.TargetColCode))
                        {
                            rowCalcResults.Add(calc);
                        }
                        else if (string.IsNullOrEmpty(calc.TargetRowCode))
                        {
                            colCalcResults.Add(calc);
                        }
                        else
                        {
                            cellCalcResults.Add(calc);
                        }
                    }
                    
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
                            grid.Columns.Add(new ColumnVm()
                            {
                                ColCode = attrib.ColCode,
                                ColSpan = attrib.ColSpan ?? 1,
                                Directive = attrib.Directive,
                                DisplayOrder = attrib.DisplayOrder ?? 1,
                                DisplayText = attrib.DisplayText,
                                HasHeader = attrib.HasHeader ?? true,
                                IsHidden = attrib.IsHidden ?? false,
                                Level = attrib.Level ?? 0,
                                Width = attrib.Width,
                                IsEditable = attrib.IsEditable ?? false,
                                Class = attrib.Class,
                                Alignment = attrib.Alignment
                            });
                            //For Numeric columns expand the row calcs for every column and add to cell calcs
                            if (attrib.Directive == Literals.Directive.Numeric)
                            cellCalcsExpandedFromRowCalcs.AddRange(rowCalcResults.Select(rowCalc => new GetCalcs_Result()
                            {
                                TargetGridCode = rowCalc.TargetGridCode, 
                                TargetRowCode = rowCalc.TargetRowCode, 
                                TargetColCode = attrib.ColCode,
                                Expression = rowCalc.Expression.Split('.').Aggregate((c, n) => n == "" ? c + "." + attrib.ColCode + n: c + "." + n), 
                                GridCode = rowCalc.GridCode, 
                                RowCode = rowCalc.RowCode, 
                                ColCode = attrib.ColCode
                            }));
                        }
                        else if (!string.IsNullOrEmpty(attrib.RowCode) && string.IsNullOrEmpty(attrib.ColCode))
                        {
                            grid.HasSelectCol = (attrib.CanSelect ?? false) || grid.HasSelectCol;
                            grid.HasCollapseCol = (attrib.CanCollapse ?? false) || grid.HasCollapseCol;
                            grid.HasAddCol = (attrib.CanAdd ?? false) || grid.HasAddCol;
                            grid.HasDeleteCol = (attrib.CanDelete ?? false) || grid.HasDeleteCol;
                            grid.DataRows.Add(new RowVm()
                            {
                                GridCode = attrib.GridCode,
                                RowCode = attrib.RowCode,
                                ParentRowCode = attrib.ParentRowCode,
                                CanSelect = attrib.CanSelect ?? false,
                                CanCollapse = attrib.CanCollapse ?? false,
                                CanAdd = attrib.CanAdd ?? false,
                                CanDelete = attrib.CanDelete ?? false,
                                Cells = new List<CellVm>(),
                                Class = attrib.Class,
                                DisplayOrder = attrib.DisplayOrder ?? 0,
                                IsSelected = false,
                                IsCollapsed = false,
                                IsHidden = attrib.IsHidden ?? false,
                                IsEditable = attrib.IsEditable ?? false
                            });
                            cellCalcsExpandedFromColCalcs.AddRange(colCalcResults.Select(colCalc => new GetCalcs_Result()
                            {
                                TargetGridCode = colCalc.TargetGridCode,
                                TargetRowCode = attrib.RowCode,
                                TargetColCode = colCalc.TargetColCode,
                                Expression = colCalc.Expression.Split('.').Aggregate((c, n) => n == "" ? c + "." + attrib.RowCode + n : c + "." + n),
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
                    var allExpandedCellCalcs = cellCalcResults;


                    //allExpandedCellCalcs.AddRange(cellCalcsExpandedFromRowCalcs.Where(rc => rc.TargetGridCode));

                    var calcGroups = cellCalcResults.GroupBy(r => new {r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression},
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
                            }).ToList();


                    calcGroups.AddRange(cellCalcsExpandedFromColCalcs.Where(cc => !calcGroups.Any(cg => cg.TargetGridCode == cc.TargetGridCode && cg.TargetRowCode == cc.TargetRowCode && cg.TargetColCode == cc.TargetColCode)).GroupBy(
                            r => new { r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression },
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
                    calcGroups.AddRange(cellCalcsExpandedFromRowCalcs.Where(rc => !calcGroups.Any(cg => cg.TargetGridCode == rc.TargetGridCode && cg.TargetRowCode == rc.TargetRowCode && cg.TargetColCode == rc.TargetColCode)).GroupBy(
                            r => new { r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression },
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

                    var cellCalcDic = calcGroups.ToDictionary(ac => ac.TargetGridCode + "." + ac.TargetRowCode + "." + ac.TargetColCode);
                    foreach (var row in grid.DataRows)
                    {
                        foreach (var col in grid.Columns.Where(c => c.Level == 0).OrderBy(c => c.DisplayOrder))
                        {
                            var cellAttrib = cellDictionary[grid.GridCode + row.RowCode + col.ColCode];
                            double numval;
                            var valParsed = double.TryParse(cellAttrib.Value, out numval);
                            var span = cellAttrib.ColSpan ?? col.ColSpan;
                            row.Cells.Add(new CellVm()
                            {
                                GridCode = grid.GridCode,
                                RowCode = row.RowCode,
                                ColCode = col.ColCode,
                                ParentRowCode = row.ParentRowCode,
                                Class = cellAttrib.Class,
                                ColSpan = span,
                                ColumnHeader = col.DisplayText,
                                Indent = cellAttrib.Indent ?? 0,
                                IsBlank = cellAttrib.IsBlank ?? false,
                                IsEditable = (cellAttrib.IsEditable ?? false) && row.IsEditable && col.IsEditable && grid.IsEditable,
                                IsHidden = cellAttrib.IsHidden ?? false,
                                Value = cellAttrib.Value,
                                NumValue = valParsed ? numval : 0,
                                Width = (span == 1 ? col.Width : "100%"),
                                Calcs = col.Directive == Literals.Directive.Numeric ? GetCalcsForCell(cellCalcResults, cellCalcDic, grid.GridCode, row.RowCode, col.ColCode) : null
                            });
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

        private static List<CalcExpressionVm> GetCalcsForCell(List<GetCalcs_Result> cellCalcs, Dictionary<string, CalcExpressionVm> allCalcExpressions, string gridCode, string rowCode, string colCode)
        {
            var thisCellsCalcs = cellCalcs.Where(cc => cc.GridCode == gridCode && cc.RowCode == rowCode && cc.ColCode == colCode).Select(ac => ac.TargetGridCode + "." + ac.TargetRowCode + "." + ac.TargetColCode);
            return allCalcExpressions.Where(dc => thisCellsCalcs.Contains(dc.Key)).Select(dc => dc.Value).ToList();
        } 
	}
}