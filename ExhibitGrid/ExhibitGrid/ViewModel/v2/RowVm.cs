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
        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
        public bool IsSelected { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsHidden { get; set; }

        public List<CellVm> Cells { get; set; }
    }
}