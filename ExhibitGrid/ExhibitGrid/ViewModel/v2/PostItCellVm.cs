using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class PostItCellVm : BaseCellVm
    {
        public PostItCellVm()
        {
            this.Type = "postit";
        }
        
        public bool CanHavePostIt { get; set; }
        public bool HasPostIt { get; set; }
    }
}