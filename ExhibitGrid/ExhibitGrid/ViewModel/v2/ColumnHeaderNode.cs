using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class ColumnHeaderNode
    {
        public ColumnHeaderVm ViewModel { get; set; }
        public List<ColumnHeaderNode> ChildNodes { get; set; }
    }
}