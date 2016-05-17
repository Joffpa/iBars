


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
        HoverBase: string;
        HoverAddition: string;
        TextColor: string;
        Calcs: ExhibitGrid.ViewModel.ICalcExpressionVm[];
    }
    interface ICalcExpressionVm {
        CalcExpressionId: number;
        TargetGridCode: string;
        TargetRowCode: string;
        TargetColCode: string;
        Expression: string;
        UpdateContext: string;
        Operands: ExhibitGrid.ViewModel.ICalcOperandVm[];
    }
    interface ICalcOperandVm {
        GridCode: string;
        RowCode: string;
        ColCode: string;
    }
    interface IGridVm {
        GridCode: string;
        IsRendered: boolean;
        IsEditable: boolean;
        Width: number;
        HasSelectCol: boolean;
        HasCollapseCol: boolean;
        HasAddCol: boolean;
        HasDeleteCol: boolean;
        ShowNegativeNumsInParens: boolean;
        Columns: ExhibitGrid.ViewModel.IColumnVm[];
        Rows: ExhibitGrid.ViewModel.IRowVm[];
        ColCalcs: ExhibitGrid.ViewModel.ICalcExpressionVm[];
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
        ChildrenAreCollapsed: boolean;
        Class: string;
        CanCollapse: boolean;
        CanAdd: boolean;
        CanDelete: boolean;
        CanSelect: boolean;
        SumChildrenIntoRow: boolean;
        IsSelected: boolean;
        IsEditable: boolean;
        Type: string;
        ParentRowCode: string;
        ChildRowCodes: string[];
        Cells: ExhibitGrid.ViewModel.ICellVm[];
        TemplateRows: ExhibitGrid.ViewModel.IRowVm[];
    }

    interface ICellValueFormattting {
        Value: string;
        TextColor: string;
    }
}

