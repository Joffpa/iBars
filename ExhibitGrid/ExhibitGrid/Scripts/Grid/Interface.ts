

declare module ExhibitGrid.ViewModel {
    interface ICellVm {
        GridCode: string;
        RowCode: string;
        ColCode: string;
        ColSpan: number;
        ColumnHeader: string;
        IsEditable: boolean;
        Text: string;
        Class: string;
        Value: number;
        Indent: number;
        HasNarrative: boolean;
        HasPostIt: boolean;
        IsHidden: boolean;
        IsBlank: boolean;
    }
    interface IGridVm {
        GridCode: string;
        GridName: string;
        IsEditable: boolean;
        Width: number;
        HasCollapseColumn: boolean;
        HasSelectColumn: boolean;
        HasAddColumn: boolean;
        HasDeleteColumn: boolean;
        NumColumns: number;
        ColumnHeaders: ExhibitGrid.ViewModel.IColumnVm[];
        DataRows: ExhibitGrid.ViewModel.IRowVm[];
    }
    interface IColumnVm {
        ColCode: string;
        HeaderIsVisible: boolean;
        IsHidden: boolean;
        Type: string;
        Width: string;
        Text: string;
        ColSpan: number;
        Level: number;
        DisplayOrder: number;
    }
    interface IRowVm {
        GridCode: string;
        RowCode: string;
        DisplayOrder: number;
        IsHidden: boolean;
        IsCollapsed: boolean;
        Class: string;
        CanCollapse: boolean;
        CanSelect: boolean;
        CanAdd: boolean;
        CanDelete: boolean;
        IsSelected: boolean;
        Cells: ExhibitGrid.ViewModel.ICellVm[];
        CollapseableChildren: string[];
    }
}


