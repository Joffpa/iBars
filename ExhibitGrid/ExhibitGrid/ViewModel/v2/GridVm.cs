using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class GridVm
    {
        public string GridCode { get; set; }
        public List<RowVm> HeaderRows { get; set; }
        public List<RowVm> DataRows { get; set; }
    }
}