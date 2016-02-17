using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExhibitGrid.ViewModel;

namespace ExhibitGrid.Processes
{
    public class GridVmFactory
    {
        public static GridVm GetGridVm(string gridCode)
        {
            switch (gridCode)
            {
                case "mock":
                    return GetMockGridVm();
                default:
                    return null;
            }
        }

        public static ViewModel.v2.GridVm GetGridVmV2(string gridCode)
        {
            switch (gridCode)
            {
                case "mock":
                    return GetMockGridVmV2();
                default:
                    return null;
            }
        }



        private static GridVm GetMockGridVm()
        {
            var numRows = 16;
            var numVisibleCols = 17;

            
            var grid = new GridVm();
            grid.GridCode = "MockGrid";

            var subHeaderRow = new RowVm();
            subHeaderRow.RowCode = "Row_0";
            subHeaderRow.ParentRowCodes = null;
            subHeaderRow.Class = "header-row";
            subHeaderRow.Text = "Header Text";

            var selectCell = new SelectionCellVm();
            selectCell.IncludeSpaceForCell = true;
            selectCell.AllowSelect = false;
            selectCell.IsSelected = false;
            subHeaderRow.SelectionCell = selectCell;

            var crudCell = new CrudCellVm();
            crudCell.IncludeSpaceForCell = true;
            crudCell.CrudFunctionality = "no-crud";
            subHeaderRow.CrudCell = crudCell;

            var narrCell = new NarrativeCellVm();
            narrCell.IncludeSpaceForCell = true;
            narrCell.AllowNarrative = false;
            narrCell.HasNarrative = false;
            subHeaderRow.NarrativeCell = narrCell;

            var postItCell = new PostItCellVm();
            postItCell.IncludeSpaceForCell = true;
            postItCell.AllowPostIt = false;
            postItCell.HasPostIt = false;
            subHeaderRow.PostItCell = postItCell;

            subHeaderRow.DataCells = new List<DataCellVm>();
            for (var c = 0; c <= numVisibleCols; c++)
            {
                var cell = new DataCellVm();
                cell.RowCode = subHeaderRow.RowCode;
                cell.ColCode = "Col_" + c;
                cell.Class = "header-cell";
                cell.Type = "read-only";
                cell.Value = "Column " + c;
                cell.Width = "1x";
                cell.IsEditable = false;

                subHeaderRow.DataCells.Add(cell);
            }

            grid.Rows = new List<RowVm>() { subHeaderRow };

            for (var r = 1; r <= numRows; r++)
            {
                var dataRow = new RowVm();
                dataRow.RowCode = "Row_" + r;
                dataRow.ParentRowCodes = null;
                dataRow.Class = "data-row";
                dataRow.Text = "Row Text " + r;

                selectCell = new SelectionCellVm();
                selectCell.IncludeSpaceForCell = true;
                selectCell.AllowSelect = true;
                selectCell.IsSelected = false;
                dataRow.SelectionCell = selectCell;

                crudCell = new CrudCellVm();
                crudCell.IncludeSpaceForCell = true;
                crudCell.CrudFunctionality = "create";
                dataRow.CrudCell = crudCell;

                narrCell = new NarrativeCellVm();
                narrCell.IncludeSpaceForCell = true;
                narrCell.AllowNarrative = true;
                narrCell.HasNarrative = false;
                dataRow.NarrativeCell = narrCell;

                postItCell = new PostItCellVm();
                postItCell.IncludeSpaceForCell = true;
                postItCell.AllowPostIt = true;
                postItCell.HasPostIt = false;
                dataRow.PostItCell = postItCell;

                dataRow.DataCells = new List<DataCellVm>();

                for (var c = 0; c <= numVisibleCols; c++)
                {
                    var cell = new DataCellVm();
                    cell.RowCode = dataRow.RowCode;
                    cell.ColCode = "Col_" + c;
                    cell.Class = "data-cell";
                    cell.Type = "num-input";
                    cell.Value = 5 * c;
                    cell.Width = "1x";
                    cell.IsEditable = true;

                    dataRow.DataCells.Add(cell);
                }

                grid.Rows.Add(dataRow);
            }

            return grid;
        }


