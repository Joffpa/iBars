/// <reference path="../typings/lodash/lodash.d.ts" />
/// <reference path="../typings/mathjs/mathjs.d.ts" />

'use strict';

module app.calc{

    export interface ICalcService {
        //cellHasCalcs(gridCode: string, rowCode: string, colCode: string): boolean; 
        runCellCalcs(cellVm: ExhibitGrid.ViewModel.ICellVm): void;               
    }

    export class CalcService implements ICalcService {

        ModelService: app.model.IModelService;

        constructor(modelService: app.model.IModelService) {
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

        runCellCalcs(cellVm: ExhibitGrid.ViewModel.ICellVm) {
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
                var thisGridCalcTargets = <ExhibitGrid.ViewModel.ICalcExpressionVm[]>_.filter(cellVm.Calcs, { 'TargetGridCode': cellVm.GridCode });
                _.forEach(thisGridCalcTargets, calc => {
                    var equation = calc.Expression;
                    _.forEach(calc.Operands, operand => {
                        var coordinate = "{" + operand.GridCode + "." + operand.RowCode + "." + operand.ColCode + ".}";
                        var val = null;
                        if (operand.GridCode === cellVm.GridCode && operand.RowCode === cellVm.RowCode && operand.ColCode === cellVm.ColCode) {
                            if (cellVm.Type == 'percent') {
                                val = cellVm.NumValue / 100;
                            } else {
                                val = cellVm.NumValue;
                            }
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
                    var result;
                    try {
                        result = <number>math.round(math.eval(equation), 2)
                        this.ModelService.updateCellValue(calc.TargetGridCode, calc.TargetRowCode, calc.TargetColCode, result);
                    } catch (err) {
                        this.ModelService.setCellValueNA(calc.TargetGridCode, calc.TargetRowCode, calc.TargetColCode);
                    } 
                    var targetCell = this.ModelService.getCellVm(calc.TargetGridCode, calc.TargetRowCode, calc.TargetColCode);
                    if (targetCell.Calcs && targetCell.Calcs.length > 0) {
                        calcTargets.push(targetCell);
                    }
                });

            }

            if (calcTargets.length > 0) {
                _.forEach(calcTargets, c => { this.runCellCalcs(c) });
            }
        }
    }

    angular.module('app.calc', ['app.model'])
        .service('calcService', ['modelService', CalcService]);

}