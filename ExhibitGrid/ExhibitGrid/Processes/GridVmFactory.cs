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

        private static GridVm GetMockGridVm()
        {
            var numRows = 16;
            var numColumns = 17;

            var grid = new GridVm();
            grid.GridCode = "MockGrid";
            
            var headerRow = new RowVm();
            headerRow.RowCode = "Row_0";
            headerRow.ParentRowCodes = null;
            headerRow.Class = "header-row";
            headerRow.Text = "Header Text";

            var selectCell = new SelectionCellVm();
            selectCell.IncludeSpaceForCell = true;
            selectCell.AllowSelect = false;
            selectCell.IsSelected = false;
            headerRow.SelectionCell = selectCell;

            var crudCell = new CrudCellVm();
            crudCell.IncludeSpaceForCell = true;
            crudCell.CrudFunctionality = "no-crud";
            headerRow.CrudCell = crudCell;
            
            var narrCell = new NarrativeCellVm();
            narrCell.IncludeSpaceForCell = true;
            narrCell.AllowNarrative = false;
            narrCell.HasNarrative = false;
            headerRow.NarrativeCell = narrCell;

            var postItCell = new PostItCellVm();
            postItCell.IncludeSpaceForCell = true;
            postItCell.AllowPostIt = false;
            postItCell.HasPostIt = false;
            headerRow.PostItCell = postItCell;

            headerRow.DataCells = new List<DataCellVm>();
            for (var c = 0; c <= numColumns; c++)
            {
                var cell = new DataCellVm();
                cell.RowCode = headerRow.RowCode;
                cell.ColCode = "Col_" + c;
                cell.Class = "header-cell";
                cell.Type = "read-only";
                cell.Value = "Column " + c;
                cell.Width = "1x";
                cell.IsEditable = false;

                headerRow.DataCells.Add(cell);
            }

            grid.Rows = new List<RowVm>() { headerRow };

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
    }
}