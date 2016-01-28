using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class RowVm
    {
        public RowVm(string rowCode, List<CellVm> cells)
        {
            this.RowCode = rowCode;
            this.Cells = cells;
        }
        public string newProp { get; set; }
        public string RowCode { get; set; }
        public string RowAttrib1 { get; set; }
        public string RowAttrib2 { get; set; }
        public string RowAttrib3 { get; set; }
        public string RowAttrib4 { get; set; }
        public string RowAttrib5 { get; set; }
        public string RowAttrib6 { get; set; }
        public bool RowAttrib7 { get; set; }
        public bool RowAttrib8 { get; set; }
        public bool RowAttrib9 { get; set; }
        public bool RowAttrib10 { get; set; }
        public bool RowAttrib11 { get; set; }
        public bool RowAttrib12 { get; set; }

        public List<CellVm> Cells { get; set; }

    }
}