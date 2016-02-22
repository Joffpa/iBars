
'use strict'

module app {

    export class GridController {

        GridVm: ExhibitGrid.ViewModel.IGridVm;
        ModelService: app.model.IModelService;

        constructor(modelService: app.model.IModelService) {
            this.ModelService = modelService;
            this.GridVm = this.ModelService.getGridVm('MockGrid');
        }
    }

    export class RowController {

        RowVm: ExhibitGrid.ViewModel.IRowVm;
        ModelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
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

        CellVm: ExhibitGrid.ViewModel.ICellVm;
        ModelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }

    } 

    export class NumericCellController {

        CellVm: ExhibitGrid.ViewModel.ICellVm;
        ModelService: app.model.IModelService;
        
        constructor($scope, modelService: app.model.IModelService) {
            //console.log($scope.cellVm);
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;

            if (this.CellVm.ColCode.indexOf('Col_') >= 0) {
                //NOTE: the calcs are hacked in to repeat a pattern of column level calcs every three columns.
                //There is also a total row calc
                var colNum = parseInt(this.CellVm.ColCode.replace('Col_', ''));
                var thisRow = this.CellVm.RowCode;
                var totalRow = 'Row_1'; //the row that holds the total row result

                //col 0
                if (colNum % 3 == 0 && this.CellVm.RowCode != totalRow) {
                    var nextCol = 'Col_' + (colNum + 1);
                    var nextNextCol = 'Col_' + (colNum + 2);
                    $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                        scope.cellCtrl.ModelService.updateCellValue('MockGrid', thisRow, nextNextCol, newVal + scope.cellCtrl.ModelService.getCellValue('MockGrid', thisRow, nextCol));

                    });

                } //col 1
                else if (colNum % 3 == 1 && this.CellVm.RowCode != totalRow) {
                    $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                        var nextCol = 'Col_' + (colNum + 1);
                        var prevCol = 'Col_' + (colNum - 1);
                        scope.cellCtrl.ModelService.updateCellValue('MockGrid', thisRow, nextCol, newVal + scope.cellCtrl.ModelService.getCellValue('MockGrid', thisRow, prevCol));
                    });
                }
                if (this.CellVm.RowCode != totalRow) {
                    $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                        scope.cellCtrl.ModelService.updateCellValue('MockGrid', totalRow, scope.cellVm.ColCode, scope.cellCtrl.ModelService.sumAllCellsInColForTotalRow('MockGrid', totalRow, scope.cellVm.ColCode));
                    });
                }  
            }          
        }        
    }
    export class PostItCellController {

        CellVm: ExhibitGrid.ViewModel.ICellVm;
        ModelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        
        editPostIt() {
            alert("Post it for cell: " + this.CellVm.RowCode + " " + this.CellVm.ColCode);
        }
    }

    export class NarrativeCellController {

        CellVm: ExhibitGrid.ViewModel.ICellVm;
        ModelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }

        editNarrative() {
            alert("Narrative for cell: " + this.CellVm.RowCode + " " + this.CellVm.ColCode);
            
        }
    }

    export class DropdownCellController {

        CellVm: ExhibitGrid.ViewModel.ICellVm;
        ModelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        
    }

    var exhibitApp = angular
        .module('app', ['app.model', 'app.directives'])    
        .controller('gridController', ['modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', RowController])
        .controller('textCellController', ['$scope', 'modelService', TextCellController]);

}