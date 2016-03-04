using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class ColumnVm
    {
        public string ColCode { get; set; }
        public bool HasHeader { get; set; } 
        public bool IsHidden { get; set; }
        public string Directive { get; set; } //datatype
        public string Width { get; set; }
        public string DisplayText { get; set; }
        public int ColSpan { get; set; }
        public int Level { get; set; }
        public int DisplayOrder { get; set; } //col #
        public bool IsEditable { get; set; }
        //alignment
        //hovertext
        //header css class
    }
}