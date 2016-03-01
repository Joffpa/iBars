using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class ColumnVm
    {
        public string ColCode { get; set; }
        public bool HeaderIsVisible { get; set; }
        public bool IsHidden { get; set; }
        public string Type { get; set; }
        public string Width { get; set; }
        public string Text { get; set; }
        public int ColSpan { get; set; }
        public int Level { get; set; }
        public int DisplayOrder { get; set; }
    }
}