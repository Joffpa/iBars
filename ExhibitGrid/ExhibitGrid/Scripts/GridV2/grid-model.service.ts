/// <reference path="../typings/lodash/lodash.d.ts" />

module Service {

    export interface IModelService {
        exhibitModel: ExhibitVm;
        addGridVm(gridVm: ExhibitGrid.ViewModel.IGridVm);
        getExhibitVm(): ExhibitVm;
        getGridVm(gridCode: string): ExhibitGrid.ViewModel.IGridVm;
        getRowVm(gridCode: string, rowCode: string): ExhibitGrid.ViewModel.IRowVm;
        getCellVm(gridCode: string, rowCode: string, colCode: string): ExhibitGrid.ViewModel.ICellVm;
        getCellValue(gridCode: string, rowCode: string, colCode: string): number;
        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: number): void;
        collapseChildren(gridCode: string, rowCode: string): void;
        getParentRowCalcForColumn(gridCode: string, parentRowCode: string, colCode): string;
    }

    export class ExhibitVm {
        Grids: ExhibitGrid.ViewModel.IGridVm[];
        constructor() {
            console.log("creating exhibitvm");
            this.Grids = new Array<ExhibitGrid.ViewModel.IGridVm>();
        }
    }

    export class GridVm implements ExhibitGrid.ViewModel.IGridVm {

        GridCode: string;
        DisplayText: string;
        IsEditable: boolean;
        Width: number;
        HasCollapseColumn: boolean;
        HasSelectColumn: boolean;
        HasAddColumn: boolean;
        HasDeleteColumn: boolean;
        NumColumns: number;
        Columns: ExhibitGrid.ViewModel.IColumnVm[];
        DataRows: ExhibitGrid.ViewModel.IRowVm[];
        constructor(GridCode: string) {
            this.GridCode = GridCode;
        }
    }

    export class RowVm implements ExhibitGrid.ViewModel.IRowVm {
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
        CollapseableChildren: string[];
        constructor(RowCode: string, Class: string, Text: string, CanCollapse: boolean, CanSelect: boolean, IsSelected: boolean) {
            this.RowCode = RowCode;
            this.Class = Class;
        }

    }

    export class CellVm implements ExhibitGrid.ViewModel.ICellVm {
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
        constructor(Order: number, Type: string, RowCode: string, ColCode: string, CanAddNarrative: boolean, HasNarrative: boolean) {
            this.RowCode = RowCode;
            this.ColCode = ColCode;
        }
    }
    export class CalcExpressionVm implements ExhibitGrid.ViewModel.ICalcExpressionVm {
        TargetGridCode: string;
        TargetRowCode: string;
        TargetColCode: string;
        Expression: string;
        Operands: ExhibitGrid.ViewModel.ICalcOperandVm[];
    }

    export class CalcOperandVm implements ExhibitGrid.ViewModel.ICalcOperandVm {
        GridCode: string;
        RowCode: string;
        ColCode: string;
    }



    export class GridModelService implements IModelService{

        public exhibitModel: ExhibitVm;

        constructor() {
            console.log("creating service");
            this.exhibitModel = new ExhibitVm();
        }

        addGridVm(gridVm: ExhibitGrid.ViewModel.IGridVm) {
            this.exhibitModel.Grids.push(gridVm);
        }

        getExhibitVm() {  
            return this.exhibitModel;
        }

        getGridVm(gridCode: string): ExhibitGrid.ViewModel.IGridVm {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            return grid;
        }

        getRowVm(gridCode: string, rowCode: string): ExhibitGrid.ViewModel.IRowVm {
            console.log(gridCode);
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            return row;
        }

        getCellVm(gridCode: string, rowCode: string, colCode: string): ExhibitGrid.ViewModel.ICellVm {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell;
        }

        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: number) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            cell.NumValue = value;
        }

        getCellValue(gridCode: string, rowCode: string, colCode: string): number {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell.NumValue;
        }

        collapseChildren(gridCode: string, rowCode: string) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            _.each(_.where(grid.DataRows, { 'ParentRowCode': rowCode }), child => {
                child.IsCollapsed = !child.IsCollapsed;
            });

        }

        getParentRowCalcForColumn(gridCode: string, parentRowCode: string, colCode) {
            var calc = "";
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            _.each(_.where(grid.DataRows, { 'ParentRowCode': parentRowCode }), child => {
                var cell = _.find(child.Cells, { 'ColCode': colCode });
                calc += cell.NumValue.toString() + "+";
            });
            if (calc && calc.length > 2) {
                calc.substring(0, calc.length - 2);
            } else {
                calc = "0";
            }
            return calc;
        }
    }

}