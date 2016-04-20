/// <reference path="../typings/lodash/lodash.d.ts" />

'use strict';

module app.model {

    export interface IModelService {
        exhibitModel: ExhibitVm;
        addGridVm(gridVm: ExhibitGrid.ViewModel.IGridVm);
        getExhibitVm(): ExhibitVm;
        getGridVm(gridCode: string): ExhibitGrid.ViewModel.IGridVm;
        getRowVm(gridCode: string, rowCode: string): ExhibitGrid.ViewModel.IRowVm;
        getRowVms(gridCode: string, rowCodes: string[]): ExhibitGrid.ViewModel.IRowVm[];
        getCellVm(gridCode: string, rowCode: string, colCode: string): ExhibitGrid.ViewModel.ICellVm;
        getCellValueForCalc(gridCode: string, rowCode: string, colCode: string): number;
        getCellValueForCalcFromVm(cell: ExhibitGrid.ViewModel.ICellVm): number;
        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: number): void;
        updateCellVmValue(cell:ExhibitGrid.ViewModel.ICellVm, value: number): void;
        setCellVmValueNA(cell: ExhibitGrid.ViewModel.ICellVm): void;
        collapseChildren(gridCode: string, rowCode: string): void;
    }

    export class ExhibitVm {
        Grids: ExhibitGrid.ViewModel.IGridVm[];
        constructor() {
            this.Grids = new Array<ExhibitGrid.ViewModel.IGridVm>();
        }        
    }

    export class GridVm implements ExhibitGrid.ViewModel.IGridVm {

        GridCode: string;
        DisplayText: string;
        IsEditable: boolean;
        Width: number;
        HasSelectCol: boolean;
        HasCollapseCol: boolean;
        HasAddCol: boolean;
        HasDeleteCol: boolean;
        NumColumns: number;
        Columns: ExhibitGrid.ViewModel.IColumnVm[];
        Rows: ExhibitGrid.ViewModel.IRowVm[];
        Cells: ExhibitGrid.ViewModel.ICellVm[];
        ExternalDependantCells: ExhibitGrid.ViewModel.ICellVm[];
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
        Type: string;
        Cells: ExhibitGrid.ViewModel.ICellVm[];
        CollapseParent: string;
        CollapseableChildren: string[];
        TotalParentRowCode: string;
        TotalChildrenRowCodes: string[];
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
        Alignment: string;
        Type: string;
        Calcs: ExhibitGrid.ViewModel.ICalcExpressionVm[];
        constructor(Order: number, Type: string, RowCode: string, ColCode: string, CanAddNarrative: boolean, HasNarrative: boolean) {
            this.RowCode = RowCode;
            this.ColCode = ColCode;
        }
    }
    export class CalcExpressionVm implements ExhibitGrid.ViewModel.ICalcExpressionVm {
        CalcExpressionId: number;
        TargetGridCode: string;
        TargetRowCode: string;
        TargetColCode: string;
        Expression: string;
        Operands: ExhibitGrid.ViewModel.ICalcOperandVm[];
    }

    export class CalcOperandVm implements ExhibitGrid.ViewModel.ICalcOperandVm{
        GridCode: string;
        RowCode: string;
        ColCode: string;
    }


    export class ModelService implements IModelService {
        exhibitModel: ExhibitVm;

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
            var grid = this.getGridVm(gridCode);
            var row = _.find(grid.Rows, { 'RowCode': rowCode });
            return row;
        }

        getRowVms(gridCode: string, rowCodes: string[]): ExhibitGrid.ViewModel.IRowVm[]  {
            var grid = this.getGridVm(gridCode);
            return _.filter(grid.Rows, function (r) { return _.includes(rowCodes, r.RowCode)});
        }

        getCellVm(gridCode: string, rowCode: string, colCode: string): ExhibitGrid.ViewModel.ICellVm {
            var row = this.getRowVm(gridCode, rowCode);
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell;
        }

        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: number) {
            var cell = this.getCellVm(gridCode, rowCode, colCode);
            this.updateCellVmValue(cell, value);
        }

        updateCellVmValue(cell: ExhibitGrid.ViewModel.ICellVm, value: number) {
            cell.NumValue = value;
            cell.Value = value.toString();
        }

        setCellVmValueNA(cell: ExhibitGrid.ViewModel.ICellVm) {
            cell.Value = "N/A";
            cell.NumValue = 0;
        }

        getCellValueForCalc(gridCode: string, rowCode: string, colCode: string): number {
            var cell = this.getCellVm(gridCode, rowCode, colCode);
            return this.getCellValueForCalcFromVm(cell);
        }

        getCellValueForCalcFromVm(cell: ExhibitGrid.ViewModel.ICellVm): number {
            if (cell.Type == 'percent') {
                return cell.NumValue / 100;
            }
            return cell.NumValue;
        }

        collapseChildren(gridCode: string, rowCode: string) {
            var row = this.getRowVm(gridCode, rowCode);
            row.CollapseableChildren.forEach(childRowCode => {
                var childRow = this.getRowVm(gridCode, childRowCode);
                childRow.IsCollapsed = !childRow.IsCollapsed
            });
        }

        constructor() {
            this.exhibitModel = window['gridModel'].exhibit;
        }
    }

    var service = angular
        .module('app.model', [])
        .service('modelService', ModelService);
}


