using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr.Runtime;
using ExhibitGrid.ViewModel;

namespace ExhibitGrid.Processes
{
    public class GridVmFactory
    {

        private const string MOCKGRID = "MockGrid";

        private int numRows;
        private int numCols;
        private int totalRow;
        private int[] hiddenCols;
        private int numVisibleCols;

        public GridVmFactory()
        {
             numRows = 25;
             numCols = 24;
             totalRow = 1; // value of 1 means Row_1 is set as the total row
             hiddenCols = new int[3] { 3, 4, 5 };
             numVisibleCols = numCols - hiddenCols.Count();
        }
        
        public GridVm GetGridVmV2(string gridCode)
        {
            switch (gridCode)
            {
                case MOCKGRID:
                    return GetMockGridVmV2();
                case "MiniOp5":
                    return GetMiniOp5Vm();
                default:
                    return null;
            }
        }

        #region MockGrid
        private GridVm GetMockGridVmV2()
        {
            var grid = new GridVm { GridCode = MOCKGRID, GridName = "Grid Name", ColumnHeaders = new List<ColumnVm>() };

            //Add Column headers to list

            var colHeader = new ColumnVm
            {
                ColCode = "Level3Header",
                HeaderIsVisible = true,
                Text = "Level 3 Header",
                Level = 3,
                DisplayOrder = 0,
                ColSpan = numVisibleCols - 3
            };
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ColumnVm
            {
                ColCode = "Level2HeaderA",
                HeaderIsVisible = true,
                Text = "Level 2 Header A",
                Level = 2,
                DisplayOrder = 0,
                ColSpan = (numVisibleCols - 3)/2
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level2HeaderB",
                HeaderIsVisible = true,
                Text = "Level 2 Header B",
                Level = 2,
                DisplayOrder = 1,
                ColSpan = ((numVisibleCols - 3) - (numVisibleCols - 3)/2)
            };
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderA",
                HeaderIsVisible = true,
                Text = "Level 1 Header A",
                Level = 1,
                DisplayOrder = 0,
                ColSpan = ((numVisibleCols - 3)/2)/3
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderB",
                HeaderIsVisible = true,
                Text = "Level 1 Header B",
                Level = 1,
                DisplayOrder = 1,
                ColSpan = ((numVisibleCols - 3)/2)/3
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderC",
                HeaderIsVisible = true,
                Text = "Level 1 Header C",
                Level = 1,
                DisplayOrder = 2,
                ColSpan = ((numVisibleCols - 3)/2) - ((((numVisibleCols - 3)/2)/3)*2)
            };
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderA",
                HeaderIsVisible = true,
                Text = "Level 1 Header D",
                Level = 1,
                DisplayOrder = 3,
                ColSpan = ((numVisibleCols - 3) - (numVisibleCols - 3)/2)/3
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderB",
                HeaderIsVisible = true,
                Text = "Level 1 Header E",
                Level = 1,
                DisplayOrder = 4,
                ColSpan = ((numVisibleCols - 3) - (numVisibleCols - 3)/2)/3
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Level1HeaderC",
                HeaderIsVisible = true,
                Text = "Level 1 Header F",
                Level = 1,
                DisplayOrder = 5,
                ColSpan =
                    (((numVisibleCols - 3) - (numVisibleCols - 3)/2) -
                     (((numVisibleCols - 3) - (numVisibleCols - 3)/2)/3)*2)
            };
            grid.ColumnHeaders.Add(colHeader);

