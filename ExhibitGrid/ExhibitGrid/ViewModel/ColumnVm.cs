using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ExhibitGrid.ViewModel
{
    public class ColumnVm
    {
        public string ColCode { get; set; }
        public bool HasHeader { get; set; } 
        public bool IsHidden { get; set; }
        public string Type { get; set; } //datatype
        public string Width { get; set; }
        public string DisplayText { get; set; }
        public int ColSpan { get; set; }
        public int Level { get; set; }
        public decimal DisplayOrder { get; set; } //col #
        public bool IsEditable { get; set; }
        public string Alignment { get; set; }
        //alignment
        //hovertext
        //header css class
        [JsonIgnore]
        public List<CellVm> Cells { get; set; }
    }
}