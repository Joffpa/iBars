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


            //Add Column headers to list
            grid.ColumnHeaders = new List<ViewModel.v2.ColumnHeaderVm>();

            var colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level3Header";
            //colHeader.ParentColCode = null;
            colHeader.Text = "Level 3 Header";
            colHeader.Level = 3;
            colHeader.Order = 0;
            colHeader.ColSpan = 18;
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level2HeaderA";
            //colHeader.ParentColCode = "Level3Header";
            colHeader.Text = "Level 2 Header A";
            colHeader.Level = 2;
            colHeader.Order = 0;
            colHeader.ColSpan = 17;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level2HeaderB";
            //colHeader.ParentColCode = "Level3Header";
            colHeader.Text = "Level 2 Header B";
            colHeader.Level = 2;
            colHeader.Order = 1;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderA";
            //colHeader.ParentColCode = "Level2HeaderA";
            colHeader.Text = "Level 1 Header A";
            colHeader.Level = 1;
            colHeader.Order = 0;
            colHeader.ColSpan = 7;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderB";
            //colHeader.ParentColCode = "Level2HeaderA";
            colHeader.Text = "Level 1 Header B";
            colHeader.Level = 1;
            colHeader.Order = 1;
            colHeader.ColSpan = 10;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level1HeaderC";
            //colHeader.ParentColCode = "Level2HeaderB";
            colHeader.Text = "Level 1 Header C";
            colHeader.Level = 1;
            colHeader.Order = 2;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderA";
            //colHeader.ParentColCode = "Level1HeaderA";
            colHeader.Text = "Level 0 Header A";
            colHeader.Level = 0;
            colHeader.Order = 1;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderB";
            //colHeader.ParentColCode = "Level1HeaderA";
            colHeader.Text = "Level 0 Header B";
            colHeader.Level = 0;
            colHeader.Order = 2;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderC";
            //colHeader.ParentColCode = "Level1HeaderA";
            colHeader.Text = "Level 0 Header C";
            colHeader.Level = 0;
            colHeader.Order = 3;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderD";
            //colHeader.ParentColCode = "Level1HeaderA";
            colHeader.Text = "Level 0 Header D";
            colHeader.Level = 0;
            colHeader.Order = 4;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderE";
            //colHeader.ParentColCode = "Level1HeaderA";
            colHeader.Text = "Level 0 Header E";
            colHeader.Level = 0;
            colHeader.Order = 5;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderF";
            //colHeader.ParentColCode = "Level1HeaderA";
            colHeader.Text = "Level 0 Header F";
            colHeader.Level = 0;
            colHeader.Order = 6;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderG";
            //colHeader.ParentColCode = "Level1HeaderA";
            colHeader.Text = "Level 0 Header G";
            colHeader.Level = 0;
            colHeader.Order = 7;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);

            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderH";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header H";
            colHeader.Level = 0;
            colHeader.Order = 8;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderI";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header I";
            colHeader.Level = 0;
            colHeader.Order = 9;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderJ";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header J";
            colHeader.Level = 0;
            colHeader.Order = 10;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderK";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header K";
            colHeader.Level = 0;
            colHeader.Order = 11;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderL";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header L";
            colHeader.Level = 0;
            colHeader.Order = 12;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderM";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header M";
            colHeader.Level = 0;
            colHeader.Order = 13;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderN";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header N";
            colHeader.Level = 0;
            colHeader.Order = 14;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderO";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header O";
            colHeader.Level = 0;
            colHeader.Order = 15;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderP";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header P";
            colHeader.Level = 0;
            colHeader.Order = 16;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);
            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderQ";
            //colHeader.ParentColCode = "Level1HeaderB";
            colHeader.Text = "Level 0 Header Q";
            colHeader.Level = 0;
            colHeader.Order = 17;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);


            colHeader = new ViewModel.v2.ColumnHeaderVm();
            colHeader.ColCode = "Level0HeaderR";
            //colHeader.ParentColCode = "Level1HeaderC";
            colHeader.Text = "Level 0 Header R";
            colHeader.Level = 0;
            colHeader.Order = 18;
            colHeader.ColSpan = 1;
            grid.ColumnHeaders.Add(colHeader);


            //Convert header list to header tree DEPRECATED
            //int maxLevels = 0;
            //int colSpan;
            //grid.ColumnHeaderTree = GetColumnHeaderTree(grid.ColumnHeaders, null, 0,out colSpan, ref maxLevels);
            //grid.MaxHeaderLevels = maxLevels;


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
                dataRow.CrudFunctionality = r % 2 == 0 ? "create" : r % 3 == 0 ? "delete" : "none";

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

        //    public static List<ViewModel.v2.ColumnHeaderNode> GetColumnHeaderTree(List<ViewModel.v2.ColumnHeaderVm> headerList, string parentColCode, int level, out int colSpan,  ref int maxLevel)
        //    {
        //        List<ViewModel.v2.ColumnHeaderNode> tree = null;
        //        colSpan = 0;
        //        if (headerList.Any(c => c.ParentColCode == parentColCode))
        //        {
        //            if (level > maxLevel)
        //            {
        //                maxLevel = level;
        //            }
        //            tree = new List<ViewModel.v2.ColumnHeaderNode>();
        //            foreach (var colHeader in headerList.Where(c => c.ParentColCode == parentColCode))
        //            {
        //                var node = new ViewModel.v2.ColumnHeaderNode();
        //                node.ViewModel = colHeader;
        //                node.ChildNodes = GetColumnHeaderTree(headerList, colHeader.ColCode, level + 1, out colSpan, ref maxLevel);
        //                node.ViewModel.ColSpan = colSpan;
        //                tree.Add(node);
        //            }
        //            colSpan = tree.Sum(n => n.ViewModel.ColSpan);
        //        }
        //        else
        //        {
        //            colSpan = 1;
        //        }
        //        return tree;
        //    }
        //}
    }

}