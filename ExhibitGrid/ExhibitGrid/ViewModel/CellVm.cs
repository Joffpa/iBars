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
        public string ColCode { get; set; }  //comes from row attr
        public string ParentRowCode { get; set; }
        public int ColSpan{ get; set; }  //comes from col attr
        public string ColumnHeader { get; set; }  //comes from col attr
        public string Width { get; set; } //comes from col attr
        public bool IsEditable { get; set; }
        public string Class { get; set; }
        public double NumValue { get; set; } 
        public string Value { get; set; } 
        public int Indent { get; set; } 
        public bool IsHidden { get; set; }  //comes from col attr
        public bool IsBlank { get; set; }
        public string Alignment { get; set; }



        public List<CalcExpressionVm> Calcs { get; set; }
    }
}