        private static ViewModel.v2.GridVm GetMockGridVmV2()
        {
            var numRows = 25;
            var numCols = 21;
            var totalRow = 1; // value of 1 means Row_1 is set as the total row
            var hiddenCols = new int[3] { 3, 4, 5 };
            var numVisibleCols = numCols - hiddenCols.Count(); 


            var rando = new Random();
            
            var grid = new ViewModel.v2.GridVm();
            grid.GridCode = "MockGrid";
            grid.GridName = "Grid Name";

            //Add Column headers to list
            grid.ColumnHeaders = new List<ViewModel.v2.ColumnHeaderVm>();

            var colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level3Header";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 3 Header";
            colHeader.Level = 3;
            colHeader.Order = 0;
            colHeader.ColSpan = numVisibleCols - 3;
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level2HeaderA";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 2 Header A";
            colHeader.Level = 2;
            colHeader.Order = 0;
            colHeader.ColSpan = (numVisibleCols - 3)/2;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level2HeaderB";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 2 Header B";
            colHeader.Level = 2;
            colHeader.Order = 1;
            colHeader.ColSpan = ((numVisibleCols - 3) - (numVisibleCols - 3) / 2);
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderA";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header A";
            colHeader.Level = 1;
            colHeader.Order = 0;
            colHeader.ColSpan = ((numVisibleCols - 3) / 2 ) / 3;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderB";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header B";
            colHeader.Level = 1;
            colHeader.Order = 1;
            colHeader.ColSpan = ((numVisibleCols - 3) / 2) / 3;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderC";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header C";
            colHeader.Level = 1;
            colHeader.Order = 2;
            colHeader.ColSpan = ((numVisibleCols - 3) / 2) - ((((numVisibleCols - 3) / 2) / 3) * 2);
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderA";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header D";
            colHeader.Level = 1;
            colHeader.Order = 3;
            colHeader.ColSpan = ((numVisibleCols - 3) - (numVisibleCols - 3) / 2) / 3;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderB";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header E";
            colHeader.Level = 1;
            colHeader.Order = 4;
            colHeader.ColSpan = ((numVisibleCols - 3) - (numVisibleCols - 3) / 2) / 3;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderC";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header F";
            colHeader.Level = 1;
            colHeader.Order = 5;
            colHeader.ColSpan = (((numVisibleCols - 3) - (numVisibleCols - 3) / 2) - (((numVisibleCols - 3) - (numVisibleCols - 3) / 2) / 3) * 2);
            grid.ColumnHeaders.Add(colHeader);

            //Hidden Col Headers
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "RowText";
            colHeader.HeaderIsVisible = false;
            colHeader.Width = "200px";
            colHeader.Text = "RowText";
            colHeader.Level = 0;
            colHeader.Order = -2;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "PostIt";
            colHeader.HeaderIsVisible = false;
            colHeader.Width = "32px";
            colHeader.Text = "PostIt";
            colHeader.Level = 0;
            colHeader.Order = -1;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Narrative";
            colHeader.HeaderIsVisible = false;
            colHeader.Width = "32px";
            colHeader.Text = "PostIt";
            colHeader.Level = 0;
            colHeader.Order = 0;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);


            for(int col = 0; col < numCols - 3; col++)
            {
                if (!hiddenCols.Contains(col))
                {
                    colHeader = new ViewModel.v2.ColumnHeaderVm();
                    colHeader.ColCode = "Col_" + col;
                    colHeader.HeaderIsVisible = true;
                    colHeader.Width = "100px";
                    colHeader.Text = "Level 0 Header " + Convert.ToChar(col + 65);
                    colHeader.Level = 0;
                    colHeader.Order = col + 1;
                    colHeader.ColSpan = 1;
                    grid.ColumnHeaders.Add(colHeader);
                }
            }
                        
            var subHeaderRow = new ViewModel.v2.RowVm();
            subHeaderRow.RowCode = "Row_0";
            subHeaderRow.Class = "header-row";
            subHeaderRow.Text = "Header Text";
            subHeaderRow.CanCollapse = false;
            subHeaderRow.CanSelect = false;
            subHeaderRow.IsSelected = false;
            subHeaderRow.CanAdd = false;
            subHeaderRow.CanDelete = false;
            subHeaderRow.IsHidden = false;

            subHeaderRow.Cells = new List<ViewModel.v2.CellVm>();

            var rowText = new ViewModel.v2.CellVm();
            rowText.Order = 2;
            rowText.RowCode = subHeaderRow.RowCode;
            rowText.ColCode = "RowText";
            rowText.IsEditable = false;
            rowText.Text = "";
            rowText.Directive = "text-cell";
            rowText.IsHidden = false;
            subHeaderRow.Cells.Add(rowText);

            var postitCell = new ViewModel.v2.CellVm();
            postitCell.Order = 3;
            postitCell.IsEditable = false;
            postitCell.HasPostIt = false;
            postitCell.RowCode = subHeaderRow.RowCode;
            postitCell.ColCode = "PostIt";
            postitCell.Directive = "postit-cell";
            rowText.IsHidden = false;
            subHeaderRow.Cells.Add(postitCell);

