declare module ExhibitGrid.ViewModel.v2.Interface {
    interface IBaseCellVm {
        Order: number;
        RowCode: string;
        ColCode: string;
        IsRenderable: boolean;
    }
    interface IDataCellVm extends ExhibitGrid.ViewModel.v2.Interface.IBaseCellVm {
        Class: string;
        Width: string;
        IsEditable: boolean;
        Value: any;
    }
    interface IGridVm {
        GridCode: string;
        HasCollapseColumn: boolean;
        HasSelectColumn: boolean;
        HasCrudColumn: boolean;
        ColumnHeaders: ExhibitGrid.ViewModel.v2.Interface.IColumnHeaderVm[];
        DataRows: ExhibitGrid.ViewModel.v2.Interface.IRowVm[];
    }
    interface IColumnHeaderVm {
        ColCode: string;
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
        IsSelected: boolean;
        CrudFunctionality: string;
        Cells: ExhibitGrid.ViewModel.v2.Interface.IBaseCellVm[];
    }
    interface INarrativeCellVm extends ExhibitGrid.ViewModel.v2.Interface.IBaseCellVm {
        CanAddNarrative: boolean;
        HasNarrative: boolean;
    }
    interface IPostItCellVm extends ExhibitGrid.ViewModel.v2.Interface.IBaseCellVm {
        CanHavePostIt: boolean;
        HasPostIt: boolean;
    }
    interface ITextCellVm extends ExhibitGrid.ViewModel.v2.Interface.IBaseCellVm {
        Text: string;
        IsEditable: boolean;
    }
}
