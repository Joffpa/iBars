using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class GridVm
    {
        public GridVm(string gridCode)
        {
            this.GridCode = gridCode;
        }

        public string GridCode { get; set; }
        public string GridAttrib1 { get; set; }
        public string GridAttrib2 { get; set; }
        public string GridAttrib3 { get; set; }
        public string GridAttrib4 { get; set; }

        public List<RowVm> Rows { get; set; }

    }
}