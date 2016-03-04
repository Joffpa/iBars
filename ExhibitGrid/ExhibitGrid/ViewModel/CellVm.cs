using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class CellVm
    {
        //public int Order { get; set; } //comes from col attr
        public string GridCode { get; set; }
        public string RowCode { get; set; } 
        public string ColCode { get; set; }  //comes from col attr
        public int ColSpan{ get; set; }  //comes from col attr
        public string ColumnHeader { get; set; }  //comes from col attr
        public string Width { get; set; } //comes from col attr
        public bool IsEditable { get; set; }
        //public string Text { get; set; } 
        public string Class { get; set; }
        public double NumValue { get; set; } 
        public string Value { get; set; } 
        public int Indent { get; set; } 
        //public bool CanNarrate { get; set; } //remove
        //public bool CanPostIt { get; set; }  //remove
        public bool IsHidden { get; set; }  //comes from col attr
        public bool IsBlank { get; set; }  
    }
}