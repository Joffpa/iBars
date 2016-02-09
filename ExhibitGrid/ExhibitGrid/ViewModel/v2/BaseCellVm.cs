using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public abstract class BaseCellVm
    {
        public int Order { get; set; }
        //public string Type { get; set; }
        public string RowCode { get; set; }
        public string ColCode { get; set; }
        public bool IsEditable { get; set; }
    }
}