            //Hidden Col Headers
            colHeader = new ColumnVm
            {
                ColCode = "RowText",
                HeaderIsVisible = false,
                Type = "text",
                Width = "200px",
                Text = "RowText",
                Level = 0,
                DisplayOrder = -4,
                ColSpan = 1
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "PostIt",
                HeaderIsVisible = false,
                Type = "postit",
                Width = "32px",
                Text = "PostIt",
                Level = 0,
                DisplayOrder = -3,
                ColSpan = 1
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "Narrative",
                HeaderIsVisible = false,
                Type = "narrative",
                Width = "32px",
                Text = "PostIt",
                Level = 0,
                DisplayOrder = -2,
                ColSpan = 1
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "DoubleOne",
                HeaderIsVisible = true,
                Type = "text",
                Width = "200px",
                Text = "Double Cell Header",
                Level = 0,
                DisplayOrder = -1,
                ColSpan = 1
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "DoubleTwo",
                HeaderIsVisible = true,
                Type = "text",
                Width = "200px",
                Text = "Double Cell Header",
                Level = 0,
                DisplayOrder = 0,
                ColSpan = 1
            };
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm
            {
                ColCode = "DropDown",
                HeaderIsVisible = true,
                Type = "dropdown",
                Width = "200px",
                Text = "DropDown Header",
                Level = 0,
                DisplayOrder = 1,
                ColSpan = 1
            };
            grid.ColumnHeaders.Add(colHeader);

            for (int col = 0; col < numCols - 6; col++)
            {
                colHeader = new ColumnVm
                {
                    ColCode = "Col_" + col,
                    HeaderIsVisible = !hiddenCols.Contains(col),
                    IsHidden = hiddenCols.Contains(col),
                    Type = "numeric",
                    Width = "125px",
                    Text = "Level 0 Header " + Convert.ToChar(col + 65),
                    Level = 0,
                    DisplayOrder = col + 10,
                    ColSpan = 1
                };
                grid.ColumnHeaders.Add(colHeader);
            }
            
