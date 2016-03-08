using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class RowCalcVm
    {
        public string TargetGridCode { get; set; }
        public string TargetRowCode { get; set; }
        public string Expression { get; set; }
        public List<CalcOperandVm> Operands { get; set; }
    }
}