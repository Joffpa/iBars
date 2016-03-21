/// <reference path="../typings/lodash/lodash.d.ts" />
/// <reference path="../typings/mathjs/mathjs.d.ts" />
'use strict';
var app;
(function (app) {
    var calc;
    (function (calc_1) {
        var CalcService = (function () {
            function CalcService(modelService) {
                this.ModelService = modelService;
            }
            CalcService.prototype.cellHasCalcs = function (gridCode, rowCode, colCode) {
                //TODO: Replace with actual framework
                //*************************************************************************************************
                //Mini Op-5
                if (gridCode == 'MiniOp5') {
                    if (colCode == 'BY1Prog') {
                        if (rowCode == 'Row_1_Sub_3' || rowCode == 'Row_2_Sub_3' || rowCode == 'Row_1_Sub_4' || rowCode == 'Row_2_Sub_4') {
                            return true;
                        }
                    }
                }
                //Mock Grid
                if (gridCode == 'MockGrid') {
                    if (colCode.indexOf('Col_') >= 0 && gridCode == 'MockGrid') {
                        var colNum = parseInt(colCode.replace('Col_', ''));
                        var totalRow = 'Row_1';
                        if (rowCode != totalRow || colNum % 3 == 0 || colNum % 3 == 1) {
                            return true;
                        }
                    }
                    return false;
                }
                //*************************************************************************************************
            };
            CalcService.prototype.runCalcsForCell = function (gridCode, rowCode, colCode, newVal) {
                //TODO: Replace with actual framework
                //*************************************************************************************************
                //Mini Op5
                if (gridCode == 'MiniOp5') {
                    if (colCode == 'BY1Prog') {
                        if (rowCode == 'Row_1_Sub_3' || rowCode == 'Row_2_Sub_3') {
                            var row1By1Val = this.ModelService.getCellValue(gridCode, 'Row_1_Sub_3', 'BY1Prog');
                            var row2By1Val = this.ModelService.getCellValue(gridCode, 'Row_2_Sub_3', 'BY1Prog');
                            var sum = row1By1Val + row2By1Val;
                            this.ModelService.updateCellValue(gridCode, 'Total_Row_Sub_3', 'BY1Prog', sum);
                        }
                        if (rowCode == 'Row_1_Sub_4' || rowCode == 'Row_2_Sub_4') {
                            var row1By1Val = this.ModelService.getCellValue(gridCode, 'Row_1_Sub_4', 'BY1Prog');
                            var row2By1Val = this.ModelService.getCellValue(gridCode, 'Row_2_Sub_4', 'BY1Prog');
                            var sum = row1By1Val + row2By1Val;
                            this.ModelService.updateCellValue(gridCode, 'Total_Row_Sub_4', 'BY1Prog', sum);
                        }
                    }
                }
                //MockGrid Calcs
                if (colCode.indexOf('Col_') >= 0 && gridCode === 'MockGrid') {
                    //NOTE: the calcs are hacked in to repeat a pattern of column level calcs every three columns.
                    //There is also a total row calc
                    var colNum = parseInt(colCode.replace('Col_', ''));
                    var thisRow = rowCode;
                    var totalRow = 'Row_1'; //the row that holds the total row result
                    //col 0
                    var nextCol;
                    if (colNum % 3 === 0 && rowCode !== totalRow) {
                        nextCol = 'Col_' + (colNum + 1);
                        var nextNextCol = 'Col_' + (colNum + 2);
                        var updateVal = newVal + this.ModelService.getCellValue('MockGrid', thisRow, nextCol);
                        this.ModelService.updateCellValue('MockGrid', thisRow, nextNextCol, updateVal);
                    } //col 1
                    else if (colNum % 3 === 1 && rowCode !== totalRow) {
                        nextCol = 'Col_' + (colNum + 1);
                        var prevCol = 'Col_' + (colNum - 1);
                        this.ModelService.updateCellValue('MockGrid', thisRow, nextCol, newVal + this.ModelService.getCellValue('MockGrid', thisRow, prevCol));
                    }
                    if (rowCode != totalRow) {
                        this.ModelService.updateCellValue('MockGrid', totalRow, colCode, sumAllCellsInColForTotalRow('MockGrid', totalRow, colCode, this.ModelService));
                    }
                }
                function sumAllCellsInColForTotalRow(gridCode, rowCode, colCode, modelService) {
                    var grid = modelService.getGridVm(gridCode);
                    var sum = 0;
                    _.forEach(grid.DataRows, function (row) {
                        if (row.RowCode !== rowCode) {
                            var cell = _.where(row.Cells, { 'ColCode': colCode })[0];
                            if (cell) {
                                sum += cell['NumValue'];
                            }
                        }
                    });
                    return sum;
                }
                //*************************************************************************************************
            };
            //Actual framework!
            CalcService.prototype.runCellCalcs = function (cellVm, newVal) {
                var _this = this;
                //Run calc of child rows first
                if (cellVm.ParentRowCode) {
                    var calc = this.ModelService.getParentRowCalcForColumn(cellVm.GridCode, cellVm.ParentRowCode, cellVm.ColCode);
                    var result = math.round(math.eval(calc), 2);
                    this.ModelService.updateCellValue(cellVm.GridCode, cellVm.ParentRowCode, cellVm.ColCode, result);
                }
                if (cellVm.Calcs && cellVm.Calcs.length > 0) {
                    var thisGridCalcTargets = _.filter(cellVm.Calcs, { 'TargetGridCode': cellVm.GridCode });
                    _.forEach(thisGridCalcTargets, function (calc) {
                        var equation = calc.Expression;
                        _.forEach(calc.Operands, function (operand) {
                            var coordinate = "{" + operand.GridCode + "." + operand.RowCode + "." + operand.ColCode + ".}";
                            var val = _this.ModelService.getCellValue(operand.GridCode, operand.RowCode, operand.ColCode);
                            if (val) {
                                var sVal = val.toString();
                            }
                            else {
                                var sVal = "0";
                            }
                            equation = equation.replace(coordinate, sVal);
                        });
                        _this.ModelService.updateCellValue(calc.TargetGridCode, calc.TargetRowCode, calc.TargetColCode, math.round(math.eval(equation), 2));
                    });
                }
            };
            return CalcService;
        })();
        calc_1.CalcService = CalcService;
        angular.module('app.calc', ['app.model'])
            .service('calcService', ['modelService', CalcService]);
    })(calc = app.calc || (app.calc = {}));
})(app || (app = {}));
//# sourceMappingURL=calcService.js.map