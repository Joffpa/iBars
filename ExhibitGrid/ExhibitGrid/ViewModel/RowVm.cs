using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExhibitGrid.ViewModel
{
    public class RowVm
    {
        public string RowCode { get; set; }
        public string[] ParentRowCodes { get; set; }
        public RowType Type { get; set; }
        public string Text { get; set; }
        public SelectionCellVm SelectionCell { get; set; }
        public CrudCellVm CrudCell { get; set; }
        public NarrativeCellVm NarrativeCell { get; set; }
        public PostItCellVm PostItCell { get; set; }

        public List<DataCellVm> DataCells { get; set; }
    }

    public enum RowType
    {
        Data, Total, Header
    }

    public class SelectionCellVm
    {
        public bool IncludeSpaceForCell { get; set; }
        public bool AllowSelect { get; set; }
        public bool IsSelected { get; set; }
    }
    public class CrudCellVm
    {
        public bool IncludeSpaceForCell { get; set; }
        public string CrudFunctionality { get; set; }
    }
    public class NarrativeCellVm
    {
        public bool IncludeSpaceForCell { get; set; }
        public bool AllowNarrative { get; set; }
        public bool HasNarrative { get; set; }
    }
    public class PostItCellVm
    {
        public bool IncludeSpaceForCell { get; set; }
        public bool AllowPostIt { get; set; }
        public bool HasPostIt { get; set; }
    }
}
