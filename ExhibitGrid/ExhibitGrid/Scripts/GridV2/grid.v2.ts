
'use strict'

module app.v2 {

    export class GridController {

        GridVm: ExhibitGrid.ViewModel.v2.IGridVm;
        ModelService: app.v2.model.IModelService;

        constructor(modelService: app.v2.model.IModelService) {
            this.GridVm = modelService.getGridVm('MockGrid');
            console.log(this.GridVm);
            this.ModelService = modelService;
        }
    }

    export class RowController {

        RowVm: app.v2.model.RowVm;
        ModelService: app.v2.model.IModelService;

        constructor($scope, modelService: app.v2.model.IModelService) {
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
    
    //export class CellController {
    //    DataCellVm: app.v2.model.DataCellVm;
    //    CalcService: app.v2.calc.CalcService;

    //    constructor($scope, calcService: app.calc.CalcService) {
    //        this.DataCellVm = $scope.cell;
    //        this.CalcService = calcService;
    //    }
    //}

    var exhibitApp = angular
        .module('app.v2', ['app.v2.model', 'app.v2.directives'])    
        .controller('gridController', ['modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', RowController]);

}