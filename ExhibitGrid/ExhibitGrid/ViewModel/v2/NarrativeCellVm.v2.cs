using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class NarrativeCellVm :CellVm
    {
        public NarrativeCellVm()
        {
            this.Type = "narrative-cell";
        }

        public bool IncludeSpaceForCell { get; set; }
        public bool AllowNarrative { get; set; }
        public bool HasNarrative { get; set; }

    }
}