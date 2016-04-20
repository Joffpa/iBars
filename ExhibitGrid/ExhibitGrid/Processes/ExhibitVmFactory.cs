using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using Antlr.Runtime;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.ViewModel;
using ExhibitGrid.Globals;

namespace ExhibitGrid.Processes
{
    public class ExhibitVmFactory
    {

        private const string Mockgrid = "MockGrid";
        private const string MiniOp5 = "MiniOp5";

        //private int _numRows;
        private readonly int _numCols;
        private readonly int _totalRow;
        private readonly int[] _hiddenCols;
        private readonly int _numVisibleCols;

        public ExhibitVmFactory()
        {
             //_numRows = 25;
             _numCols = 24;
             _totalRow = 1; // value of 1 means Row_1 is set as the total row
             _hiddenCols = new int[3] { 3, 4, 5 };
             _numVisibleCols = _numCols - _hiddenCols.Count();
        }
        
        public ExhibitVm GetExhibitVm(string gridCode)
        {
            var exhibit = new ExhibitVm()
            {
                Grids = new List<GridVm>(),
                PrimaryGridCode = gridCode
            };
            switch (gridCode)
            {
                case Mockgrid:
                    exhibit.Grids.Add(GetMockGridVmV2());
                    return exhibit;
                //case MiniOp5:
                //    exhibit.Grids.Add(GetMiniOp5Vm());
                //    return exhibit;
                default:
                    return GetGridFromDb(gridCode);
            }
        }

        #region Get From DB

        private ExhibitVm GetGridFromDb(string gridCode, ExhibitVm exhibit = null)
        {
            return ExhibitVmProcess.GetExhibitVmWithCalcs(gridCode, exhibit);
        }

        #endregion

        #region MockGrid
        private GridVm GetMockGridVmV2()
        {
            var grid = new GridVm { GridCode = Mockgrid, DisplayText = "Grid Name", Columns = new List<ColumnVm>() };

            //Add Column headers to list

            var colHeader = new ColumnVm
            {
                ColCode = "Level3Header",
                HasHeader = true,
                DisplayText = "Level 3 Header",
                Level = 3,
                DisplayOrder = 0,
                ColSpan = _numVisibleCols - 3
            };
            grid.Columns.Add(colHeader);

            colHeader = new ColumnVm
            {
                ColCode = "Level2HeaderA",
                HasHeader = true,
                DisplayText = "Level 2 Header A",
                Level = 2,
                DisplayOrder = 0,
                ColSpan = (_numVisibleCols - 3)/2
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level2HeaderB",
                HasHeader = true,
                DisplayText = "Level 2 Header B",
                Level = 2,
                DisplayOrder = 1,
                ColSpan = ((_numVisibleCols - 3) - (_numVisibleCols - 3)/2)
            };
            grid.Columns.Add(colHeader);

            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderA",
                HasHeader = true,
                DisplayText = "Level 1 Header A",
                Level = 1,
                DisplayOrder = 0,
                ColSpan = ((_numVisibleCols - 3)/2)/3
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderB",
                HasHeader = true,
                DisplayText = "Level 1 Header B",
                Level = 1,
                DisplayOrder = 1,
                ColSpan = ((_numVisibleCols - 3)/2)/3
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderC",
                HasHeader = true,
                DisplayText = "Level 1 Header C",
                Level = 1,
                DisplayOrder = 2,
                ColSpan = ((_numVisibleCols - 3)/2) - ((((_numVisibleCols - 3)/2)/3)*2)
            };
            grid.Columns.Add(colHeader);

            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderA",
                HasHeader = true,
                DisplayText = "Level 1 Header D",
                Level = 1,
                DisplayOrder = 3,
                ColSpan = ((_numVisibleCols - 3) - (_numVisibleCols - 3)/2)/3
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderB",
                HasHeader = true,
                DisplayText = "Level 1 Header E",
                Level = 1,
                DisplayOrder = 4,
                ColSpan = ((_numVisibleCols - 3) - (_numVisibleCols - 3)/2)/3
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderC",
                HasHeader = true,
                DisplayText = "Level 1 Header F",
                Level = 1,
                DisplayOrder = 5,
                ColSpan =
                    (((_numVisibleCols - 3) - (_numVisibleCols - 3)/2) -
                     (((_numVisibleCols - 3) - (_numVisibleCols - 3)/2)/3)*2)
            };
            grid.Columns.Add(colHeader);

