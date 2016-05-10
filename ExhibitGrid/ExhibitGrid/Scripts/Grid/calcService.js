/// <reference path="../typings/lodash/lodash.d.ts" />
/// <reference path="../typings/mathjs/mathjs.d.ts" />
'use strict';
var app;
(function (app) {
    var calc;
    (function (calc) {
        var CalcService = (function () {
            function CalcService(modelService) {
                this.ModelService = modelService;
            }
            CalcService.prototype.runCellCalcs = function (cellVm) {
                var _this = this;
                //calcTargets hold the collection of cells that are updated from this 
                var calcTargets = [];
                //Run calc of child rows first
                var thisRow = this.ModelService.getRowVm(cellVm.GridCode, cellVm.RowCode);
                if (thisRow.TotalParentRowCode) {
                    var parentRow = this.ModelService.getRowVm(cellVm.GridCode, thisRow.TotalParentRowCode);
                    var targetCell = this.evaluateTotalParentCellForColumn(parentRow, cellVm.ColCode);
                    if (targetCell) {
                        calcTargets.push(targetCell);
                    }
                }
                if (cellVm.Calcs && cellVm.Calcs.length > 0) {
                    _.forEach(cellVm.Calcs, function (calcTemplate) {
                        var expression = calcTemplate.Expression;
                        _.forEach(calcTemplate.Operands, function (operand) {
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
                            expression = expression.replace(coordinate, sVal);
                        });
                        var targetCell = _this.ModelService.getCellVm(calcTemplate.TargetGridCode, calcTemplate.TargetRowCode, calcTemplate.TargetColCode);
                        _this.evaluateExpression(targetCell, expression, calcTemplate.UpdateContext);
                        if (targetCell.Calcs && targetCell.Calcs.length > 0 && calcTemplate.UpdateContext.toUpperCase() !== "DELTACHECK") {
                            calcTargets.push(targetCell);
                        }
                    });
                }
                //Run Calcs for all the target cells there were just updated
                if (calcTargets.length > 0) {
                    _.forEach(calcTargets, function (c) { _this.runCellCalcs(c); });
                }
            };
            CalcService.prototype.evaluateTotalParentCellForColumn = function (parentRowVm, colCode) {
                var _this = this;
                var childRows = this.ModelService.getRowVms(parentRowVm.GridCode, parentRowVm.TotalChildrenRowCodes);
                var equation = "";
                _.each(childRows, function (childrow) {
                    var cell = _.find(childrow.Cells, { 'ColCode': colCode });
                    if (cell) {
                        var value = _this.ModelService.getCellValueForCalcFromVm(cell);
                        if (value) {
                            equation += value.toString() + "+";
                        }
                    }
                });
                if (equation && equation.length > 1) {
                    equation = equation.substring(0, equation.length - 1);
                }
                else {
                    equation = "0";
                }
                var targetCell = _.find(parentRowVm.Cells, function (cell) { return cell.ColCode == colCode; });
                this.evaluateExpression(targetCell, equation, 'CELLVALUE');
                if (targetCell.Calcs && targetCell.Calcs.length > 0) {
                    return targetCell;
                }
                return null;
            };
            CalcService.prototype.evaluateExpression = function (targetCell, expression, updateContext) {
                var result;
                try {
                    result = math.eval(expression);
                    if (targetCell.DecimalPlaces) {
                        result = math.round(result, targetCell.DecimalPlaces);
                    }
                }
                catch (err) {
                    //Something went wrong (e.g. divide by zero, or user entered alpha chars in input), throw out the result
                    result = null;
                }
                if (updateContext.toUpperCase() === "CELLVALUE") {
                    if (result != null) {
                        this.ModelService.updateCellVmValue(targetCell, result.toString());
                    }
                    else {
                        this.ModelService.updateCellVmValueNA(targetCell);
                    }
                }
                else if (updateContext.toUpperCase() === "DELTACHECK") {
                    this.ModelService.updateCellVmDeltaCheck(targetCell, result);
                }
            };
            CalcService.prototype.expandColCalcsForCell = function (colCalcs, rowCode) {
                var _this = this;
                var expandedColCalcs = [];
                _.forEach(colCalcs, function (colCalc) {
                    var expandedCalc = {
                        CalcExpressionId: colCalc.CalcExpressionId,
                        TargetGridCode: colCalc.TargetGridCode,
                        TargetRowCode: rowCode,
                        TargetColCode: colCalc.TargetColCode,
                        Expression: _this.expandColCalcExpression(colCalc.Expression, rowCode),
                        UpdateContext: colCalc.UpdateContext,
                        Operands: _this.expandColCalcOperands(colCalc.Operands, rowCode)
                    };
                    expandedColCalcs.push(expandedCalc);
                });
                return expandedColCalcs;
            };
            CalcService.prototype.expandColCalcExpression = function (expression, rowCode) {
                var splitExpression = expression.split('.');
                var expandedExpression = "";
                _.forEach(splitExpression, function (str) {
                    if (str) {
                        expandedExpression += str + ".";
                    }
                    else {
                        expandedExpression += rowCode + ".";
                    }
                });
                //remove trailing period
                expandedExpression = expandedExpression.substring(0, expandedExpression.length - 1);
                return expandedExpression;
            };
            CalcService.prototype.expandColCalcOperands = function (operands, rowCode) {
                var expandedOperands = [];
                _.forEach(operands, function (operand) {
                    var expandedOperand = {
                        GridCode: operand.GridCode,
                        RowCode: rowCode,
                        ColCode: operand.ColCode
                    };
                    expandedOperands.push(expandedOperand);
                });
                return expandedOperands;
            };
            return CalcService;
        }());
        calc.CalcService = CalcService;
        angular.module('app.calc', ['app.model'])
            .service('calcService', ['modelService', CalcService]);
    })(calc = app.calc || (app.calc = {}));
})(app || (app = {}));
//# sourceMappingURL=calcService.js.map