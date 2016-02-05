using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel.v2
{
    public class DataCellVm : BaseCellVm
    {
        public DataCellVm()
        {

        }

        public string Class { get; set; }
        public string Width { get; set; }
        public bool IsEditable { get; set; }
        public object Value { get; set; }
    }
}