using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class RowVm
    {
        public string RowCode { get; set; }
        public string Class { get; set; }
        public string Text { get; set; }        
        public bool CanCollapse { get; set; }        
        public bool CanSelect { get; set; }
        public bool IsSelected { get; set; }
        
        public List<BaseCellVm> Cells { get; set; }
    }
}