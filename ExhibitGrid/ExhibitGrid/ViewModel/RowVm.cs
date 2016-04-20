using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ExhibitGrid.ViewModel
{
    public class RowVm
    {
        public string GridCode { get; set; }
        public string RowCode { get; set; }
        public decimal DisplayOrder { get; set; }
        public bool IsHidden { get; set; }
        public bool IsCollapsed { get; set; }
        public string Class { get; set; }
        public bool CanCollapse { get; set; }
        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
        public bool CanSelect { get; set; }
        public bool IsSelected { get; set; }
        public bool IsEditable { get; set; }
        public string Type { get; set; }
        public string CollapseParent { get; set; }
        public string TotalParentRowCode{ get; set; }


        //alignment
        //hovertext

        public List<CellVm> Cells { get; set; }
        public List<string> CollapseableChildren { get; set; }
        public List<string> TotalChildrenRowCodes{ get; set; }


    }
}