using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class CellVm
    {
        public int Order { get; set; }
        public string RowCode { get; set; }
        public string ColCode { get; set; }
        public bool IsEditable { get; set; }
        public string Directive { get; set; }
        public string Text { get; set; }
        public string Class { get; set; }
        public double Value { get; set; }
        public int Indent { get; set; }
        public bool HasNarrative { get; set; }
        public bool HasPostIt { get; set; }
    }
}