using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class GridAttribsVm
    {
        public GridAttribsVm(string gridCode)
        {
            this.GridCode = gridCode;
        }

        public string GridCode { get; set; }
        public List<RowAttribsVm> Rows { get; set; }

    }
}