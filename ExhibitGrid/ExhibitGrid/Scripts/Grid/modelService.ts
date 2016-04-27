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
        updateCellVmValue(cellVm:ExhibitGrid.ViewModel.ICellVm, value: number): void;
        setCellVmValueNA(cellVm: ExhibitGrid.ViewModel.ICellVm): void;
        collapseChildren(gridCode: string, rowCode: string): void;
        getCellStyle(cell: ExhibitGrid.ViewModel.ICellVm): any;
        formatCellNumber(cell: ExhibitGrid.ViewModel.ICellVm): void;
        unformatCellNumber(cell: ExhibitGrid.ViewModel.ICellVm): void;
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
        Columns: ExhibitGrid.ViewModel.IColumnVm[];
        Rows: ExhibitGrid.ViewModel.IRowVm[];
        constructor(GridCode: string) {
            this.GridCode = GridCode;
        }
    }

    export class RowVm implements ExhibitGrid.ViewModel.IRowVm {
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
        constructor(RowCode: string, Class: string, Text: string, CanCollapse: boolean, CanSelect: boolean, IsSelected: boolean) {
            this.RowCode = RowCode;
            this.Class = Class;
        }

    }

    export class CellVm implements ExhibitGrid.ViewModel.ICellVm {
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

        updateCellVmValue(cellVm: ExhibitGrid.ViewModel.ICellVm, value: number) {
            cellVm.Value = $.formatNumber(value.toString(), { format: "#,###.00", locale: "us" });
        }
        
        setCellVmValueNA(cellVm: ExhibitGrid.ViewModel.ICellVm) {
            cellVm.Value = "N/A";
        }

        getCellValueForCalc(gridCode: string, rowCode: string, colCode: string): number {
            var cellVm = this.getCellVm(gridCode, rowCode, colCode);
            return this.getCellValueForCalcFromVm(cellVm);
        }

        getCellValueForCalcFromVm(cellVm: ExhibitGrid.ViewModel.ICellVm): number {
            //remove  comma formatting 
            var value = $.parseNumber(cellVm.Value, { format: "#,###.00", locale: "us" });
            var numValue = parseFloat(value);
            if (numValue === NaN) {
                return NaN;
            }
            if (cellVm.DecimalPlaces) {
                numValue = <number>math.round(numValue, cellVm.DecimalPlaces);
            }
            if (cellVm.Type == 'percent') {
                return numValue / 100;
            }
            return numValue;
        }

        collapseChildren(gridCode: string, rowCode: string) {
            var row = this.getRowVm(gridCode, rowCode);
            row.CollapseableChildren.forEach(childRowCode => {
                var childRow = this.getRowVm(gridCode, childRowCode);
                childRow.IsCollapsed = !childRow.IsCollapsed
            });
        }

        getCellStyle(cellVm: ExhibitGrid.ViewModel.ICellVm) {
            var style = {};
            style['text-align'] = cellVm.Alignment;
            if (cellVm.Width) {
                style['width'] = cellVm.Width;
            } else {
                style['width'] = '100%';
            }
            return style;
        }
        
        formatCellNumber(cellVm: ExhibitGrid.ViewModel.ICellVm) {
            var value = cellVm.Value;
            //remove  comma formatting 
            value = $.parseNumber(cellVm.Value, { format: "#,###.00", locale: "us" });
            //conver to float
            var numValue = parseFloat(value);
            //if it is not a valid number, return without affecting any formatting
            if (numValue === NaN) {
                return;
            }
            //Round decimals as neccesary
            if (cellVm.DecimalPlaces) {
                numValue = <number>math.round(numValue, cellVm.DecimalPlaces);
            }
            //re-apply comma formatting
            cellVm.Value = $.formatNumber(numValue.toString(), { format: "#,###.00", locale: "us" });
            if (cellVm.Value.charAt(0) === '.') {
                cellVm.Value = "0" + cellVm.Value;
            }
        }

        unformatCellNumber(cellVm: ExhibitGrid.ViewModel.ICellVm) {
            if (cellVm.Value.match(/[a-z]/i)) {
                // alphabet letters found, dont try to parse as a number
                return;
            }
            var value = cellVm.Value;
            //remove comma formatting
            value = $.parseNumber(cellVm.Value, { format: "#,###.00000000", locale: "us" });
            //conver to float
            var numValue = parseFloat(value);
            //if it is not a valid number, return without affecting any formatting
            if (numValue === NaN) {
                return;
            }
            //Round decimals as neccesary
            if (cellVm.DecimalPlaces) {
                numValue = <number>math.round(numValue, cellVm.DecimalPlaces);
            }
            //re-apply comma formatting
            cellVm.Value = numValue.toString();
        }

        constructor() {
            this.exhibitModel = window['gridModel'].exhibit;
        }
    }

    var service = angular
        .module('app.model', [])
        .service('modelService', ModelService);
}


