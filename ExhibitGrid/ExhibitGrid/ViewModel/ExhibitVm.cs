using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class ExhibitVm
    {
        public string PrimaryGridCode { get; set; }
        public List<GridVm> Grids { get; set; } 
    }
}