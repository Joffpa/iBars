using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class SelectCellVm : CellVm
    {
        public SelectCellVm()
        {
            this.Type = "select-cell";
        }

        public bool IncludeSpaceForCell { get; set; }
        public bool AllowSelect { get; set; }
        public bool IsSelected { get; set; }
    }
}
