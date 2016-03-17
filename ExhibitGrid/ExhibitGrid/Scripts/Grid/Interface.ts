





declare module ExhibitGrid.ViewModel {
    interface ICellVm {
        GridCode: string;
        RowCode: string;
        ColCode: string;
        ParentRowCode: string;
        ColSpan: number;
        ColumnHeader: string;
        Width: string;
        IsEditable: boolean;
        Class: string;
        NumValue: number;
        Value: string;
        Indent: number;
        IsHidden: boolean;
        IsBlank: boolean;
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
        Columns: ExhibitGrid.ViewModel.IColumnVm[];
        DataRows: ExhibitGrid.ViewModel.IRowVm[];
    }
    interface IColumnVm {
        ColCode: string;
        HasHeader: boolean;
        IsHidden: boolean;
        Directive: string;
        Width: string;
        DisplayText: string;
        ColSpan: number;
        Level: number;
        DisplayOrder: number;
        IsEditable: boolean;
    }
    interface IRowVm {
        GridCode: string;
        RowCode: string;
        ParentRowCode: string;
        DisplayOrder: number;
        IsHidden: boolean;
        IsCollapsed: boolean;
        Class: string;
        CanCollapse: boolean;
        CanSelect: boolean;
        CanAdd: boolean;
        CanDelete: boolean;
        IsSelected: boolean;
        IsEditable: boolean;
        Cells: ExhibitGrid.ViewModel.ICellVm[];
    }
}


