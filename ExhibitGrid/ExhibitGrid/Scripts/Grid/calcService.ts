/// <reference path="../typings/lodash/lodash.d.ts" />
/// <reference path="../typings/mathjs/mathjs.d.ts" />

'use strict';

module app.calc{

    export interface ICalcService {
        runCellCalcs(cellVm: ExhibitGrid.ViewModel.ICellVm): void;               
    }

    export class CalcService implements ICalcService {

        ModelService: app.model.IModelService;

        constructor(modelService: app.model.IModelService) {
            this.ModelService = modelService;
        }

        runCellCalcs(cellVm: ExhibitGrid.ViewModel.ICellVm) {
            //Run calc of child rows first
            var calcTargets = [];
            var thisRow = this.ModelService.getRowVm(cellVm.GridCode, cellVm.RowCode);
            if (thisRow.TotalParentRowCode) {
                var parentRow = this.ModelService.getRowVm(cellVm.GridCode, thisRow.TotalParentRowCode);
                var childRows = this.ModelService.getRowVms(cellVm.GridCode, parentRow.TotalChildrenRowCodes);

                var equation = "";
                _.each(childRows, childrow => {
                    var cell = _.find(childrow.Cells, { 'ColCode': cellVm.ColCode });
                    if (cell) {
                        equation += this.ModelService.getCellValueForCalcFromVm(cell).toString() + "+";
                    }
                });
                if (equation && equation.length > 1) {
                    equation = equation.substring(0, equation.length - 1);
                } else {
                    equation = "0";
                }
                var targetCell = this.ModelService.getCellVm(cellVm.GridCode, parentRow.RowCode, cellVm.ColCode);
                this.evaluateCalc(targetCell, equation);
                if (targetCell.Calcs && targetCell.Calcs.length > 0) {
                    calcTargets.push(targetCell);
                }
            }
            if (cellVm.Calcs && cellVm.Calcs.length > 0) {
                var thisGridCalcTargets = <ExhibitGrid.ViewModel.ICalcExpressionVm[]>_.filter(cellVm.Calcs, { 'TargetGridCode': cellVm.GridCode });
                _.forEach(thisGridCalcTargets, calc => {
                    var equation = calc.Expression;
                    _.forEach(calc.Operands, operand => {
                        var coordinate = "{" + operand.GridCode + "." + operand.RowCode + "." + operand.ColCode + ".}";
                        var val = null;
                        if (operand.GridCode === cellVm.GridCode && operand.RowCode === cellVm.RowCode && operand.ColCode === cellVm.ColCode) {
                            val = this.ModelService.getCellValueForCalcFromVm(cellVm);
                        }
                        else {
                            val = this.ModelService.getCellValueForCalc(operand.GridCode, operand.RowCode, operand.ColCode);
                        }
                        if (val) {
                            var sVal = <string>val.toString();
                        } else {
                            var sVal = "0";
                        }
                        equation = equation.replace(coordinate, sVal);
                    });
                    var targetCell = this.ModelService.getCellVm(calc.TargetGridCode, calc.TargetRowCode, calc.TargetColCode);
                    this.evaluateCalc(targetCell, equation);
                    if (targetCell.Calcs && targetCell.Calcs.length > 0) {
                        calcTargets.push(targetCell);
                    }
                });
            }
            if (calcTargets.length > 0) {
                _.forEach(calcTargets, c => { this.runCellCalcs(c) });
            }
        }

        evaluateCalc(targetCell: ExhibitGrid.ViewModel.ICellVm, equation: string) {
            var result;
            try {
                result = math.eval(equation);
                if (targetCell.DecimalPlaces) {
                    result = <number>math.round(result, targetCell.DecimalPlaces);
                }
                this.ModelService.updateCellVmValue(targetCell, result);
            } catch (err) {
                this.ModelService.setCellVmValueNA(targetCell);
            } 
        }

    }

    angular.module('app.calc', ['app.model'])
        .service('calcService', ['modelService', CalcService]);

}