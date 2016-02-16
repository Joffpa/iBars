
declare module ExhibitGrid.ViewModel.v2 {
    interface ICellVm {
        Order: number;
        RowCode: string;
        ColCode: string;
        IsEditable: boolean;
        Directive: string;
        Text: string;
        Class: string;
        Value: number;
        Indent: number;
        HasNarrative: boolean;
        HasPostIt: boolean;
    }
    interface IGridVm {
        GridCode: string;
        HasCollapseColumn: boolean;
        HasSelectColumn: boolean;
        HasAddColumn: boolean;
        HasDeleteColumn: boolean;
        NumColumns: number;
        ColumnHeaders: ExhibitGrid.ViewModel.v2.IColumnHeaderVm[];
        DataRows: ExhibitGrid.ViewModel.v2.IRowVm[];
    }
    interface IColumnHeaderVm {
        ColCode: string;
        HeaderIsVisible: boolean;
        Width: string;
        Text: string;
        ColSpan: number;
        Level: number;
        Order: number;
    }
    interface IRowVm {
        RowCode: string;
        Class: string;
        Text: string;
        CanCollapse: boolean;
        CanSelect: boolean;
        CanAdd: boolean;
        CanDelete: boolean;
        IsSelected: boolean;
        Cells: ExhibitGrid.ViewModel.v2.ICellVm[];
    }
}
