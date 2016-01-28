using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class GridVm
    {
        public string GridCode { get; set; }
        public List<RowVm> Rows { get; set; }

    }
}