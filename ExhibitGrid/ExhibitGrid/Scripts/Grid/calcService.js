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
            CalcService.prototype.runCellCalcs = function (cellVm) {
                var _this = this;
                //Run calc of child rows first
                var calcTargets = [];
                var thisRow = this.ModelService.getRowVm(cellVm.GridCode, cellVm.RowCode);
                if (thisRow.TotalParentRowCode) {
                    var parentRow = this.ModelService.getRowVm(cellVm.GridCode, thisRow.TotalParentRowCode);
                    var childRows = this.ModelService.getRowVms(cellVm.GridCode, parentRow.TotalChildrenRowCodes);
                    var equation = "";
                    _.each(childRows, function (childrow) {
                        var cell = _.find(childrow.Cells, { 'ColCode': cellVm.ColCode });
                        if (cell) {
                            equation += _this.ModelService.getCellValueForCalcFromVm(cell).toString() + "+";
                        }
                    });
                    if (equation && equation.length > 1) {
                        equation = equation.substring(0, equation.length - 1);
                    }
                    else {
                        equation = "0";
                    }
                    var targetCell = this.ModelService.getCellVm(cellVm.GridCode, parentRow.RowCode, cellVm.ColCode);
                    this.evaluateCalc(targetCell, equation);
                    if (targetCell.Calcs && targetCell.Calcs.length > 0) {
                        calcTargets.push(targetCell);
                    }
                }
                if (cellVm.Calcs && cellVm.Calcs.length > 0) {
                    var thisGridCalcTargets = _.filter(cellVm.Calcs, { 'TargetGridCode': cellVm.GridCode });
                    _.forEach(thisGridCalcTargets, function (calc) {
                        var equation = calc.Expression;
                        _.forEach(calc.Operands, function (operand) {
                            var coordinate = "{" + operand.GridCode + "." + operand.RowCode + "." + operand.ColCode + ".}";
                            var val = null;
                            if (operand.GridCode === cellVm.GridCode && operand.RowCode === cellVm.RowCode && operand.ColCode === cellVm.ColCode) {
                                val = _this.ModelService.getCellValueForCalcFromVm(cellVm);
                            }
                            else {
                                val = _this.ModelService.getCellValueForCalc(operand.GridCode, operand.RowCode, operand.ColCode);
                            }
                            if (val) {
                                var sVal = val.toString();
                            }
                            else {
                                var sVal = "0";
                            }
                            equation = equation.replace(coordinate, sVal);
                        });
                        var targetCell = _this.ModelService.getCellVm(calc.TargetGridCode, calc.TargetRowCode, calc.TargetColCode);
                        _this.evaluateCalc(targetCell, equation);
                        if (targetCell.Calcs && targetCell.Calcs.length > 0) {
                            calcTargets.push(targetCell);
                        }
                    });
                }
                if (calcTargets.length > 0) {
                    _.forEach(calcTargets, function (c) { _this.runCellCalcs(c); });
                }
            };
            CalcService.prototype.evaluateCalc = function (targetCell, equation) {
                var result;
                try {
                    result = math.eval(equation);
                    if (targetCell.DecimalPlaces) {
                        result = math.round(result, targetCell.DecimalPlaces);
                    }
                    this.ModelService.updateCellVmValue(targetCell, result);
                }
                catch (err) {
                    this.ModelService.setCellVmValueNA(targetCell);
                }
            };
            return CalcService;
        }());
        calc_1.CalcService = CalcService;
        angular.module('app.calc', ['app.model'])
            .service('calcService', ['modelService', CalcService]);
    })(calc = app.calc || (app.calc = {}));
})(app || (app = {}));
//# sourceMappingURL=calcService.js.map