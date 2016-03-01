using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class GridVm
    {
        public string GridCode { get; set; }
        public string GridName { get; set; }
        public bool IsEditable { get; set; }
        public int Width { get; set; }
        public bool HasCollapseColumn { get; set; }
        public bool HasSelectColumn { get; set; }
        public bool HasAddColumn { get; set; }
        public bool HasDeleteColumn { get; set; }
        public int NumColumns { get; set; }

        public List<ColumnVm> ColumnHeaders { get; set; }
        public List<RowVm> DataRows { get; set; }
    }
}