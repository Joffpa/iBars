
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
        HasCollapseColumn: boolean;
        HasSelectColumn: boolean;
        HasAddColumn: boolean;
        HasDeleteColumn: boolean;
        NumColumns: number;
        ColumnHeaders: ExhibitGrid.ViewModel.IColumnHeaderVm[];
        DataRows: ExhibitGrid.ViewModel.IRowVm[];
    }
    interface IColumnHeaderVm {
        ColCode: string;
        HeaderIsVisible: boolean;
        IsHidden: boolean;
        Type: string;
        Width: string;
        Text: string;
        ColSpan: number;
        Level: number;
        Order: number;
    }
    interface IRowVm {
        RowCode: string;
        DisplayOrder: number;
        IsHidden: boolean;
        Text: string;
        Class: string;
        CanCollapse: boolean;
        CanSelect: boolean;
        CanAdd: boolean;
        CanDelete: boolean;
        IsSelected: boolean;
        Cells: ExhibitGrid.ViewModel.ICellVm[];
    }
}


