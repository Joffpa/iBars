using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class CellVm
    {
        public string GridCode { get; set; }
        public string RowCode { get; set; }
        public string ColCode { get; set; }  //comes from row attr
        public int ColSpan{ get; set; }  //comes from col attr
        public string ColumnHeader { get; set; }  //comes from col attr
        public string Width { get; set; } //comes from col attr
        public bool IsEditable { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int Indent { get; set; }
        public bool IsHidden { get; set; }  //comes from col attr
        public string Alignment { get; set; }
        public int? MaxChars { get; set; }
        public int? DecimalPlaces { get; set; }
        public string HoverBase { get; set; }
        public string HoverExpression { get; set; }

        public List<CalcExpressionVm> Calcs { get; set; }
    }
}