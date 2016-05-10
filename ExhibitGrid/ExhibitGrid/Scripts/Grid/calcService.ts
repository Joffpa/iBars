/// <reference path="../typings/lodash/lodash.d.ts" />
/// <reference path="../typings/mathjs/mathjs.d.ts" />

'use strict';

module app.calc{

    export interface ICalcService {
        runCellCalcs(cellVm: ExhibitGrid.ViewModel.ICellVm): void;
        evaluateTotalParentCellForColumn(parentRowVm: ExhibitGrid.ViewModel.IRowVm, colCode: string): ExhibitGrid.ViewModel.ICellVm;
        expandColCalcsForCell(colCalcs: ExhibitGrid.ViewModel.ICalcExpressionVm[], rowCode:string): ExhibitGrid.ViewModel.ICalcExpressionVm[];
    }

    export class CalcService implements ICalcService {

        ModelService: app.model.IModelService;

        constructor(modelService: app.model.IModelService) {
            this.ModelService = modelService;
        }

        runCellCalcs(cellVm: ExhibitGrid.ViewModel.ICellVm) {
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
                _.forEach(cellVm.Calcs, calcTemplate => {
                    var expression = calcTemplate.Expression;
                    _.forEach(calcTemplate.Operands, operand => {
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
                        expression = expression.replace(coordinate, sVal);
                    });
                    var targetCell = this.ModelService.getCellVm(calcTemplate.TargetGridCode, calcTemplate.TargetRowCode, calcTemplate.TargetColCode);
                    this.evaluateExpression(targetCell, expression, calcTemplate.UpdateContext);
                    if (targetCell.Calcs && targetCell.Calcs.length > 0 && calcTemplate.UpdateContext.toUpperCase() !== "DELTACHECK") {
                        calcTargets.push(targetCell);
                    }
                });
            }
            //Run Calcs for all the target cells there were just updated
            if (calcTargets.length > 0) {
                _.forEach(calcTargets, c => { this.runCellCalcs(c) });
            }
        }

        evaluateTotalParentCellForColumn(parentRowVm: ExhibitGrid.ViewModel.IRowVm, colCode: string) {
            var childRows = this.ModelService.getRowVms(parentRowVm.GridCode, parentRowVm.TotalChildrenRowCodes);

            var equation = "";
            _.each(childRows, childrow => {
                var cell = _.find(childrow.Cells, { 'ColCode': colCode });
                if (cell) {
                    var value = this.ModelService.getCellValueForCalcFromVm(cell);
                    if (value) {
                        equation += value.toString() + "+";
                    }
                }
            });
            if (equation && equation.length > 1) {
                equation = equation.substring(0, equation.length - 1);
            } else {
                equation = "0";
            }

            var targetCell = _.find(parentRowVm.Cells, cell => { return cell.ColCode == colCode; });

            this.evaluateExpression(targetCell, equation, 'CELLVALUE');
            if (targetCell.Calcs && targetCell.Calcs.length > 0) {
                return targetCell;
            }
            return null;
        }

        evaluateExpression(targetCell: ExhibitGrid.ViewModel.ICellVm, expression: string, updateContext: string) {
            var result;
            try {
                result = math.eval(expression);
                if (targetCell.DecimalPlaces) {
                    result = <number>math.round(result, targetCell.DecimalPlaces);
                }
            } catch (err) {
                //Something went wrong (e.g. divide by zero, or user entered alpha chars in input), throw out the result
                result = null;
            }
            if (updateContext.toUpperCase() === "CELLVALUE") {
                if (result != null) {
                    this.ModelService.updateCellVmValue(targetCell, result.toString());
                } else {
                    this.ModelService.updateCellVmValueNA(targetCell);
                }
            } else if (updateContext.toUpperCase() === "DELTACHECK") {
                this.ModelService.updateCellVmDeltaCheck(targetCell, result);
            }
        }

        expandColCalcsForCell(colCalcs: ExhibitGrid.ViewModel.ICalcExpressionVm[], rowCode: string) {
            var expandedColCalcs = [];
            _.forEach(colCalcs, colCalc => {
                var expandedCalc: ExhibitGrid.ViewModel.ICalcExpressionVm = {
                    CalcExpressionId: colCalc.CalcExpressionId,
                    TargetGridCode: colCalc.TargetGridCode,
                    TargetRowCode: rowCode,
                    TargetColCode: colCalc.TargetColCode,
                    Expression: this.expandColCalcExpression(colCalc.Expression, rowCode),
                    UpdateContext: colCalc.UpdateContext,
                    Operands: this.expandColCalcOperands(colCalc.Operands, rowCode)
                }
                expandedColCalcs.push(expandedCalc);
            });
            return expandedColCalcs;
        }

        expandColCalcExpression(expression: string, rowCode: string) {
            var splitExpression = expression.split('.');
            var expandedExpression = "";
            _.forEach(splitExpression, str => {
                if (str) {
                    expandedExpression += str + ".";
                } else {
                    expandedExpression += rowCode + ".";
                }
            });
            //remove trailing period
            expandedExpression = expandedExpression.substring(0, expandedExpression.length - 1);
            return expandedExpression;
        } 

        expandColCalcOperands(operands: ExhibitGrid.ViewModel.ICalcOperandVm[], rowCode: string) {
            var expandedOperands = [];
            _.forEach(operands, operand => {
                var expandedOperand: ExhibitGrid.ViewModel.ICalcOperandVm = {
                    GridCode: operand.GridCode,
                    RowCode: rowCode,
                    ColCode: operand.ColCode
                }
                expandedOperands.push(expandedOperand)
            });
            return expandedOperands;
        }

    }

    angular.module('app.calc', ['app.model'])
        .service('calcService', ['modelService', CalcService]);

}