            //Hidden Col Headers
            colHeader = new ColumnVm
            {
                ColCode = "RowText",
                HasHeader = false,
                Type = Literals.ColCellType.Text,
                Width = "200px",
                DisplayText = "RowText",
                Level = 0,
                DisplayOrder = -4,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "PostIt",
                HasHeader = false,
                Type = Literals.ColCellType.Postit,
                Width = "",
                DisplayText = "PostIt",
                Level = 0,
                DisplayOrder = -3,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Narrative",
                HasHeader = false,
                Type = Literals.ColCellType.Narrative,
                Width = "",
                DisplayText = "Narrative",
                Level = 0,
                DisplayOrder = -2,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "DoubleOne",
                HasHeader = true,
                Type = Literals.ColCellType.Text,
                Width = "150px",
                DisplayText = "D1",
                Level = 0,
                DisplayOrder = -1,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "DoubleTwo",
                HasHeader = true,
                Type = Literals.ColCellType.Text,
                Width = "150px",
                DisplayText = "D2",
                Level = 0,
                DisplayOrder = 0,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "DropDown",
                HasHeader = true,
                Type = Literals.ColCellType.Dropdown,
                Width = "",
                DisplayText = "DropDown Header with a long string <br/> of text because why not",
                Level = 0,
                DisplayOrder = 1,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);

            for (int col = 0; col < _numCols - 6; col++)
            {
                colHeader = new ColumnVm
                {
                    ColCode = "Col_" + col,
                    HasHeader = !_hiddenCols.Contains(col),
                    IsHidden = _hiddenCols.Contains(col),
                    Type = Literals.ColCellType.Numeric,
                    Width = null,
                    DisplayText = "Level 0 Header " + Convert.ToChar(col + 65),
                    Level = 0,
                    DisplayOrder = col + 10,
                    ColSpan = 1
                };
                grid.Columns.Add(colHeader);
            }
            
            //Add Rows
            grid.Rows = new List<RowVm>
            {
                CreateSubHeaderRowMockGrid(0, 0),
                CreateDataRowMockGrid(grid,1, 50, false, false, false, false, 0, new int[0]), //total row
                CreateDataRowMockGrid(grid,2, 2, true, true, true, false, 0, new[]{3, 4, 5, 6}), //parent a
                CreateDataRowMockGrid(grid,3, 3, false, false, false, true, 1, new int[0]), //child of a
                CreateDataRowMockGrid(grid,4, 4, false, false, false, true, 1, new int[0]), //child of a
                CreateDataRowMockGrid(grid,5, 5, false, false, false, true, 1, new int[0]), //child of a
                CreateDataRowMockGrid(grid,6, 6, false, false, false, true, 1, new int[0]), //child of a
                CreateSubHeaderRowMockGrid(7, 7),
                CreateDataRowMockGrid(grid,8, 8, true, true, true, false, 0, new[]{9, 10, 11, 12}), //parent b
                CreateDataRowMockGrid(grid,9, 9, false, false, false, true, 1, new int[0]), //child of b
                CreateDataRowMockGrid(grid,10, 10, false, false, false, true, 1, new int[0]), //child of b
                CreateDataRowMockGrid(grid,11, 11, false, false, false, true, 1, new int[0]), //child of b
                CreateDataRowMockGrid(grid,12, 12, false, false, false, true, 1, new int[0]), //child of b
            };


            //for (var r = 1; r <= numRows; r++)
            //{    
            //    if(r % 8 == 0)
            //    {
            //        grid.DataRows.Add(CreateSubHeaderRowMockGrid(r));
            //    }
            //    else
            //    {
            //        grid.DataRows.Add(CreateDataRowMockGrid(r));
            //    }
            //}

            #region calcs

