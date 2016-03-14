using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExhibitGrid.EntityDataModel;
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
                DataRows = new List<RowVm>()
            };
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
                                IsEditable = attrib.IsEditable ?? false
                            });
                        }
                        else if (!string.IsNullOrEmpty(attrib.RowCode) && string.IsNullOrEmpty(attrib.ColCode))
                        {
                            grid.DataRows.Add(new RowVm()
                            {
                                CanAdd = attrib.CanAdd ?? false,
                                CanCollapse = attrib.CanCollapse ?? false,
                                CanDelete = attrib.CanDelete ?? false,
                                CanSelect = attrib.CanSelect ?? false,
                                Cells = new List<CellVm>(),
                                Class = attrib.Class,
                                CollapseableChildren = new List<string>(),
                                DisplayOrder = attrib.DisplayOrder ?? 0,
                                GridCode = attrib.GridCode,
                                IsSelected = false,
                                IsCollapsed = false,
                                IsHidden = attrib.IsHidden ?? false,
                                RowCode = attrib.RowCode,
                                IsEditable = attrib.IsEditable ?? false
                            });
                        }
                        else
                        {
                            grid.IsEditable = attrib.IsEditable ?? true;
                            grid.DisplayText = attrib.DisplayText;
                        }
                    }
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
                                Class = cellAttrib.Class,
                                ColCode = col.ColCode,
                                ColSpan = span,
                                ColumnHeader = col.DisplayText,
                                GridCode = grid.GridCode,
                                Indent = cellAttrib.Indent ?? 0,
                                IsBlank = cellAttrib.IsBlank ?? false,
                                IsEditable = (cellAttrib.IsEditable ?? (row.IsEditable || col.IsEditable)) && grid.IsEditable,
                                IsHidden = cellAttrib.IsHidden ?? false,
                                RowCode = row.RowCode,
                                Value = cellAttrib.Value,
                                NumValue = valParsed ? numval : 0,
                                Width = (span == 1 ? col.Width : "100%")
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
	}
}