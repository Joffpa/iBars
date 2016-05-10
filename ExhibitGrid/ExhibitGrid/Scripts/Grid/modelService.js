/// <reference path="../typings/lodash/lodash.d.ts" />
'use strict';
var app;
(function (app) {
    var model;
    (function (model) {
        var ExhibitVm = (function () {
            function ExhibitVm() {
                this.Grids = new Array();
            }
            return ExhibitVm;
        }());
        model.ExhibitVm = ExhibitVm;
        var GridVm = (function () {
            function GridVm(GridCode) {
                this.GridCode = GridCode;
            }
            return GridVm;
        }());
        model.GridVm = GridVm;
        var RowVm = (function () {
            function RowVm(RowCode, Class, Text, CanCollapse, CanSelect, IsSelected) {
                this.RowCode = RowCode;
                this.Class = Class;
            }
            return RowVm;
        }());
        model.RowVm = RowVm;
        var CellVm = (function () {
            function CellVm(Order, Type, RowCode, ColCode, CanAddNarrative, HasNarrative) {
                this.RowCode = RowCode;
                this.ColCode = ColCode;
            }
            return CellVm;
        }());
        model.CellVm = CellVm;
        var CalcExpressionVm = (function () {
            function CalcExpressionVm() {
            }
            return CalcExpressionVm;
        }());
        model.CalcExpressionVm = CalcExpressionVm;
        var CalcOperandVm = (function () {
            function CalcOperandVm() {
            }
            return CalcOperandVm;
        }());
        model.CalcOperandVm = CalcOperandVm;
        var ModelService = (function () {
            function ModelService() {
                this.exhibitModel = window['gridModel'].exhibit;
            }
            ModelService.prototype.addGridVm = function (gridVm) {
                this.exhibitModel.Grids.push(gridVm);
            };
            ModelService.prototype.getExhibitVm = function () {
                return this.exhibitModel;
            };
            ModelService.prototype.getGridVm = function (gridCode) {
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                return grid;
            };
            ModelService.prototype.getRowVm = function (gridCode, rowCode) {
                var grid = this.getGridVm(gridCode);
                var row = _.find(grid.Rows, { 'RowCode': rowCode });
                return row;
            };
            ModelService.prototype.getRowVms = function (gridCode, rowCodes) {
                var grid = this.getGridVm(gridCode);
                return _.filter(grid.Rows, function (r) { return _.includes(rowCodes, r.RowCode); });
            };
            ModelService.prototype.getChildRowVms = function (parentRow) {
                var grid = this.getGridVm(parentRow.GridCode);
                var rows = _.filter(grid.Rows, function (row) {
                    var isChild = _.includes(parentRow.TotalChildrenRowCodes, row.RowCode);
                    return isChild;
                });
                return rows;
            };
            ModelService.prototype.getCellVm = function (gridCode, rowCode, colCode) {
                var row = this.getRowVm(gridCode, rowCode);
                var cell = _.find(row.Cells, { 'ColCode': colCode });
                return cell;
            };
            ModelService.prototype.updateCellValue = function (gridCode, rowCode, colCode, value) {
                var cell = this.getCellVm(gridCode, rowCode, colCode);
                this.updateCellVmValue(cell, value);
            };
            ModelService.prototype.updateCellVmValue = function (cellVm, value) {
                var decimals;
                if (cellVm.DecimalPlaces) {
                    decimals = cellVm.DecimalPlaces;
                }
                else {
                    decimals = 2;
                }
                var grid = this.getGridVm(cellVm.GridCode);
                var formatResult = this.formatNumber(value, decimals, grid.ShowNegativeNumsInParens);
                cellVm.Value = formatResult.Value;
                //cellVm.TextColor = formatResult.TextColor;
            };
            ModelService.prototype.updateCellVmValueNA = function (cellVm) {
                cellVm.Value = "N/A";
                //cellVm.TextColor = "";
            };
            ModelService.prototype.updateCellVmDeltaCheck = function (cellVm, value) {
                if (value !== null) {
                    var grid = this.getGridVm(cellVm.GridCode);
                    var formattedVal = this.formatNumber(value.toString(), cellVm.DecimalPlaces, grid.ShowNegativeNumsInParens);
                    if (value < 0) {
                        cellVm.TextColor = "red";
                        cellVm.HoverAddition = "<div class='delta-negative'>" + formattedVal.Value + "</div>";
                    }
                    else if (value > 0) {
                        cellVm.TextColor = "red";
                        cellVm.HoverAddition = "<div class='delta-positive'>" + formattedVal.Value + "</div>";
                    }
                    else {
                        cellVm.TextColor = "blue";
                        cellVm.HoverAddition = "<div class='delta-balanced'>In Balance</div>";
                    }
                }
                else {
                    cellVm.TextColor = "red";
                    cellVm.HoverAddition = "<div class='delta-negative'>N/A</div>";
                }
            };
            ModelService.prototype.getCellValueForCalc = function (gridCode, rowCode, colCode) {
                var cellVm = this.getCellVm(gridCode, rowCode, colCode);
                return this.getCellValueForCalcFromVm(cellVm);
            };
            ModelService.prototype.getCellValueForCalcFromVm = function (cellVm) {
                var numValue = this.unformatNumber(cellVm.Value, cellVm.DecimalPlaces);
                if (numValue && cellVm.Type == 'percent') {
                    return numValue / 100;
                }
                return numValue;
            };
            ModelService.prototype.getCellStyle = function (cellVm) {
                var style = {};
                style['text-align'] = cellVm.Alignment;
                if (cellVm.Width) {
                    style['width'] = cellVm.Width;
                }
                else {
                    style['width'] = '100%';
                }
                if (cellVm.TextColor) {
                    style['color'] = cellVm.TextColor;
                    style['text-decoration-color'] = cellVm.TextColor;
                }
                return style;
            };
            ModelService.prototype.getGridColCalcs = function (gridCode) {
                var grid = this.getGridVm(gridCode);
                return grid.ColCalcs;
            };
            ModelService.prototype.collapseChildren = function (parentRow, collapse) {
                var _this = this;
                parentRow.ChildrenAreCollapsed = collapse;
                parentRow.CollapseableChildrenRowCodes.forEach(function (childRowCode) {
                    var childRow = _this.getRowVm(parentRow.GridCode, childRowCode);
                    childRow.IsCollapsed = collapse;
                });
            };
            ModelService.prototype.formatCellValue = function (cellVm) {
                var decimals;
                if (cellVm.DecimalPlaces) {
                    decimals = cellVm.DecimalPlaces;
                }
                else {
                    decimals = 2;
                }
                var grid = this.getGridVm(cellVm.GridCode);
                var formatResult = this.formatNumber(cellVm.Value, decimals, grid.ShowNegativeNumsInParens);
                cellVm.Value = formatResult.Value;
                //cellVm.TextColor = formatResult.TextColor;
            };
            ModelService.prototype.formatNumber = function (value, decimalPlaces, showNegativeInParens) {
                var result = {
                    Value: null,
                    TextColor: ""
                };
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
            };
            ModelService.prototype.unformatCellValue = function (cellVm) {
                var unformattedVal = this.unformatNumber(cellVm.Value, cellVm.DecimalPlaces);
                if (unformattedVal) {
                    cellVm.Value = unformattedVal.toString();
                }
            };
            ModelService.prototype.unformatNumber = function (value, decimalPlaces) {
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
                    numValue = math.round(numValue, decimalPlaces);
                }
                return numValue;
            };
            return ModelService;
        }());
        model.ModelService = ModelService;
        var service = angular
            .module('app.model', [])
            .service('modelService', ModelService);
    })(model = app.model || (app.model = {}));
})(app || (app = {}));
//# sourceMappingURL=modelService.js.map