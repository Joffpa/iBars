
declare module ExhibitGrid.ViewModel.Interface {
    interface IGridVm {
        GridCode: string;
        Rows: ExhibitGrid.ViewModel.Interface.IRowVm[];
    }
    interface IRowVm {
        RowCode: string;
        ParentRowCodes: string[];
        Class: string;
        Text: string;
        PeCode: string;
        SelectionCell: ExhibitGrid.ViewModel.Interface.ISelectionCellVm;
        CrudCell: ExhibitGrid.ViewModel.Interface.ICrudCellVm;
        NarrativeCell: ExhibitGrid.ViewModel.Interface.INarrativeCellVm;
        PostItCell: ExhibitGrid.ViewModel.Interface.IPostItCellVm;
        DataCells: ExhibitGrid.ViewModel.Interface.IDataCellVm[];
    }
    interface ISelectionCellVm {
        IncludeSpaceForCell: boolean;
        AllowSelect: boolean;
        IsSelected: boolean;
    }
    interface ICrudCellVm {
        IncludeSpaceForCell: boolean;
        CrudFunctionality: string;
    }
    interface INarrativeCellVm {
        IncludeSpaceForCell: boolean;
        AllowNarrative: boolean;
        HasNarrative: boolean;
    }
    interface IPostItCellVm {
        IncludeSpaceForCell: boolean;
        AllowPostIt: boolean;
        HasPostIt: boolean;
    }
    interface IDataCellVm {
        RowCode: string;
        ColCode: string;
        Class: string;
        Type: string;
        Width: string;
        IsEditable: boolean;
        Value: any;
    }
}