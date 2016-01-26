using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class CellVm
    {
        public CellVm(string colCode)
        {
            this.ColCode = colCode;
        }

        public string RowCode { get; set; }
        public string ColCode { get; set; }
        public string CellAttrib1 { get; set; }
        public string CellAttrib2 { get; set; }
        public string CellAttrib3 { get; set; }
        public string CellAttrib4 { get; set; }
        public string CellAttrib5 { get; set; }
        public string CellAttrib6 { get; set; }
        public bool CellAttrib7 { get; set; }
        public bool CellAttrib8 { get; set; }
        public bool CellAttrib9 { get; set; }
        public bool CellAttrib10 { get; set; }
        public bool CellAttrib11 { get; set; }
        public bool CellAttrib12 { get; set; }
    }
}