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
            var numColumns = 17;

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
            for (var c = 0; c <= numColumns; c++)
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

                for (var c = 0; c <= numColumns; c++)
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
            var numRows = 16;
            var numColumns = 17;

            var grid = new ViewModel.v2.GridVm();
            grid.GridCode = "MockGrid";
            
            var headerRow = new ViewModel.v2.RowVm();


            var subHeaderRow = new ViewModel.v2.RowVm();
            subHeaderRow.RowCode = "Row_0";
            subHeaderRow.Class = "header-row";
            subHeaderRow.Text = "Header Text";
            subHeaderRow.CanCollapse = false;
            subHeaderRow.CanSelect = false;
            subHeaderRow.IsSelected = false;
            subHeaderRow.CrudFunctionality = "none";

            subHeaderRow.Cells = new List<ViewModel.v2.BaseCellVm>();

            var rowText = new ViewModel.v2.TextCellVm();
            rowText.Order = 2;
            rowText.RowCode = subHeaderRow.RowCode;
            rowText.ColCode = "RowText";
            rowText.IsEditable = false;
            rowText.Text = "";
            subHeaderRow.Cells.Add(rowText);

            var postitCell = new ViewModel.v2.PostItCellVm();
            postitCell.Order = 3;
            postitCell.CanHavePostIt = false;
            postitCell.HasPostIt = false;
            postitCell.RowCode = subHeaderRow.RowCode;
            postitCell.ColCode = "PostIt";
            subHeaderRow.Cells.Add(postitCell);

            var narrCell = new ViewModel.v2.NarrativeCellVm();
            narrCell.Order = 4;
            narrCell.CanAddNarrative = false;
            narrCell.HasNarrative = false;
            narrCell.RowCode = subHeaderRow.RowCode;
            narrCell.ColCode = "Narrative";
            subHeaderRow.Cells.Add(narrCell);

            for (var c = 0; c <= numColumns; c++)
            {
                var cell = new ViewModel.v2.DataCellVm();
                cell.RowCode = subHeaderRow.RowCode;
                cell.ColCode = "Col_" + c;
                cell.Class = "header-cell";
                cell.Value = "Column " + c;
                cell.Width = "1x";
                cell.IsEditable = false;
                cell.Order = 5 + c;
                cell.IsRenderable = true;

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
                dataRow.CrudFunctionality = r % 2 == 0 ? "create" : r% 3 == 0 ? "delete" : "none";
                
                dataRow.Cells = new List<ViewModel.v2.BaseCellVm>();

                rowText = new ViewModel.v2.TextCellVm();
                rowText.Order = 2;
                rowText.RowCode = dataRow.RowCode;
                rowText.ColCode = "RowText";
                rowText.IsEditable = false;
                rowText.Text = "Row Text " + r;
                dataRow.Cells.Add(rowText);
                rowText.IsRenderable = true;

                postitCell = new ViewModel.v2.PostItCellVm();
                postitCell.Order = 3;
                postitCell.CanHavePostIt = false;
                postitCell.HasPostIt = false;
                postitCell.RowCode = dataRow.RowCode;
                postitCell.ColCode = "PostIt";
                dataRow.Cells.Add(postitCell);
                postitCell.IsRenderable = true;

                narrCell = new ViewModel.v2.NarrativeCellVm();
                narrCell.Order = 4;
                narrCell.CanAddNarrative = false;
                narrCell.HasNarrative = false;
                narrCell.RowCode = dataRow.RowCode;
                narrCell.ColCode = "Narrative";
                dataRow.Cells.Add(narrCell);
                narrCell.IsRenderable = true;

                for (var c = 0; c <= numColumns; c++)
                {
                    var cell = new ViewModel.v2.DataCellVm();
                    cell.RowCode = dataRow.RowCode;
                    cell.ColCode = "Col_" + c;
                    cell.Class = "data-cell";
                    cell.Value = 5 * c;
                    cell.Width = "1x";
                    cell.IsEditable = true;
                    cell.Order = 5 + c;
                    cell.IsRenderable = true;
                    dataRow.Cells.Add(cell);
                }

                grid.DataRows.Add(dataRow);
            }

            return grid;
        }
    }
}