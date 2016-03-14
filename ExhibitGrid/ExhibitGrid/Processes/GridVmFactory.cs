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
    public class GridVmFactory
    {

        private const string Mockgrid = "MockGrid";
        private const string MiniOp5 = "MiniOp5";

        //private int _numRows;
        private readonly int _numCols;
        private readonly int _totalRow;
        private readonly int[] _hiddenCols;
        private readonly int _numVisibleCols;

        public GridVmFactory()
        {
             //_numRows = 25;
             _numCols = 24;
             _totalRow = 1; // value of 1 means Row_1 is set as the total row
             _hiddenCols = new int[3] { 3, 4, 5 };
             _numVisibleCols = _numCols - _hiddenCols.Count();
        }
        
        public GridVm GetGridVm(string gridCode)
        {
            switch (gridCode)
            {
                case Mockgrid:
                    return GetMockGridVmV2();
                case MiniOp5:
                    return GetMiniOp5Vm();
                default:
                    return GetGridFromDb(gridCode);
            }
        }

        #region Get From DB

        private GridVm GetGridFromDb(string gridCode)
        {
            return GetGridVmProcess.Process(gridCode);
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
                Directive = Literals.Directive.Text,
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
                Directive = Literals.Directive.Postit,
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
                Directive = Literals.Directive.Narrative,
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
                Directive = Literals.Directive.Text,
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
                Directive = Literals.Directive.Text,
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
                Directive = Literals.Directive.DropDown,
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
                    Directive = Literals.Directive.Numeric,
                    Width = null,
                    DisplayText = "Level 0 Header " + Convert.ToChar(col + 65),
                    Level = 0,
                    DisplayOrder = col + 10,
                    ColSpan = 1
                };
                grid.Columns.Add(colHeader);
            }
            
            //Add Rows
            grid.DataRows = new List<RowVm>
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
            foreach (var row in grid.DataRows)
            {
                for (int i = 2; i <= row.Cells.Count - 6; i += 3){

                    var prevPrevCellVal = row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + (i - 2)).NumValue;
                    var prevCellVal = row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + (i - 1)).NumValue;
                    row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + i).NumValue = prevPrevCellVal + prevCellVal;

                }
            }

            var totalRowVm = grid.DataRows.FirstOrDefault(r => r.RowCode == "Row_" + _totalRow);

            if (totalRowVm != null)
                foreach(var cell in totalRowVm.Cells.Where(c => c.ColCode.Substring(0, 3) == "Col"  ))
                {
                    var sum = (from row in grid.DataRows.Where(r => r.RowCode != totalRowVm.RowCode) 
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
                CollapseableChildren = collapseChildren.Select(c => "Row_" + c).ToList()
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
                    Class = "data-cell",
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
        
        #region MiniOp5
        private GridVm GetMiniOp5Vm()
        {
            var grid = new GridVm {GridCode = MiniOp5, DisplayText = "SAG 122", Columns = new List<ColumnVm>()};

            #region Headers
            //Top level headers
            var colHeader = new ColumnVm
            {
                ColCode = "Op5Header",
                HasHeader = true,
                DisplayText = "OP-5",
                Level = 1,
                DisplayOrder = 0,
                ColSpan = 7
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Op32Header",
                HasHeader = true,
                DisplayText = "OP-32",
                Level = 1,
                DisplayOrder = 1,
                ColSpan = 19
            };
            grid.Columns.Add(colHeader);

            //Level 0 headers under OP-5
            colHeader = new ColumnVm
            {
                ColCode = "RowText",
                HasHeader = false,
                IsHidden = false,
                Directive = "text",
                Width = "400px",
                DisplayText = "row text",
                Level = 0,
                DisplayOrder = -2,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Description",
                HasHeader = false,
                IsHidden = false,
                Directive = "narrative",
                Width = "",
                DisplayText = "Desc",
                Level = 0,
                DisplayOrder = -1,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "CyBaseline",
                HasHeader = true,
                IsHidden = false,
                Directive = "numeric",
                Width = "",
                DisplayText = "FY 2016 Baseline",
                Level = 0,
                DisplayOrder = 0,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "StubAmt",
                HasHeader = true,
                IsHidden = false,
                Directive = "numeric",
                Width = "",
                DisplayText = "Stub Amount",
                Level = 0,
                DisplayOrder = 1,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "BY1Prog",
                HasHeader = true,
                IsHidden = false,
                Directive = "numeric",
                Width = "",
                DisplayText = "FY 2017 Program",
                Level = 0,
                DisplayOrder = 2,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Mdep",
                HasHeader = true,
                IsHidden = false,
                Directive = "text",
                Width = "",
                DisplayText = "MDEP",
                Level = 0,
                DisplayOrder = 3,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Ape",
                HasHeader = true,
                IsHidden = false,
                Directive = "text",
                Width = "",
                DisplayText = "APE",
                Level = 0,
                DisplayOrder = 4,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Cmd",
                HasHeader = true,
                IsHidden = false,
                Directive = "text",
                Width = "",
                DisplayText = "CMD",
                Level = 0,
                DisplayOrder = 5,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Ftes",
                HasHeader = true,
                IsHidden = false,
                Directive = "numeric",
                Width = "",
                DisplayText = "FTEs",
                Level = 0,
                DisplayOrder = 6,
                ColSpan = 1
            };
            grid.Columns.Add(colHeader);

            //Level 0 headers under OP-32
            grid.Columns.Add(GetOp32ColHeader("Op32Total", 7));
            grid.Columns.Add(GetOp32ColHeader("0101", 8));
            grid.Columns.Add(GetOp32ColHeader("0103", 9));
            grid.Columns.Add(GetOp32ColHeader("0104", 10));
            grid.Columns.Add(GetOp32ColHeader("0105", 11));
            grid.Columns.Add(GetOp32ColHeader("0106", 12));
            grid.Columns.Add(GetOp32ColHeader("0107", 13));
            grid.Columns.Add(GetOp32ColHeader("0110", 14));
            grid.Columns.Add(GetOp32ColHeader("0111", 15));
            grid.Columns.Add(GetOp32ColHeader("0308", 16));
            grid.Columns.Add(GetOp32ColHeader("0401", 17));
            grid.Columns.Add(GetOp32ColHeader("0402", 18));
            grid.Columns.Add(GetOp32ColHeader("0411", 19));
            grid.Columns.Add(GetOp32ColHeader("0412", 20));
            grid.Columns.Add(GetOp32ColHeader("0414", 21));
            grid.Columns.Add(GetOp32ColHeader("0416", 22));
            grid.Columns.Add(GetOp32ColHeader("0417", 23));
            grid.Columns.Add(GetOp32ColHeader("0422", 24));
            grid.Columns.Add(GetOp32ColHeader("0423", 25));
            #endregion

            grid.DataRows = new List<RowVm>();

            AddSubHeader1(grid);
            AddTotalRowSub1(grid);
            AddBlankRow(grid, "blank_1");

            AddSubHeader2(grid);
            AddTotalRowSub2(grid);
            AddBlankRow(grid, "blank_2");

            AddSubHeader3(grid);
            AddRow1Sub3(grid);
            AddRow1Child1Sub3(grid);
            AddRow2Sub3(grid);
            AddRow2Child1Sub3(grid);
            AddTotalRowSub3(grid);
            AddBlankRow(grid, "blank_3");


            AddSubHeader4(grid);
            AddRow1Sub4(grid);
            AddRow1Child1Sub4(grid);
            AddRow1Child2Sub4(grid);
            AddRow1Child3Sub4(grid);
            AddRow2Sub4(grid);
            AddRow2Child1Sub4(grid);
            AddTotalRowSub4(grid);
            AddBlankRow(grid, "blank_4");


            return grid;
        }

        private ColumnVm GetOp32ColHeader(string colCode, int order)
        {
            var colHeader = new ColumnVm
            {
                ColCode = colCode,
                HasHeader = true,
                IsHidden = false,
                Directive = "numeric",
                Width = "",
                DisplayText = colCode,
                Level = 0,
                DisplayOrder = order,
                ColSpan = 1
            };
            return colHeader;
        }

        private void AddSubHeader1(GridVm grid)
        {
            //First Sub Header for grouping 1
            var subHeaderRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "2017TransferInTitle",
                Class = "sub-header-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };


            var rowText = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = subHeaderRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "FY 2017 Transfer-in Title",
                ColSpan = grid.Columns.Count(ch => ch.Level == 0),
                IsHidden = false,
                IsBlank = false
            };
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddTotalRowSub1(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Total_Row_Sub_1",
                Class = "grand-total-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "Total",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = false,
                Width = "400px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", false));
            grid.DataRows.Add(dataRow);
        }

        private void AddBlankRow(GridVm grid, string rowCode)
        {
            //First Sub Header for grouping 1
            var subHeaderRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = rowCode,
                Class = "blank-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };


            var rowText = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = subHeaderRow.RowCode,
                ColCode = "blank_1",
                IsEditable = false,
                Value = "",
                ColSpan = grid.Columns.Count(ch => ch.Level == 0),
                IsHidden = false,
                IsBlank = true
            };
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddSubHeader2(GridVm grid)
        {
            //First Sub Header for grouping 1
            var subHeaderRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "2017TransferOutTitle",
                Class = "sub-header-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };


            var rowText = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = subHeaderRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "FY 2017 Transfer-Out Title",
                ColSpan = grid.Columns.Count(ch => ch.Level == 0),
                IsHidden = false,
                IsBlank = true
            };
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddTotalRowSub2(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Total_Row_Sub_2",
                Class = "grand-total-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "Total",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = false,
                Width = "400px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", false));
            grid.DataRows.Add(dataRow);
        }

        private void AddSubHeader3(GridVm grid)
        {
            //First Sub Header for grouping 1
            var subHeaderRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "2017ProgGrowth",
                Class = "sub-header-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };

            var rowText = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = subHeaderRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "FY 2017 Program Growth Title",
                ColSpan = grid.Columns.Count(ch => ch.Level == 0),
                IsHidden = false,
                IsBlank = false,
                Width = "400px"
            };
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddRow1Sub3(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_1_Sub_3",
                Class = "total-row",
                CanCollapse = true,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>(),
                CollapseableChildren = new List<string>() { "Row_1_Child_1_Sub_3" }
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value =
                    "Tactical Exploitation of National Capabilities (TENCAP) Military Exploitation of Reconnaissance and Intelligence Technology (MERIT)  Projects",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "400px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value =
                    "Provides operational support and below depot-level maintenance of classified, low-density tactical intelligence software and equipment performed or managed at the National Level by either in-house or joint national contractor activities provided by TENCAP MERIT Projects. Provides for the sustainment of these national capabilities until fully transitioned into an Army Program of Record.Includes operations and maintenance of software and equipment, necessary facilities, and the associated costs specifically identified and measurable to these units.",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 2044,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = true,
                NumValue = 2044,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", false));
            grid.DataRows.Add(dataRow);
        }

        private void AddRow1Child1Sub3(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_1_Child_1_Sub_3",
                Class = "data-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                IsCollapsed = true,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 2044,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 2044,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "FPDP",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "122011",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "5D0",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", true));
            grid.DataRows.Add(dataRow);
        }

        private void AddRow2Sub3(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_2_Sub_3",
                Class = "total-row",
                CanCollapse = true,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>(),
                CollapseableChildren = new List<string>() { "Row_2_Child_1_Sub_3" }
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "Combat Support Medical",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "400px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value =
                    "Increases funding for the U.S. Army Medical Command's Medical Combat Support Program. Medical Equipment Sets(MES) include state of the art initial trauma resuscitation equipment and are fielded to units and medical personnel that treat from the point of injury through the combat support hospitals levels of care.  MES may consist of ambulatory care, dental, environmental, laboratory/ blood gas, therapy / treatment, testing measurement diagnostic equipment, veterinary, and x - ray sets.Funding will fill equipment shortages or upgrade outdated equipment in approximately approximately 1,000 MESes throughout the Army. POC: Ben Ervin",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 38686,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 10430,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = true,
                NumValue = 49116,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", false));

            grid.DataRows.Add(dataRow);
        }

        private void AddRow2Child1Sub3(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_2_Child_1_Sub_3",
                Class = "data-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                IsCollapsed = true,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 38686,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 10430,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 49116,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "FL8D",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "122011",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "740",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", true));
            grid.DataRows.Add(dataRow);
        }

        private void AddTotalRowSub3(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Total_Row_Sub_3",
                Class = "grand-total-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "Total",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 38686,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 12474,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 51160,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", false));
            grid.DataRows.Add(dataRow);
        }

        private void AddSubHeader4(GridVm grid)
        {
            var subHeaderRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "2017ProgDecre",
                Class = "sub-header-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };


            var rowText = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = subHeaderRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "FY 2017 Program Decreases Title",
                ColSpan = grid.Columns.Count(ch => ch.Level == 0),
                IsHidden = false,
                IsBlank = false
            };
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddRow1Sub4(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_1_Sub_4",
                Class = "total-row",
                CanCollapse = true,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>(),
                CollapseableChildren = new List<string>() { "Row_1_Child_1_Sub_4", "Row_1_Child_2_Sub_4", "Row_1_Child_3_Sub_4" }
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "Civilian Workforce Reduction",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "400px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value =
                    "Reduces funding and 29 FTEs to shape the civilian workforce commensurate with force structure levels.",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 172380,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = -3996,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = true,
                NumValue = 168384,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", false));
            grid.DataRows.Add(dataRow);
        }

        private void AddRow1Child1Sub4(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_1_Child_1_Sub_4",
                Class = "data-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                IsCollapsed = true,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 50000,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 50000,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "HSMR",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "122018",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "740",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = -2,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", true));
            grid.DataRows.Add(dataRow);
        }

        private void AddRow1Child2Sub4(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_1_Child_2_Sub_4",
                Class = "data-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                IsCollapsed = true,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 50000,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 50000,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "VTRD",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "122018",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "570",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = -26,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", true));
            grid.DataRows.Add(dataRow);
        }

        private void AddRow1Child3Sub4(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_1_Child_3_Sub_4",
                Class = "data-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                IsCollapsed = true,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 72308,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = -3996,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 68384,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "WSCC",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "122152",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "890",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = -2,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", true));
            grid.DataRows.Add(dataRow);
        }

        private void AddRow2Sub4(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_2_Sub_4",
                Class = "total-row",
                CanCollapse = true,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>(),
                CollapseableChildren = new List<string>() { "Row_2_Child_1_Sub_4"}
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "Army Service Component Command Tactical Units",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "400px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "One-time decrease in funding to address civilian pay affordability in U.S. Army Europe.",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 19708,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = -2511,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = true,
                NumValue = 17197,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", false));
            grid.DataRows.Add(dataRow);
        }

        private void AddRow2Child1Sub4(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Row_2_Child_1_Sub_4",
                Class = "data-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                IsCollapsed = true,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = true
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 19708,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = -2511,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 17197,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "WSCC",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "122152",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "740",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", true));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", true));
            grid.DataRows.Add(dataRow);
        }

        private void AddTotalRowSub4(GridVm grid)
        {
            var dataRow = new RowVm
            {
                GridCode = grid.GridCode,
                RowCode = "Total_Row_Sub_4",
                Class = "grand-total-row",
                CanCollapse = false,
                CanSelect = false,
                IsSelected = false,
                CanAdd = false,
                CanDelete = false,
                IsHidden = false,
                Cells = new List<CellVm>()
            };
            var cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Value = "Total",
                Indent = 0,
                ColSpan = 2,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Description",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 0,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "CyBaseline",
                IsEditable = false,
                NumValue = 192088,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "StubAmt",
                Class = "data-cell",
                IsEditable = false,
                NumValue = -6507,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "BY1Prog",
                Class = "data-cell",
                IsEditable = false,
                NumValue = 185581,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Mdep",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ape",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Cmd",
                Class = "text-cell",
                IsEditable = false,
                Value = "",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = true,
                Width = "60px"
            };
            dataRow.Cells.Add(cell);
            cell = new CellVm
            {
                GridCode = grid.GridCode,
                RowCode = dataRow.RowCode,
                ColCode = "Ftes",
                Class = "data-cell",
                IsEditable = false,
                NumValue = -30,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false,
                Width = "40px"
            };
            dataRow.Cells.Add(cell);

            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "Op32Total", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0101", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0103", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0104", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0105", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0106", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0107", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0110", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0111", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0308", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0401", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0402", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0411", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0412", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0414", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0416", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0417", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0422", false));
            dataRow.Cells.Add(GetOp32Col(grid.GridCode, dataRow.RowCode, "0423", false));
            grid.DataRows.Add(dataRow);
        }

        private CellVm GetOp32Col(string gridCode, string rowCode, string colCode, bool isEditable)
        {
            var cell = new CellVm
            {
                GridCode = gridCode,
                RowCode = rowCode,
                ColCode = colCode,
                Class = "data-cell",
                IsEditable = isEditable,
                NumValue = 0,
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            return cell;
        }
        #endregion
    }

}