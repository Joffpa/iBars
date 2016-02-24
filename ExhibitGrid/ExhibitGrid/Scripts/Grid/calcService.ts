/// <reference path="../typings/lodash/lodash.d.ts" />
'use strict';

module app.calc{

    export interface ICalcService {
        cellHasCalcs(gridCode: string, rowCode: string, colCode: string): boolean; 
        runCalcsForCell(gridCode: string, rowCode: string, colCode: string, newVal: number): void;               
    }

    export class CalcService implements ICalcService {

        ModelService: app.model.IModelService;

        constructor(modelService: app.model.IModelService) {
            this.ModelService = modelService;
        }

        cellHasCalcs(gridCode: string, rowCode: string, colCode: string) {     
        
            //TODO: Replace with actual framework
            //*************************************************************************************************
            if (colCode.indexOf('Col_') >= 0 && gridCode == 'MockGrid') {
                var colNum = parseInt(colCode.replace('Col_', ''));
                var totalRow = 'Row_1';             
                if (rowCode != totalRow || colNum % 3 == 0 || colNum % 3 == 1) {
                    return true;
                }
            }
            return false;
            //*************************************************************************************************
        }

        runCalcsForCell(gridCode: string, rowCode: string, colCode: string, newVal: number) {
        
            //TODO: Replace with actual framework
            //*************************************************************************************************
            //MockGrid Calcs
            if (colCode.indexOf('Col_') >= 0 && gridCode == 'MockGrid') {
                //NOTE: the calcs are hacked in to repeat a pattern of column level calcs every three columns.
                //There is also a total row calc
                var colNum = parseInt(colCode.replace('Col_', ''));
                var thisRow = rowCode;
                var totalRow = 'Row_1'; //the row that holds the total row result
                
                //col 0
                if (colNum % 3 == 0 && rowCode != totalRow) {
                    var nextCol = 'Col_' + (colNum + 1);
                    var nextNextCol = 'Col_' + (colNum + 2);
                    this.ModelService.updateCellValue('MockGrid', thisRow, nextNextCol, newVal + this.ModelService.getCellValue('MockGrid', thisRow, nextCol));
                } //col 1
                else if (colNum % 3 == 1 && rowCode != totalRow) {
                    var nextCol = 'Col_' + (colNum + 1);
                    var prevCol = 'Col_' + (colNum - 1);
                    this.ModelService.updateCellValue('MockGrid', thisRow, nextCol, newVal + this.ModelService.getCellValue('MockGrid', thisRow, prevCol));                    
                }
                if (rowCode != totalRow) {
                    this.ModelService.updateCellValue('MockGrid', totalRow, colCode, sumAllCellsInColForTotalRow('MockGrid', totalRow, colCode, this.ModelService));                    
                }
            }

            function sumAllCellsInColForTotalRow(gridCode: string, rowCode: string, colCode: string, modelService: app.model.IModelService) {
                var grid = modelService.getGridVm(gridCode);
                var sum = 0;
                _.forEach(grid.DataRows, function (row) {
                    if (row.RowCode != rowCode) {
                        var cell = _.where(row.Cells, { 'ColCode': colCode })[0];
                        if (cell) {
                            sum += cell['Value'];
                        }
                    }
                });
                return sum;
            }
            //*************************************************************************************************
        }       
    }

    var service = angular
        .module('app.calc', ['app.model'])
        .service('calcService', ['modelService', CalcService]);

}