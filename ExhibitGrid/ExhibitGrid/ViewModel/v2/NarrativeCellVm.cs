﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class NarrativeCellVm : BaseCellVm
    {
        public NarrativeCellVm()
        {
            this.Type = "narrative";
        }
        
        public bool CanAddNarrative { get; set; }
        public bool HasNarrative { get; set; }
    }
}