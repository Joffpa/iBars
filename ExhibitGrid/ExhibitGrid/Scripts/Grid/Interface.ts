
declare module ExhibitGrid.ViewModel {
    interface ICellVm {
        GridCode: string;
        RowCode: string;
        ColCode: string;
        ColSpan: number;
        ColumnHeader: string;
        Width: string;
        IsEditable: boolean;
        Type: string;
        NumValue: number;
        Value: string;
        Indent: number;
        IsHidden: boolean;
        IsBlank: boolean;
        Alignment: string;
        Calcs: ExhibitGrid.ViewModel.ICalcExpressionVm[];
    }
    interface ICalcExpressionVm {
        TargetGridCode: string;
        TargetRowCode: string;
        TargetColCode: string;
        Expression: string;
        Operands: ExhibitGrid.ViewModel.ICalcOperandVm[];
    }
    interface ICalcOperandVm {
        GridCode: string;
        RowCode: string;
        ColCode: string;
    }
    interface IGridVm {
        GridCode: string;
        DisplayText: string;
        IsEditable: boolean;
        Width: number;
        HasSelectCol: boolean;
        HasCollapseCol: boolean;
        HasAddCol: boolean;
        HasDeleteCol: boolean;
        Columns: ExhibitGrid.ViewModel.IColumnVm[];
        Rows: ExhibitGrid.ViewModel.IRowVm[];
        Cells: ExhibitGrid.ViewModel.ICellVm[];
        ExternalDependantCells: ExhibitGrid.ViewModel.ICellVm[];
    }
    interface IColumnVm {
        ColCode: string;
        HasHeader: boolean;
        IsHidden: boolean;
        Type: string;
        Width: string;
        DisplayText: string;
        ColSpan: number;
        Level: number;
        DisplayOrder: number;
        IsEditable: boolean;
        Alignment: string;
        Cells: ExhibitGrid.ViewModel.ICellVm[];
    }
    interface IRowVm {
        GridCode: string;
        RowCode: string;
        DisplayOrder: number;
        IsHidden: boolean;
        IsCollapsed: boolean;
        Class: string;
        CanCollapse: boolean;
        CanAdd: boolean;
        CanDelete: boolean;
        CanSelect: boolean;
        IsSelected: boolean;
        IsEditable: boolean;
        Type: string;
        Cells: ExhibitGrid.ViewModel.ICellVm[];
    }
}


