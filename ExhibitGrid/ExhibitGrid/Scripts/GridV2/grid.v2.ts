﻿
'use strict'

module app.v2 {

    export class GridController {

        GridVm: ExhibitGrid.ViewModel.v2.IGridVm;
        ModelService: app.v2.model.IModelService;

        constructor(modelService: app.v2.model.IModelService) {
            this.ModelService = modelService;
            this.GridVm = this.ModelService.getGridVm('MockGrid');
        }
    }

    export class RowController {

        RowVm: ExhibitGrid.ViewModel.v2.IRowVm;
        ModelService: app.v2.model.IModelService;

        constructor($scope, modelService: app.v2.model.IModelService) {
            console.log($scope.row);
            this.RowVm = $scope.row;
            this.ModelService = modelService;
        }

        addRow() {
            alert('row added: ' + this.RowVm.RowCode);
        }
        deleteRow() {
            alert('row deleted: ' + this.RowVm.RowCode);
        }
    }

    export class TextCellController {

        CellVm: ExhibitGrid.ViewModel.v2.ICellVm;
        ModelService: app.v2.model.IModelService;

        constructor($scope, modelService: app.v2.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }

    } 

    export class NumericCellController {

        CellVm: ExhibitGrid.ViewModel.v2.ICellVm;
        ModelService: app.v2.model.IModelService;
        
        constructor($scope, modelService: app.v2.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;

            //NOTE: the calcs are hacked in to repeat a pattern of column level calcs every three columns.
            //There is also a total row calc
            var colNum = parseInt(this.CellVm.ColCode.replace('Col_', ''));
            var thisRow = this.CellVm.RowCode;
            var totalRow = 'Row_1'; //the row that holds the total row result
            var calcs = "";

            //col 0
            if (colNum % 3 == 0 && this.CellVm.RowCode != totalRow) {
                calcs += "Col Calc (1st col),  ";
                var nextCol = 'Col_' + (colNum + 1);
                var nextNextCol = 'Col_' + (colNum + 2);
                $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                    scope.cellCtrl.ModelService.updateCellValue('MockGrid', thisRow, nextNextCol, newVal + scope.cellCtrl.ModelService.getCellValue('MockGrid', thisRow, nextCol));

                });

            } //col 1
            else if (colNum % 3 == 1 && this.CellVm.RowCode != totalRow) {
                calcs += "Col Calc (2nd col),  ";
                $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                    var nextCol = 'Col_' + (colNum + 1);
                    var prevCol = 'Col_' + (colNum - 1);
                    scope.cellCtrl.ModelService.updateCellValue('MockGrid', thisRow, nextCol, newVal + scope.cellCtrl.ModelService.getCellValue('MockGrid', thisRow, prevCol));
                });
            } 
            if (this.CellVm.RowCode != totalRow) {
                calcs += "Total Row Calc";
                $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                    scope.cellCtrl.ModelService.updateCellValue('MockGrid', totalRow, scope.cellVm.ColCode, scope.cellCtrl.ModelService.sumAllCellsInColForTotalRow('MockGrid', totalRow, scope.cellVm.ColCode));
                });
            }
            //console.log(this.CellVm.RowCode + " " + this.CellVm.ColCode + ": " + calcs);
            
        }        
    }
    export class PostItCellController {

        CellVm: ExhibitGrid.ViewModel.v2.ICellVm;
        ModelService: app.v2.model.IModelService;

        constructor($scope, modelService: app.v2.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        
        editPostIt() {
            alert("Post it for cell: " + this.CellVm.RowCode + " " + this.CellVm.ColCode);
        }
    }

    export class NarrativeCellController {

        CellVm: ExhibitGrid.ViewModel.v2.ICellVm;
        ModelService: app.v2.model.IModelService;

        constructor($scope, modelService: app.v2.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }

        editNarrative() {
            alert("Narrative for cell: " + this.CellVm.RowCode + " " + this.CellVm.ColCode);
            
        }
    }

    export class BlankCellController {

        CellVm: ExhibitGrid.ViewModel.v2.ICellVm;
        ModelService: app.v2.model.IModelService;

        constructor($scope, modelService: app.v2.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }        
    }

    var exhibitApp = angular
        .module('app.v2', ['app.v2.model', 'app.v2.directives'])    
        .controller('gridController', ['modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', RowController])
        .controller('textCellController', ['$scope', 'modelService', TextCellController]);

}