            //Add Rows
            grid.DataRows = new List<RowVm>
            {
                CreateSubHeaderRowMockGrid(0, 0),
                CreateDataRowMockGrid(1, 50, false, false, false, false, 0, new int[0]), //total row
                CreateDataRowMockGrid(2, 2, true, true, true, false, 0, new[]{3, 4, 5, 6}), //parent a
                CreateDataRowMockGrid(3, 3, false, false, false, true, 1, new int[0]), //child of a
                CreateDataRowMockGrid(4, 4, false, false, false, true, 1, new int[0]), //child of a
                CreateDataRowMockGrid(5, 5, false, false, false, true, 1, new int[0]), //child of a
                CreateDataRowMockGrid(6, 6, false, false, false, true, 1, new int[0]), //child of a
                CreateSubHeaderRowMockGrid(7, 7),
                CreateDataRowMockGrid(8, 8, true, true, true, false, 0, new[]{9, 10, 11, 12}), //parent b
                CreateDataRowMockGrid(9, 9, false, false, false, true, 1, new int[0]), //child of b
                CreateDataRowMockGrid(10, 10, false, false, false, true, 1, new int[0]), //child of b
                CreateDataRowMockGrid(11, 11, false, false, false, true, 1, new int[0]), //child of b
                CreateDataRowMockGrid(12, 12, false, false, false, true, 1, new int[0]), //child of b
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
            foreach (var row in grid.DataRows)
            {
                for (int i = 2; i <= row.Cells.Count - 6; i += 3){

                    var prevPrevCellVal = row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + (i - 2)).Value;
                    var prevCellVal = row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + (i - 1)).Value;
                    row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + i).Value = prevPrevCellVal + prevCellVal;

                }
            }

            var totalRowVm = grid.DataRows.FirstOrDefault(r => r.RowCode == "Row_" + totalRow);

            if (totalRowVm != null)
                foreach(var cell in totalRowVm.Cells.Where(c => c.ColCode.Substring(0, 3) == "Col"  ))
                {
                    var sum = (from row in grid.DataRows.Where(r => r.RowCode != totalRowVm.RowCode) 
                        let cl = row.Cells.FirstOrDefault(c => c.ColCode == cell.ColCode) 
                        where cl != null 
                        select cl.Value).Sum();
                    cell.Value = sum;

                }
            #endregion
            #region derive grid attribs
            grid.NumColumns = 0;
            if (grid.DataRows.Any(r => r.CanCollapse))
            {
                grid.HasCollapseColumn = true;
                grid.NumColumns++;
            }
            if (grid.DataRows.Any(r => r.CanSelect))
            {
                grid.HasSelectColumn = true;
                grid.NumColumns++;
            }
            if (grid.DataRows.Any(r => r.CanAdd))
            {
                grid.HasAddColumn = true;
                grid.NumColumns++;
            }
            if (grid.DataRows.Any(r => r.CanDelete))
            {
                grid.HasDeleteColumn = true;
                grid.NumColumns++;
            }
            grid.NumColumns += numVisibleCols;
            #endregion
            return grid;
        }
        
        private RowVm CreateSubHeaderRowMockGrid(int r, int order)
        {
            var subHeaderRow = new RowVm
            {
                GridCode = MOCKGRID,
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
                GridCode = MOCKGRID,
                RowCode = subHeaderRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Text = "Sub Header Text",
                ColSpan = numVisibleCols + 4,
                IsHidden = false,
                IsBlank = false
            };
            subHeaderRow.Cells.Add(rowText);
            
            return subHeaderRow;
        }

        private RowVm CreateDataRowMockGrid(int r, int order, bool canCollapse, bool canSelect, bool canAdd, bool canDelete, int indent, int[] collapseChildren)
        {
            var dataRow = new RowVm
            {
                GridCode = MOCKGRID,
                RowCode = "Row_" + r,
                DisplayOrder = order,
                Class = r == totalRow ? "total-row" : "data-row",
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
            
            var rowText = new CellVm
            {
                GridCode = MOCKGRID,
                RowCode = dataRow.RowCode,
                ColCode = "RowText",
                IsEditable = false,
                Text = r == totalRow ? "Total Row" : "Row Text " + r,
                Indent = indent,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(rowText);

            var postitCell = new CellVm
            {
                GridCode = MOCKGRID,
                RowCode = dataRow.RowCode,
                ColCode = "PostIt",
                IsEditable = true,
                HasPostIt = false,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(postitCell);

            var narrCell = new CellVm
            {
                GridCode = MOCKGRID,
                RowCode = dataRow.RowCode,
                ColCode = "Narrative",
                IsEditable = true,
                HasNarrative = false,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(narrCell);

            rowText = new CellVm
            {
                GridCode = MOCKGRID,
                RowCode = dataRow.RowCode,
                ColCode = "DoubleOne",
                IsEditable = true,
                Text = r%2 == 0 ? "Double Span Text" : "Single Span Text",
                Indent = 0,
                ColSpan = r%2 == 0 ? 2 : 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(rowText);
            rowText = new CellVm
            {
                GridCode = MOCKGRID,
                RowCode = dataRow.RowCode,
                ColCode = "DoubleTwo",
                IsEditable = true,
                Text = "Single Span Text",
                Indent = 0,
                ColSpan = r%2 == 0 ? 0 : 1,
                IsHidden = false,
                IsBlank = false
            };
            dataRow.Cells.Add(rowText);
            rowText = new CellVm
            {
                GridCode = MOCKGRID,
                RowCode = dataRow.RowCode,
                ColCode = "DropDown",
                IsEditable = r%5 != 0,
                Text = " ",
                Indent = 0,
                ColSpan = 1,
                IsHidden = false,
                IsBlank = r == totalRow
            };
            dataRow.Cells.Add(rowText);

            for (var c = 0; c < numCols - 5; c++)
            {
                var cell = new CellVm
                {
                    GridCode = MOCKGRID,
                    RowCode = dataRow.RowCode,
                    ColCode = "Col_" + c,
                    Class = "data-cell",
                    ColSpan = 1,
                    Value = 5*c,
                    IsEditable = c%3 != 2 && r != totalRow,
                    IsHidden = hiddenCols.Contains(c),
                    IsBlank = r%5 == 0 && c == 0 ? true : false
                };
                dataRow.Cells.Add(cell);
            }
            return dataRow;
        }
        #endregion
        
        #region MiniOp5
        private GridVm GetMiniOp5Vm()
        {
            var grid = new GridVm();
            grid.GridCode = "MiniOp5";
            grid.GridName = "SAG 122";
            grid.ColumnHeaders = new List<ColumnVm>();

            #region Headers
            //Top level headers
            var colHeader = new ColumnVm();
            colHeader.ColCode = "Op5Header";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "OP-5";
            colHeader.Level = 1;
            colHeader.DisplayOrder = 0;
            colHeader.ColSpan = 7;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm();
            colHeader.ColCode = "Op32Header";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "OP-32";
            colHeader.Level = 1;
            colHeader.DisplayOrder = 1;
            colHeader.ColSpan = 19;
            grid.ColumnHeaders.Add(colHeader);

            //Level 0 headers under OP-5
            colHeader = new ColumnVm();
            colHeader.ColCode = "RowText";
            colHeader.HeaderIsVisible = false;
            colHeader.IsHidden = false;
            colHeader.Type = "text";
            colHeader.Width = "225px";
            colHeader.Text = "row text";
            colHeader.Level = 0;
            colHeader.DisplayOrder = -2;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm();
            colHeader.ColCode = "Description";
            colHeader.HeaderIsVisible = false;
            colHeader.IsHidden = false;
            colHeader.Type = "text";
            colHeader.Width = "300px";
            colHeader.Text = "Desc";
            colHeader.Level = 0;
            colHeader.DisplayOrder = -1;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm();
            colHeader.ColCode = "CyBaseline";
            colHeader.HeaderIsVisible = true;
            colHeader.IsHidden = false;
            colHeader.Type = "numeric";
            colHeader.Width = "125px";
            colHeader.Text = "FY 2016 Baseline";
            colHeader.Level = 0;
            colHeader.DisplayOrder = 0;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm();
            colHeader.ColCode = "StubAmt";
            colHeader.HeaderIsVisible = true;
            colHeader.IsHidden = false;
            colHeader.Type = "numeric";
            colHeader.Width = "125px";
            colHeader.Text = "Stub Amount";
            colHeader.Level = 0;
            colHeader.DisplayOrder = 1;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm();
            colHeader.ColCode = "BY1Prog";
            colHeader.HeaderIsVisible = true;
            colHeader.IsHidden = false;
            colHeader.Type = "numeric";
            colHeader.Width = "125px";
            colHeader.Text = "FY 2017 Program";
            colHeader.Level = 0;
            colHeader.DisplayOrder = 2;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm();
            colHeader.ColCode = "Mdep";
            colHeader.HeaderIsVisible = true;
            colHeader.IsHidden = false;
            colHeader.Type = "text";
            colHeader.Width = "75px";
            colHeader.Text = "MDEP";
            colHeader.Level = 0;
            colHeader.DisplayOrder = 3;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm();
            colHeader.ColCode = "Ape";
            colHeader.HeaderIsVisible = true;
            colHeader.IsHidden = false;
            colHeader.Type = "text";
            colHeader.Width = "75px";
            colHeader.Text = "APE";
            colHeader.Level = 0;
            colHeader.DisplayOrder = 4;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm();
            colHeader.ColCode = "Cmd";
            colHeader.HeaderIsVisible = true;
            colHeader.IsHidden = false;
            colHeader.Type = "text";
            colHeader.Width = "75px";
            colHeader.Text = "CMD";
            colHeader.Level = 0;
            colHeader.DisplayOrder = 5;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnVm();
            colHeader.ColCode = "Ftes";
            colHeader.HeaderIsVisible = true;
            colHeader.IsHidden = false;
            colHeader.Type = "numeric";
            colHeader.Width = "75px";
            colHeader.Text = "FTEs";
            colHeader.Level = 0;
            colHeader.DisplayOrder = 6;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);

            //Level 0 headers under OP-32
            grid.ColumnHeaders.Add(getOp32ColHeader("Op32Total", 7));
            grid.ColumnHeaders.Add(getOp32ColHeader("0101", 8));
            grid.ColumnHeaders.Add(getOp32ColHeader("0103", 9));
            grid.ColumnHeaders.Add(getOp32ColHeader("0104", 10));
            grid.ColumnHeaders.Add(getOp32ColHeader("0105", 11));
            grid.ColumnHeaders.Add(getOp32ColHeader("0106", 12));
            grid.ColumnHeaders.Add(getOp32ColHeader("0107", 13));
            grid.ColumnHeaders.Add(getOp32ColHeader("0110", 14));
            grid.ColumnHeaders.Add(getOp32ColHeader("0111", 15));
            grid.ColumnHeaders.Add(getOp32ColHeader("0308", 16));
            grid.ColumnHeaders.Add(getOp32ColHeader("0401", 17));
            grid.ColumnHeaders.Add(getOp32ColHeader("0402", 18));
            grid.ColumnHeaders.Add(getOp32ColHeader("0411", 19));
            grid.ColumnHeaders.Add(getOp32ColHeader("0412", 20));
            grid.ColumnHeaders.Add(getOp32ColHeader("0414", 21));
            grid.ColumnHeaders.Add(getOp32ColHeader("0416", 22));
            grid.ColumnHeaders.Add(getOp32ColHeader("0417", 23));
            grid.ColumnHeaders.Add(getOp32ColHeader("0422", 24));
            grid.ColumnHeaders.Add(getOp32ColHeader("0423", 25));
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


            grid.HasCollapseColumn = false;
            grid.HasSelectColumn = false;
            grid.HasAddColumn = false;
            grid.HasDeleteColumn = false;
            grid.NumColumns = grid.ColumnHeaders.Count(h => h.Level == 0 && !h.IsHidden);
            return grid;
        }

        private ColumnVm getOp32ColHeader(string colCode, int order)
        {
            var colHeader = new ColumnVm
            {
                ColCode = colCode,
                HeaderIsVisible = true,
                IsHidden = false,
                Type = "numeric",
                Width = "100px",
                Text = colCode,
                Level = 0,
                DisplayOrder = order,
                ColSpan = 1
            };
            return colHeader;
        }

        private void AddSubHeader1(GridVm grid)
        {
            //First Sub Header for grouping 1
            var subHeaderRow = new RowVm();
            subHeaderRow.RowCode = "2017TransferInTitle";
            subHeaderRow.Class = "sub-header-row";
            subHeaderRow.CanCollapse = false;
            subHeaderRow.CanSelect = false;
            subHeaderRow.IsSelected = false;
            subHeaderRow.CanAdd = false;
            subHeaderRow.CanDelete = false;
            subHeaderRow.IsHidden = false;

            subHeaderRow.Cells = new List<CellVm>();

            var rowText = new CellVm();
            rowText.GridCode = grid.GridCode;
            rowText.RowCode = subHeaderRow.RowCode;
            rowText.ColCode = "RowText";
            rowText.IsEditable = false;
            rowText.Text = "FY 2017 Transfer-in Title";
            rowText.ColSpan = grid.ColumnHeaders.Where(ch => ch.Level == 0).Count();
            rowText.IsHidden = false;
            rowText.IsBlank = false;
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddTotalRowSub1(GridVm grid)
        {
            var dataRow = new RowVm();
            dataRow.RowCode = "Total_Row_Sub_1";
            dataRow.Class = "grand-total-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "Total";
            cell.Indent = 0;
            cell.ColSpan = 2;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 0;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
            var subHeaderRow = new RowVm();
            subHeaderRow.RowCode = rowCode;
            subHeaderRow.Class = "blank-row";
            subHeaderRow.CanCollapse = false;
            subHeaderRow.CanSelect = false;
            subHeaderRow.IsSelected = false;
            subHeaderRow.CanAdd = false;
            subHeaderRow.CanDelete = false;
            subHeaderRow.IsHidden = false;

            subHeaderRow.Cells = new List<CellVm>();

            var rowText = new CellVm();
            rowText.GridCode = grid.GridCode;
            rowText.RowCode = subHeaderRow.RowCode;
            rowText.ColCode = "blank_1";
            rowText.IsEditable = false;
            rowText.Text = "";
            rowText.ColSpan = grid.ColumnHeaders.Count(ch => ch.Level == 0);
            rowText.IsHidden = false;
            rowText.IsBlank = true;
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddSubHeader2(GridVm grid)
        {
            //First Sub Header for grouping 1
            var subHeaderRow = new RowVm();
            subHeaderRow.RowCode = "2017TransferOutTitle";
            subHeaderRow.Class = "sub-header-row";
            subHeaderRow.CanCollapse = false;
            subHeaderRow.CanSelect = false;
            subHeaderRow.IsSelected = false;
            subHeaderRow.CanAdd = false;
            subHeaderRow.CanDelete = false;
            subHeaderRow.IsHidden = false;

            subHeaderRow.Cells = new List<CellVm>();

            var rowText = new CellVm();
            rowText.GridCode = grid.GridCode;
            rowText.RowCode = subHeaderRow.RowCode;
            rowText.ColCode = "RowText";
            rowText.IsEditable = false;
            rowText.Text = "FY 2017 Transfer-Out Title";
            rowText.ColSpan = grid.ColumnHeaders.Count(ch => ch.Level == 0);
            rowText.IsHidden = false;
            rowText.IsBlank = true;
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddTotalRowSub2(GridVm grid)
        {
            var dataRow = new RowVm();
            dataRow.RowCode = "Total_Row_Sub_2";
            dataRow.Class = "grand-total-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "Total";
            cell.Indent = 0;
            cell.ColSpan = 2;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 0;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
            var subHeaderRow = new RowVm();
            subHeaderRow.RowCode = "2017ProgGrowth";
            subHeaderRow.Class = "sub-header-row";
            subHeaderRow.CanCollapse = false;
            subHeaderRow.CanSelect = false;
            subHeaderRow.IsSelected = false;
            subHeaderRow.CanAdd = false;
            subHeaderRow.CanDelete = false;
            subHeaderRow.IsHidden = false;

            subHeaderRow.Cells = new List<CellVm>();

            var rowText = new CellVm();
            rowText.GridCode = grid.GridCode;
            rowText.RowCode = subHeaderRow.RowCode;
            rowText.ColCode = "RowText";
            rowText.IsEditable = false;
            rowText.Text = "FY 2017 Program Growth Title";
            rowText.ColSpan = grid.ColumnHeaders.Where(ch => ch.Level == 0).Count();
            rowText.IsHidden = false;
            rowText.IsBlank = false;
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddRow1Sub3(GridVm grid)
        {
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_1_Sub_3";
            dataRow.Class = "total-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "Tactical Exploitation of National Capabilities (TENCAP) Military Exploitation of Reconnaissance and Intelligence Technology (MERIT)  Projects";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "Provides operational support and below depot-level maintenance of classified, low-density tactical intelligence software and equipment performed or managed at the National Level by either in-house or joint national contractor activities provided by TENCAP MERIT Projects. Provides for the sustainment of these national capabilities until fully transitioned into an Army Program of Record.Includes operations and maintenance of software and equipment, necessary facilities, and the associated costs specifically identified and measurable to these units.";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 2044;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = true;
            cell.Value = 2044;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_1_Child_1_Sub_3";
            dataRow.Class = "data-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 2044;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 2044;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "FPDP";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "122011";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "5D0";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_2_Sub_3";
            dataRow.Class = "total-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "Combat Support Medical";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "Increases funding for the U.S. Army Medical Command's Medical Combat Support Program. Medical Equipment Sets(MES) include state of the art initial trauma resuscitation equipment and are fielded to units and medical personnel that treat from the point of injury through the combat support hospitals levels of care.  MES may consist of ambulatory care, dental, environmental, laboratory/ blood gas, therapy / treatment, testing measurement diagnostic equipment, veterinary, and x - ray sets.Funding will fill equipment shortages or upgrade outdated equipment in approximately approximately 1,000 MESes throughout the Army. POC: Ben Ervin";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 38686;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 10430;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = true;
            cell.Value = 49116;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_2_Child_1_Sub_3";
            dataRow.Class = "data-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 38686;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 10430;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 49116;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "FL8D";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "122011";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "740";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Total_Row_Sub_3";
            dataRow.Class = "grand-total-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "Total";
            cell.Indent = 0;
            cell.ColSpan = 2;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 0;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 38686;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 12474;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 51160;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
            var subHeaderRow = new RowVm();
            subHeaderRow.RowCode = "2017ProgDecre";
            subHeaderRow.Class = "sub-header-row";
            subHeaderRow.CanCollapse = false;
            subHeaderRow.CanSelect = false;
            subHeaderRow.IsSelected = false;
            subHeaderRow.CanAdd = false;
            subHeaderRow.CanDelete = false;
            subHeaderRow.IsHidden = false;

            subHeaderRow.Cells = new List<CellVm>();

            var rowText = new CellVm();
            rowText.GridCode = grid.GridCode;
            rowText.RowCode = subHeaderRow.RowCode;
            rowText.ColCode = "RowText";
            rowText.IsEditable = false;
            rowText.Text = "FY 2017 Program Decreases Title";
            rowText.ColSpan = grid.ColumnHeaders.Where(ch => ch.Level == 0).Count();
            rowText.IsHidden = false;
            rowText.IsBlank = false;
            subHeaderRow.Cells.Add(rowText);

            grid.DataRows.Add(subHeaderRow);
        }

        private void AddRow1Sub4(GridVm grid)
        {
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_1_Sub_4";
            dataRow.Class = "total-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "Civilian Workforce Reduction";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "Reduces funding and 29 FTEs to shape the civilian workforce commensurate with force structure levels.";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 172380;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = -3996;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = true;
            cell.Value = 168384;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_1_Child_1_Sub_4";
            dataRow.Class = "data-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 50000;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 50000;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "HSMR";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "122018";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "740";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = -2;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_1_Child_2_Sub_4";
            dataRow.Class = "data-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 50000;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 50000;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "VTRD";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "122018";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "570";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = -26;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_1_Child_3_Sub_4";
            dataRow.Class = "data-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 72308;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = -3996;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 68384;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "WSCC";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "122152";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "890";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = -2;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_2_Sub_4";
            dataRow.Class = "total-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "Army Service Component Command Tactical Units";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "One-time decrease in funding to address civilian pay affordability in U.S. Army Europe.";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 19708;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = -2511;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = true;
            cell.Value = 17197;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_2_Child_1_Sub_4";
            dataRow.Class = "data-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 19708;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = -2511;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 17197;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "WSCC";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "122152";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "740";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 0;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
            var dataRow = new RowVm();
            dataRow.RowCode = "Total_Row_Sub_4";
            dataRow.Class = "grand-total-row";
            dataRow.CanCollapse = false;
            dataRow.CanSelect = false;
            dataRow.IsSelected = false;
            dataRow.CanAdd = false;
            dataRow.CanDelete = false;
            dataRow.IsHidden = false;
            dataRow.Cells = new List<CellVm>();
            var cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "RowText";
            cell.IsEditable = false;
            cell.Text = "Total";
            cell.Indent = 0;
            cell.ColSpan = 2;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Description";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 0;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "CyBaseline";
            cell.IsEditable = false;
            cell.Value = 192088;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "StubAmt";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = -6507;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "BY1Prog";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = 185581;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Mdep";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ape";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Cmd";
            cell.Class = "text-cell";
            cell.IsEditable = false;
            cell.Text = "";
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = true;
            dataRow.Cells.Add(cell);
            cell = new CellVm();
            cell.GridCode = grid.GridCode;
            cell.RowCode = dataRow.RowCode;
            cell.ColCode = "Ftes";
            cell.Class = "data-cell";
            cell.IsEditable = false;
            cell.Value = -30;
            cell.Indent = 0;
            cell.ColSpan = 1;
            cell.IsHidden = false;
            cell.IsBlank = false;
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
                Value = 0,
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