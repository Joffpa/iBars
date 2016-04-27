

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
        Value: string;
        Indent: number;
        IsHidden: boolean;
        Alignment: string;
        MaxChars: number;
        DecimalPlaces: number;
        Calcs: ExhibitGrid.ViewModel.ICalcExpressionVm[];
    }
    interface ICalcExpressionVm {
        CalcExpressionId: number;
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
    }
    interface IColumnVm {
        ColCode: string;
        HasHeader: boolean;
        DisplayText: string;
        Alignment: string;
        Level: number;
        IsHidden: boolean;
        Type: string;
        Width: string;
        ColSpan: number;
        DisplayOrder: number;
        IsEditable: boolean;
        MaxChars: number;
        DecimalPlaces: number;
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
        CollapseParent: string;
        TotalParentRowCode: string;
        Cells: ExhibitGrid.ViewModel.ICellVm[];
        CollapseableChildren: string[];
        TotalChildrenRowCodes: string[];
    }
}


