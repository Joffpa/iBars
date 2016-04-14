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
            //cellHasCalcs(gridCode: string, rowCode: string, colCode: string) {     
            //    //TODO: Replace with actual framework
            //    //*************************************************************************************************
            //    //Mini Op-5
            //    if (gridCode == 'MiniOp5'){
            //        if (colCode == 'BY1Prog') {
            //            if (rowCode == 'Row_1_Sub_3' || rowCode == 'Row_2_Sub_3' || rowCode == 'Row_1_Sub_4' || rowCode == 'Row_2_Sub_4') {
            //                return true;
            //            }
            //        }
            //    }
            //    //Mock Grid
            //    if (gridCode == 'MockGrid'){
            //        if (colCode.indexOf('Col_') >= 0 && gridCode == 'MockGrid') {
            //            var colNum = parseInt(colCode.replace('Col_', ''));
            //            var totalRow = 'Row_1';
            //            if (rowCode != totalRow || colNum % 3 == 0 || colNum % 3 == 1) {
            //                return true;
            //            }
            //        }
            //        return false;
            //    }
            //    //*************************************************************************************************
            //}
            CalcService.prototype.runCellCalcs = function (cellVm) {
                var _this = this;
                //Run calc of child rows first
                var calcTargets = [];
                //if (cellVm.ParentRowCode) {
                //    var calc = this.ModelService.getParentRowCalcForColumn(cellVm.GridCode, cellVm.ParentRowCode, cellVm.ColCode);
                //    var result = <number>math.round(math.eval(calc), 2);
                //    this.ModelService.updateCellValue(cellVm.GridCode, cellVm.ParentRowCode, cellVm.ColCode, result);
                //    var targetCell = this.ModelService.getCellVm(cellVm.GridCode, cellVm.ParentRowCode, cellVm.ColCode);
                //    if (targetCell.Calcs && targetCell.Calcs.length > 0) {
                //        calcTargets.push(targetCell);
                //    }
                //}
                if (cellVm.Calcs && cellVm.Calcs.length > 0) {
                    var thisGridCalcTargets = _.filter(cellVm.Calcs, { 'TargetGridCode': cellVm.GridCode });
                    _.forEach(thisGridCalcTargets, function (calc) {
                        var equation = calc.Expression;
                        _.forEach(calc.Operands, function (operand) {
                            var coordinate = "{" + operand.GridCode + "." + operand.RowCode + "." + operand.ColCode + ".}";
                            var val = null;
                            if (operand.GridCode === cellVm.GridCode && operand.RowCode === cellVm.RowCode && operand.ColCode === cellVm.ColCode) {
                                if (cellVm.Type == 'percent') {
                                    val = cellVm.NumValue / 100;
                                }
                                else {
                                    val = cellVm.NumValue;
                                }
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
                        var result;
                        try {
                            result = math.round(math.eval(equation), 2);
                            _this.ModelService.updateCellValue(calc.TargetGridCode, calc.TargetRowCode, calc.TargetColCode, result);
                        }
                        catch (err) {
                            _this.ModelService.setCellValueNA(calc.TargetGridCode, calc.TargetRowCode, calc.TargetColCode);
                        }
                        var targetCell = _this.ModelService.getCellVm(calc.TargetGridCode, calc.TargetRowCode, calc.TargetColCode);
                        if (targetCell.Calcs && targetCell.Calcs.length > 0) {
                            calcTargets.push(targetCell);
                        }
                    });
                }
                if (calcTargets.length > 0) {
                    _.forEach(calcTargets, function (c) { _this.runCellCalcs(c); });
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