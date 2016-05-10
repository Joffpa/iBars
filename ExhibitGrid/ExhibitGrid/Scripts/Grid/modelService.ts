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
        getChildRowVms(parentRow: ExhibitGrid.ViewModel.IRowVm): ExhibitGrid.ViewModel.IRowVm[];
        getCellVm(gridCode: string, rowCode: string, colCode: string): ExhibitGrid.ViewModel.ICellVm;
        getCellValueForCalc(gridCode: string, rowCode: string, colCode: string): number;
        getCellValueForCalcFromVm(cell: ExhibitGrid.ViewModel.ICellVm): number;
        getCellStyle(cell: ExhibitGrid.ViewModel.ICellVm): any;
        getGridColCalcs(gridCode: string): ExhibitGrid.ViewModel.ICalcExpressionVm[];

        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: string): void;
        updateCellVmValue(cellVm: ExhibitGrid.ViewModel.ICellVm, value: string): void;
        updateCellVmDeltaCheck(cellVm: ExhibitGrid.ViewModel.ICellVm, value: number): void;
        updateCellVmValueNA(cellVm: ExhibitGrid.ViewModel.ICellVm): void;

        collapseChildren(parentRow: ExhibitGrid.ViewModel.IRowVm, collapse: boolean): void;
        formatCellValue(cell: ExhibitGrid.ViewModel.ICellVm): void;
        unformatCellValue(cell: ExhibitGrid.ViewModel.ICellVm): void;
        unformatNumber(value: string, decimalPlaces: number): number;
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
        ShowNegativeNumsInParens: boolean;
        Columns: ExhibitGrid.ViewModel.IColumnVm[];
        Rows: ExhibitGrid.ViewModel.IRowVm[];
        ColCalcs: ExhibitGrid.ViewModel.ICalcExpressionVm[];
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
        ChildrenAreCollapsed: boolean;
        Class: string;
        CanCollapse: boolean;
        CanAdd: boolean;
        CanDelete: boolean;
        CanSelect: boolean;
        IsSelected: boolean;
        IsEditable: boolean;
        Type: string;
        CollapseParentRowCode: string;
        TotalParentRowCode: string;
        Cells: ExhibitGrid.ViewModel.ICellVm[];
        CollapseableChildrenRowCodes: string[];
        TotalChildrenRowCodes: string[];
        TemplateRows: ExhibitGrid.ViewModel.IRowVm[];
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
        HoverBase: string;
        HoverAddition: string;
        TextColor: string;
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
        UpdateContext:string;
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

        getChildRowVms(parentRow: ExhibitGrid.ViewModel.IRowVm) {
            var grid = this.getGridVm(parentRow.GridCode);
            var rows = _.filter(grid.Rows, row => {
                var isChild = _.includes(parentRow.TotalChildrenRowCodes, row.RowCode);
                return isChild;
            });
            return rows;
        }

        getCellVm(gridCode: string, rowCode: string, colCode: string): ExhibitGrid.ViewModel.ICellVm {
            var row = this.getRowVm(gridCode, rowCode);
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell;
        }

        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: string) {
            var cell = this.getCellVm(gridCode, rowCode, colCode);
            this.updateCellVmValue(cell, value);
        }

        updateCellVmValue(cellVm: ExhibitGrid.ViewModel.ICellVm, value: string) {
            var decimals;
            if (cellVm.DecimalPlaces) {
                decimals = cellVm.DecimalPlaces;
            } else {
                decimals = 2;
            }
            var grid = this.getGridVm(cellVm.GridCode);
            var formatResult = this.formatNumber(value, decimals, grid.ShowNegativeNumsInParens);
            cellVm.Value = formatResult.Value;
            //cellVm.TextColor = formatResult.TextColor;
        }
        
        updateCellVmValueNA(cellVm: ExhibitGrid.ViewModel.ICellVm) {
            cellVm.Value = "N/A";
            //cellVm.TextColor = "";
        }

        updateCellVmDeltaCheck(cellVm: ExhibitGrid.ViewModel.ICellVm, value: number) {
            if (value !== null) {
                var grid = this.getGridVm(cellVm.GridCode);
                var formattedVal = this.formatNumber(value.toString(), cellVm.DecimalPlaces, grid.ShowNegativeNumsInParens);
                if (value < 0) {
                    cellVm.TextColor = "red";
                    cellVm.HoverAddition = "<div class='delta-negative'>" + formattedVal.Value + "</div>";
                } else if (value > 0) {
                    cellVm.TextColor = "red";
                    cellVm.HoverAddition = "<div class='delta-positive'>" + formattedVal.Value + "</div>";
                } else {
                    cellVm.TextColor = "blue";
                    cellVm.HoverAddition = "<div class='delta-balanced'>In Balance</div>";
                }
            } else {
                cellVm.TextColor = "red";
                cellVm.HoverAddition = "<div class='delta-negative'>N/A</div>";
            }
        }

        getCellValueForCalc(gridCode: string, rowCode: string, colCode: string): number {
            var cellVm = this.getCellVm(gridCode, rowCode, colCode);
            return this.getCellValueForCalcFromVm(cellVm);
        }

        getCellValueForCalcFromVm(cellVm: ExhibitGrid.ViewModel.ICellVm): number {
            var numValue = this.unformatNumber(cellVm.Value, cellVm.DecimalPlaces);
            if (numValue && cellVm.Type == 'percent') {
                return numValue / 100;
            }
            return numValue;
        }

        getCellStyle(cellVm: ExhibitGrid.ViewModel.ICellVm) {
            var style = {};
            style['text-align'] = cellVm.Alignment;
            if (cellVm.Width) {
                style['width'] = cellVm.Width;
            } else {
                style['width'] = '100%';
            }
            if (cellVm.TextColor) {
                style['color'] = cellVm.TextColor;
                style['text-decoration-color'] = cellVm.TextColor;
            }
            return style;
        }

        getGridColCalcs(gridCode: string) {
            var grid = this.getGridVm(gridCode);
            return grid.ColCalcs;
        }
        
        collapseChildren(parentRow: ExhibitGrid.ViewModel.IRowVm, collapse: boolean) {
            parentRow.ChildrenAreCollapsed = collapse;
            parentRow.CollapseableChildrenRowCodes.forEach(childRowCode => {
                var childRow = this.getRowVm(parentRow.GridCode, childRowCode);
                childRow.IsCollapsed = collapse;
            });
        }

        
        formatCellValue(cellVm: ExhibitGrid.ViewModel.ICellVm) {
            var decimals;
            if (cellVm.DecimalPlaces) {
                decimals = cellVm.DecimalPlaces;
            } else {
                decimals = 2;
            }
            var grid = this.getGridVm(cellVm.GridCode);
            var formatResult = this.formatNumber(cellVm.Value, decimals, grid.ShowNegativeNumsInParens);
            cellVm.Value = formatResult.Value;
            //cellVm.TextColor = formatResult.TextColor;
        }

        formatNumber(value: string, decimalPlaces: number, showNegativeInParens: boolean) {
            var result: ExhibitGrid.ViewModel.ICellValueFormattting = {
                Value : null,
                TextColor: ""
            }
            if (!value) {
                value = "0";
            }
            //unformat number to remove any previous formatting for rounding as a number, then reformat
            var numValue = this.unformatNumber(value, decimalPlaces);

            var decimalFormatString = ".";
            for (var i = 0; i < decimalPlaces; i++) {
                decimalFormatString += "0";
            }
            result.Value = $.formatNumber(numValue.toString(), { format: "#,###" + decimalFormatString, locale: "us" });
            if (numValue < 0) {
                result.TextColor = "red";
                if (showNegativeInParens) {
                    result.Value = "(" + result.Value.replace("-", "") + ")";
                }
            }

            if (result.Value.charAt(0) === '.') {
                result.Value = "0" + result.Value;
            }
            return result;
        }

        unformatCellValue(cellVm: ExhibitGrid.ViewModel.ICellVm) {
            var unformattedVal = this.unformatNumber(cellVm.Value, cellVm.DecimalPlaces);
            if (unformattedVal) {
                cellVm.Value = unformattedVal.toString();
            }
        }

        unformatNumber(value: string, decimalPlaces: number) {
            if (!value) {
                return;
            }
            if (value.match(/[a-z]/i)) {
                // alphabet letters found, dont try to parse as a number
                return;
            }
            var unformattedValue = value;
            if (value.length >= 3 && value.charAt(0) == "(" && value.charAt(value.length - 1) == ")") {
                unformattedValue = "-" + value.substring(1, value.length - 1);
            }
            unformattedValue = $.parseNumber(unformattedValue, { format: "#,###.00000000", locale: "us" });
            var numValue = parseFloat(unformattedValue);
            //if it's not a number 
            if (isNaN(numValue)) {
                return;
            }
            if (decimalPlaces) {
                numValue = <number>math.round(numValue, decimalPlaces);
            }
            return numValue;
        }
        
        constructor() {
            this.exhibitModel = window['gridModel'].exhibit;
        }
    }

    var service = angular
        .module('app.model', [])
        .service('modelService', ModelService);
}


