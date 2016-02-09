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

        }
        
        public bool HasPostIt { get; set; }
    }
}