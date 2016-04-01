using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class GridVm
    {
        public string GridCode { get; set; }
        public string DisplayText { get; set; }
        public bool IsEditable { get; set; }
        public int Width { get; set; }
        public bool HasSelectCol { get; set; }
        public bool HasCollapseCol { get; set; }
        public bool HasAddCol { get; set; }
        public bool HasDeleteCol { get; set; }

        public List<ColumnVm> Columns { get; set; }
        public List<RowVm> DataRows { get; set; }
    }
}