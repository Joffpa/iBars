using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class GridVm
    {
        public string GridCode { get; set; }
        //public int MaxHeaderLevels { get; set; }
        //public List<ColumnHeaderNode> ColumnHeaderTree { get; set; }
        public List<ColumnHeaderVm> ColumnHeaders { get; set; }
        public List<RowVm> DataRows { get; set; }
    }
}