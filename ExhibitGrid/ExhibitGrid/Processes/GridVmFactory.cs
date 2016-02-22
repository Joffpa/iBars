using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExhibitGrid.ViewModel;

namespace ExhibitGrid.Processes
{
    public class GridVmFactory
    {

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
                case "mock":
                    return GetMockGridVmV2();
                default:
                    return null;
            }
        }
        
        private GridVm GetMockGridVmV2()
        {

            var rando = new Random();
            
            var grid = new GridVm();
            grid.GridCode = "MockGrid";
            grid.GridName = "Grid Name";

            //Add Column headers to list
            grid.ColumnHeaders = new List<ColumnHeaderVm>();

            var colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Level3Header";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 3 Header";
            colHeader.Level = 3;
            colHeader.Order = 0;
            colHeader.ColSpan = numVisibleCols - 3;
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Level2HeaderA";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 2 Header A";
            colHeader.Level = 2;
            colHeader.Order = 0;
            colHeader.ColSpan = (numVisibleCols - 3)/2;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Level2HeaderB";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 2 Header B";
            colHeader.Level = 2;
            colHeader.Order = 1;
            colHeader.ColSpan = ((numVisibleCols - 3) - (numVisibleCols - 3) / 2);
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderA";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header A";
            colHeader.Level = 1;
            colHeader.Order = 0;
            colHeader.ColSpan = ((numVisibleCols - 3) / 2 ) / 3;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderB";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header B";
            colHeader.Level = 1;
            colHeader.Order = 1;
            colHeader.ColSpan = ((numVisibleCols - 3) / 2) / 3;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderC";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header C";
            colHeader.Level = 1;
            colHeader.Order = 2;
            colHeader.ColSpan = ((numVisibleCols - 3) / 2) - ((((numVisibleCols - 3) / 2) / 3) * 2);
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderA";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header D";
            colHeader.Level = 1;
            colHeader.Order = 3;
            colHeader.ColSpan = ((numVisibleCols - 3) - (numVisibleCols - 3) / 2) / 3;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderB";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header E";
            colHeader.Level = 1;
            colHeader.Order = 4;
            colHeader.ColSpan = ((numVisibleCols - 3) - (numVisibleCols - 3) / 2) / 3;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderC";
            colHeader.HeaderIsVisible = true;
            colHeader.Text = "Level 1 Header F";
            colHeader.Level = 1;
            colHeader.Order = 5;
            colHeader.ColSpan = (((numVisibleCols - 3) - (numVisibleCols - 3) / 2) - (((numVisibleCols - 3) - (numVisibleCols - 3) / 2) / 3) * 2);
            grid.ColumnHeaders.Add(colHeader);

            //Hidden Col Headers
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "RowText";
            colHeader.HeaderIsVisible = false;
            colHeader.Type = "text";
            colHeader.Width = "200px";
            colHeader.Text = "RowText";
            colHeader.Level = 0;
            colHeader.Order = -4;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "PostIt";
            colHeader.HeaderIsVisible = false;
            colHeader.Type = "postit";
            colHeader.Width = "32px";
            colHeader.Text = "PostIt";
            colHeader.Level = 0;
            colHeader.Order = -3;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "Narrative";
            colHeader.HeaderIsVisible = false;
            colHeader.Type = "narrative";
            colHeader.Width = "32px";
            colHeader.Text = "PostIt";
            colHeader.Level = 0;
            colHeader.Order = -2;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "DoubleOne";
            colHeader.HeaderIsVisible = true;
            colHeader.Type = "text";
            colHeader.Width = "200px";
            colHeader.Text = "Double Cell Header";
            colHeader.Level = 0;
            colHeader.Order = -1;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "DoubleTwo";
            colHeader.HeaderIsVisible = true;
            colHeader.Type = "text";
            colHeader.Width = "200px";
            colHeader.Text = "Double Cell Header";
            colHeader.Level = 0;
            colHeader.Order = 0;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ColumnHeaderVm();
            colHeader.ColCode = "DropDown";
            colHeader.HeaderIsVisible = true;
            colHeader.Type = "dropdown";
            colHeader.Width = "200px";
            colHeader.Text = "DropDown Header";
            colHeader.Level = 0;
            colHeader.Order = 1;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);

            for (int col = 0; col < numCols - 6; col++)
            {
                colHeader = new ColumnHeaderVm();
                colHeader.ColCode = "Col_" + col;
                colHeader.HeaderIsVisible = !hiddenCols.Contains(col);
                colHeader.IsHidden = hiddenCols.Contains(col);
                colHeader.Type = "numeric";
                colHeader.Width = "125px";
                colHeader.Text = "Level 0 Header " + Convert.ToChar(col + 65);
                colHeader.Level = 0;
                colHeader.Order = col + 10;
                colHeader.ColSpan = 1;
                grid.ColumnHeaders.Add(colHeader);
            }
            
            //Add Rows
            grid.DataRows = new List<RowVm>() { CreateSubHeaderRow(0) };

            for (var r = 1; r <= numRows; r++)
            {    
                if(r % 8 == 0)
                {
                    grid.DataRows.Add(CreateSubHeaderRow(r));
                }
                else
                {
                    grid.DataRows.Add(CreateDataRow(r));
                }         
            }
            
            
            foreach(var row in grid.DataRows)
            {
                for (int i = 2; i <= row.Cells.Count - 6; i += 3){

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
                    var cl = row.Cells.FirstOrDefault(c => c.ColCode == cell.ColCode);
                    if (cl != null)
                    {
                        sum += row.Cells.FirstOrDefault(c => c.ColCode == cell.ColCode).Value;
                    }
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

        private RowVm CreateSubHeaderRow(int r)
        {
            var subHeaderRow = new RowVm();
            subHeaderRow.RowCode = "Row_" + r;
            subHeaderRow.Class = "sub-header-row";
            subHeaderRow.Text = "Sub Header Text";
            subHeaderRow.CanCollapse = false;
            subHeaderRow.CanSelect = false;
            subHeaderRow.IsSelected = false;
            subHeaderRow.CanAdd = false;
            subHeaderRow.CanDelete = false;
            subHeaderRow.IsHidden = false;

            subHeaderRow.Cells = new List<CellVm>();

            var rowText = new CellVm();
            //rowText.Order = 2;
            rowText.RowCode = subHeaderRow.RowCode;
            rowText.ColCode = "RowText";
            rowText.IsEditable = false;
            rowText.Text = "Sub Header Text";
            //rowText.Directive = "text-cell";
            rowText.ColSpan = numVisibleCols + 4;
            rowText.IsHidden = false;
            rowText.IsBlank = false;
            subHeaderRow.Cells.Add(rowText);

            //var postitCell = new CellVm();
            ////postitCell.Order = 3;
            //postitCell.IsEditable = false;
            //postitCell.HasPostIt = false;
            //postitCell.RowCode = subHeaderRow.RowCode;
            //postitCell.ColCode = "PostIt";
            //postitCell.ColSpan = 0;
            ////postitCell.Directive = "postit-cell";
            //postitCell.IsHidden = false;
            //postitCell.IsBlank = false;
            //subHeaderRow.Cells.Add(postitCell);

            //var narrCell = new CellVm();
            ////narrCell.Order = 4;
            //narrCell.IsEditable = false;
            //narrCell.HasNarrative = false;
            //narrCell.RowCode = subHeaderRow.RowCode;
            //narrCell.ColCode = "Narrative";
            //narrCell.ColSpan = 0;
            ////narrCell.Directive = "narrative-cell";
            //narrCell.IsHidden = false;
            //narrCell.IsBlank = false;
            //subHeaderRow.Cells.Add(narrCell);


            //rowText = new CellVm();
            ////rowText.Order = 3;
            //rowText.RowCode = subHeaderRow.RowCode;
            //rowText.ColCode = "DoubleOne";
            //rowText.IsEditable = true;
            //rowText.Text = "Single Span Text";
            //rowText.Indent = 0;
            //rowText.ColSpan = 0;
            ////rowText.Directive = "text-cell";
            //rowText.IsHidden = false;
            //rowText.IsBlank = false;
            //subHeaderRow.Cells.Add(rowText);
            //rowText = new CellVm();
            ////rowText.Order = 4;
            //rowText.RowCode = subHeaderRow.RowCode;
            //rowText.ColCode = "DoubleTwo";
            //rowText.IsEditable = true;
            //rowText.Text = "Single Span Text";
            //rowText.Indent = 0;
            //rowText.ColSpan = 0;
            ////rowText.Directive = "text-cell";
            //rowText.IsHidden = false;
            //rowText.IsBlank = false;
            //subHeaderRow.Cells.Add(rowText);

            //for (var c = 0; c < numCols - 5; c++)
            //{
            //    var cell = new CellVm();
            //    cell.RowCode = subHeaderRow.RowCode;
            //    cell.ColCode = "Col_" + c;
            //    cell.ColSpan =0;
            //    cell.Class = "header-cell";
            //    cell.Value = 0;
            //    cell.IsEditable = false;
            //    //cell.Order = 5 + c;
            //    //cell.Directive = "numeric-cell";
            //    cell.IsBlank = false;
            //    cell.IsHidden = hiddenCols.Contains(c);
            //    subHeaderRow.Cells.Add(cell);
            //}

            return subHeaderRow;
        }

        private RowVm CreateDataRow(int r)
        {
            var dataRow = new RowVm();
            dataRow.RowCode = "Row_" + r;
            dataRow.Class = r == totalRow ? "total-row" : "data-row";
            dataRow.Text = r == totalRow ? "Total Row" : "Row Text " + r;
            dataRow.CanCollapse = r % 2 == 0;
            dataRow.CanSelect = r % 3 == 0;
            dataRow.IsSelected = false;
            dataRow.CanAdd = r % 4 == 0;
            dataRow.CanDelete = r % 5 == 0;
            dataRow.IsHidden = r % 6 == 0;

            dataRow.Cells = new List<CellVm>();

            var rowText = new CellVm();
            //rowText.Order = 0;
            rowText.RowCode = dataRow.RowCode;
            rowText.ColCode = "RowText";
            rowText.IsEditable = false;
            rowText.Text = r == totalRow ? "Total Row" : "Row Text " + r;
            rowText.Indent = r % 4;
            rowText.ColSpan = 1;
            //rowText.Directive = "text-cell";
            rowText.IsHidden = false;
            rowText.IsBlank = false;
            dataRow.Cells.Add(rowText);

            var postitCell = new CellVm();
            //postitCell.Order = 1;
            postitCell.IsEditable = true;
            postitCell.HasPostIt = false;
            postitCell.RowCode = dataRow.RowCode;
            postitCell.ColCode = "PostIt";
            postitCell.ColSpan = 1;
            //postitCell.Directive = "postit-cell";
            postitCell.IsHidden = false;
            postitCell.IsBlank = false;
            dataRow.Cells.Add(postitCell);

            var narrCell = new CellVm();
            //narrCell.Order = 2;
            narrCell.IsEditable = true;
            narrCell.HasNarrative = false;
            narrCell.RowCode = dataRow.RowCode;
            narrCell.ColCode = "Narrative";
            narrCell.ColSpan = 1;
            //narrCell.Directive = "narrative-cell";
            narrCell.IsHidden = false;
            narrCell.IsBlank = false;
            dataRow.Cells.Add(narrCell);

            rowText = new CellVm();
            //rowText.Order = 3;
            rowText.RowCode = dataRow.RowCode;
            rowText.ColCode = "DoubleOne";
            rowText.IsEditable = true;
            rowText.Text = r % 2 == 0 ? "Double Span Text" : "Single Span Text";
            rowText.Indent = 0;
            rowText.ColSpan = r % 2 == 0 ? 2 : 1;
            //rowText.Directive = "text-cell";
            rowText.IsHidden = false;
            rowText.IsBlank = false;
            dataRow.Cells.Add(rowText);
            rowText = new CellVm();
            //rowText.Order = 4;
            rowText.RowCode = dataRow.RowCode;
            rowText.ColCode = "DoubleTwo";
            rowText.IsEditable = true;
            rowText.Text = "Single Span Text";
            rowText.Indent = 0;
            rowText.ColSpan = r % 2 == 0 ? 0 : 1;
            //rowText.Directive = "text-cell";
            rowText.IsHidden = false;
            rowText.IsBlank = false;
            dataRow.Cells.Add(rowText);
            rowText = new CellVm();
            //rowText.Order = 4;
            rowText.RowCode = dataRow.RowCode;
            rowText.ColCode = "DropDown";
            rowText.IsEditable = r % 5 !=0;
            rowText.Text = " ";
            rowText.Indent = 0;
            rowText.ColSpan = 1;
            //rowText.Directive = "text-cell";
            rowText.IsHidden = false;
            rowText.IsBlank = r == totalRow;
            dataRow.Cells.Add(rowText);

            for (var c = 0; c < numCols - 5; c++)
            {
                var cell = new CellVm();
                cell.RowCode = dataRow.RowCode;
                cell.ColCode = "Col_" + c;
                cell.Class = "data-cell";
                cell.ColSpan = 1;
                cell.Value = 5 * c;
                cell.IsEditable = c % 3 != 2 && r != totalRow;
                //cell.Order = 5 + c;
                //cell.Directive = "numeric-cell";
                cell.IsHidden = hiddenCols.Contains(c);
                cell.IsBlank = r % 5 == 0 && c == 0 ? true : false;
                dataRow.Cells.Add(cell);
            }
            //dataRow.Cells = dataRow.Cells.OrderBy(c => c.Order).ToList();
            return dataRow;
        }

        
    }

}