            //do some fake summing to get the correct initial values in the "total" cells 
            foreach (var row in grid.Rows)
            {
                for (int i = 2; i <= row.Cells.Count - 6; i += 3){

                    var prevPrevCellVal = row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + (i - 2)).NumValue;
                    var prevCellVal = row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + (i - 1)).NumValue;
                    row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + i).NumValue = prevPrevCellVal + prevCellVal;

                }
            }

            var totalRowVm = grid.Rows.FirstOrDefault(r => r.RowCode == "Row_" + _totalRow);

            if (totalRowVm != null)
                foreach(var cell in totalRowVm.Cells.Where(c => c.ColCode.Substring(0, 3) == "Col"  ))
                {
                    var sum = (from row in grid.Rows.Where(r => r.RowCode != totalRowVm.RowCode) 
                        let cl = row.Cells.FirstOrDefault(c => c.ColCode == cell.ColCode) 
                        where cl != null 
                        select cl.NumValue).Sum();
                    cell.NumValue = sum;

                }
            
            //var calcExpandProcess = new CalcExpandProcess(grid, rowCalcOperands);
            //calcExpandProcess.Process();
            #endregion
            return grid;
        }
        
        private RowVm CreateSubHeaderRowMockGrid(int r, int order)
        {
            var subHeaderRow = new RowVm
            {
                GridCode = Mockgrid,
                RowCode = "Row_" + r,
                DisplayOrder = order,
                Class = "sub-header-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                IsCollapsed = false,
                Cells = new List<CellVm>()
            };
            var rowText = new CellVm
            {
                GridCode = Mockgrid,
                RowCode = subHeaderRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "Sub Header Text",
                ColSpan = _numVisibleCols + 4,
                IsHidden = false,
                IsBlank = false
            };
            subHeaderRow.Cells.Add(rowText);
            
            return subHeaderRow;
        }

        private RowVm CreateDataRowMockGrid(GridVm grid, int r, int order, bool canCollapse, bool canSelect, bool canAdd, bool canDelete, int indent, int[] collapseChildren)
        {
            var dataRow = new RowVm
            {
                GridCode = Mockgrid,
                RowCode = "Row_" + r,
                DisplayOrder = order,
                Class = r == _totalRow ? "total-row" : "data-row",
                CanCollapse = canCollapse,
                CanSelect = canSelect,
                IsSelected = false,
                CanAdd = canAdd,
                CanDelete = canDelete,
                IsHidden = false,
                IsCollapsed = false,
                Cells = new List<CellVm>(),
            };

            var col = grid.Columns.FirstOrDefault(c => c.ColCode == "RowText");
            var rowText = new CellVm
            {
                GridCode = Mockgrid,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = r == _totalRow ? "Total Row" : "Row Text " + r,
                Indent = indent,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = col.ColSpan == 1 ? col.Width : "100%"

            };
            dataRow.Cells.Add(rowText);

            col = grid.Columns.FirstOrDefault(c => c.ColCode == "PostIt");
            var postitCell = new CellVm
            {
                GridCode = Mockgrid,
                RowCode = dataRow.RowCode,
                ColCode = "PostIt",
                IsEditable = true,
                //CanPostIt = false,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = col.ColSpan == 1 ? col.Width : "100%"
            };
            dataRow.Cells.Add(postitCell);

            col = grid.Columns.FirstOrDefault(c => c.ColCode == "Narrative");
            var narrCell = new CellVm
            {
                GridCode = Mockgrid,
                RowCode = dataRow.RowCode,
                ColCode = "Narrative",
                IsEditable = true,
                //CanNarrate = false,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = col.ColSpan == 1 ? col.Width : "100%"
            };
            dataRow.Cells.Add(narrCell);

            col = grid.Columns.FirstOrDefault(c => c.ColCode == "DoubleOne");
            rowText = new CellVm
            {
                GridCode = Mockgrid,
                RowCode = dataRow.RowCode,
                ColCode = "DoubleOne",
                IsEditable = true,
                Value = r % 2 == 0 ? "Double Span Text" : "Single Span Text",
                Indent = 0,
                ColSpan = r%2 == 0 ? 2 : 1,
                IsHidden = false,
                IsBlank = false,
                Width = r % 2 == 0 ? "100%": col.Width
            };
            dataRow.Cells.Add(rowText);

            col = grid.Columns.FirstOrDefault(c => c.ColCode == "DoubleTwo");
            rowText = new CellVm
            {
                GridCode = Mockgrid,
                RowCode = dataRow.RowCode,
                ColCode = "DoubleTwo",
                IsEditable = true,
                Value = "Single Span Text",
                Indent = 0,
                ColSpan = r%2 == 0 ? 0 : 1,
                IsHidden = false,
                IsBlank = false,
                Width = r % 2 == 0 ? "100%" : col.Width
            };
            dataRow.Cells.Add(rowText);

            col = grid.Columns.FirstOrDefault(c => c.ColCode == "DropDown");
            rowText = new CellVm
            {
                GridCode = Mockgrid,
                RowCode = dataRow.RowCode,
                ColCode = "DropDown",
                IsEditable = r%5 != 0,
                Value = " ",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = r == _totalRow,
                Width = col.ColSpan == 1 ? col.Width : "100%"
            };
            dataRow.Cells.Add(rowText);

            for (var c = 0; c < _numCols - 6; c++)
            {
                col = grid.Columns.FirstOrDefault(cl => cl.ColCode == "Col_" + c);
                var cell = new CellVm
                {
                    GridCode = Mockgrid,
                    RowCode = dataRow.RowCode,
                    ColCode = "Col_" + c,
                    
                    ColSpan = 1,
                    NumValue = 5*c,
                    IsEditable = c%3 != 2 && r != _totalRow,
                    IsHidden = _hiddenCols.Contains(c),
                    IsBlank = r % 5 == 0 && c == 0 ? true : false,
                    Width = col.ColSpan == 1 ? col.Width : "100%",
                    Calcs  = new List<CalcExpressionVm>()
                };
                dataRow.Cells.Add(cell);
            }
            return dataRow;
        }




        #endregion
        
    }

}