            var narrCell = new ViewModel.v2.CellVm();
            narrCell.Order = 4;
            narrCell.IsEditable = false;
            narrCell.HasNarrative = false;
            narrCell.RowCode = subHeaderRow.RowCode;
            narrCell.ColCode = "Narrative";
            narrCell.Directive = "narrative-cell";
            rowText.IsHidden = false;
            subHeaderRow.Cells.Add(narrCell);

            for (var c = 0; c < numVisibleCols - 3; c++)
            {
                var cell = new ViewModel.v2.CellVm();
                cell.RowCode = subHeaderRow.RowCode;
                cell.ColCode = "Col_" + c;
                cell.Class = "header-cell";
                cell.Value = 0;
                cell.IsEditable = false;
                cell.Order = 5 + c;
                cell.Directive = "numeric-cell";
                rowText.IsHidden = hiddenCols.Contains(c);
                subHeaderRow.Cells.Add(cell);
            }

            grid.DataRows = new List<ViewModel.v2.RowVm>() { subHeaderRow };

            for (var r = 1; r <= numRows; r++)
            {
                var dataRow = new ViewModel.v2.RowVm();
                dataRow.RowCode = "Row_" + r;
                dataRow.Class = "data-row";
                dataRow.Text = "Row Text " + r;
                dataRow.CanCollapse = r % 2 == 0;
                dataRow.CanSelect = r % 3 == 0;
                dataRow.IsSelected = false;
                dataRow.CanAdd = r % 4 == 0;
                dataRow.CanDelete = r % 5 == 0;
                dataRow.IsHidden = r % 6 == 0 ;

                dataRow.Cells = new List<ViewModel.v2.CellVm>();

                rowText = new ViewModel.v2.CellVm();
                rowText.Order = 2;
                rowText.RowCode = dataRow.RowCode;
                rowText.ColCode = "RowText";
                rowText.IsEditable = false;
                rowText.Text = "Row Text " + r;
                rowText.Indent = r % 4;
                rowText.Directive = "text-cell";
                rowText.IsHidden = false;
                dataRow.Cells.Add(rowText);

                postitCell = new ViewModel.v2.CellVm();
                postitCell.Order = 3;
                postitCell.IsEditable = true;
                postitCell.HasPostIt = false;
                postitCell.RowCode = dataRow.RowCode;
                postitCell.ColCode = "PostIt";
                postitCell.Directive = "postit-cell";
                rowText.IsHidden = false;
                dataRow.Cells.Add(postitCell);

                narrCell = new ViewModel.v2.CellVm();
                narrCell.Order = 4;
                narrCell.IsEditable = true;
                narrCell.HasNarrative = false;
                narrCell.RowCode = dataRow.RowCode;
                narrCell.ColCode = "Narrative";
                narrCell.Directive = "narrative-cell";
                rowText.IsHidden = false;
                dataRow.Cells.Add(narrCell);

                for (var c = 0; c < numVisibleCols -3; c++)
                {
                    var cell = new ViewModel.v2.CellVm();
                    cell.RowCode = dataRow.RowCode;
                    cell.ColCode = "Col_" + c;
                    cell.Class = "data-cell";
                    cell.Value = c == 2 ? dataRow.Cells.FirstOrDefault(x => x.ColCode == "Col_0").Value : 5 * c;
                    cell.IsEditable = c % 3 != 2 && r != totalRow;
                    cell.Order = 5 + c;
                    cell.Directive = "numeric-cell";
                    cell.IsHidden = hiddenCols.Contains(c);
                    dataRow.Cells.Add(cell);
                }
                dataRow.Cells = dataRow.Cells.OrderBy(c => c.Order).ToList();
                grid.DataRows.Add(dataRow);

            }
            
            foreach(var row in grid.DataRows)
            {
                for (int i = 2; i <= row.Cells.Count - 3; i += 3){
                    var prevPrevCellVal = row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + (i - 2)).Value;
                    var prevCellVal = row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + (i - 1)).Value;
                    row.Cells.FirstOrDefault(c => c.ColCode == "Col_" + i).Value = prevPrevCellVal + prevCellVal;
                }
            }

            var totalRowVm = grid.DataRows.FirstOrDefault(r => r.RowCode == "Row_" + totalRow);

            foreach(var cell in totalRowVm.Cells.Where(c => c.ColCode.Substring(0, 3) == "Col"  ))
            {
                double sum = 0;
                foreach(var row in grid.DataRows.Where(r => r.RowCode != totalRowVm.RowCode)){
                    sum += row.Cells.FirstOrDefault(c => c.ColCode == cell.ColCode).Value;
                }
                cell.Value = sum;

            }

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
            return grid;
        }
        
    }

}