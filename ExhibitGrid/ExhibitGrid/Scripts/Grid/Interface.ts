
declare module ExhibitGrid.ViewModel {
    interface ICellVm {
        Order: number;
        RowCode: string;
        ColCode: string;
        ColSpan: string;
        ColumnHeader: string;
        IsEditable: boolean;
        Directive: string;
        Text: string;
        Class: string;
        Value: number;
        Indent: number;
        HasNarrative: boolean;
        HasPostIt: boolean;
        IsHidden: boolean;
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


