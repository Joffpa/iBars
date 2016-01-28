
'use strict'

module app{

    export class ExhibitController {
        exhibitVm: app.model.ExhibitVm;
        modelService: app.model.IModelService;
        currentGridVm: app.model.GridVm;

        constructor(modelService: app.model.IModelService) {
            this.modelService = modelService;
            this.exhibitVm = modelService.getExhibitModel();
            this.currentGridVm = modelService.getGridModel('Grid_A');
            //console.log(this.curentGridVm);
        }                     
    }
    
    export class GridController {

        GridVm: app.model.ExhibitVm;
        ModelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.GridVm = $scope.gridVm;
            this.ModelService = modelService;
        }
        
    }

    export class RowController {

        RowVm: app.model.RowVm;
        ModelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
        }

        getRowCssClass() {
            if (this.RowVm.Type == app.model.RowType.Data)
                return 'data-row';
            else if (this.RowVm.Type == app.model.RowType.Total)
                return 'total-row';
            else if (this.RowVm.Type == app.model.RowType.Header)
                return 'header-row';
        }

        addRow() {
            alert('row added' + this.RowVm.RowCode);
        }
    }

    export class CellController {
        DataCellVm: app.model.DataCellVm;
        CalcService: app.calc.CalcService;

        constructor($scope, calcService: app.calc.CalcService) {
            this.DataCellVm = $scope.cell;
            this.CalcService = calcService;
        }

    }

    var exhibitApp = angular.module('app', ['app.model', 'app.directives', 'app.calc']);

    exhibitApp.controller('exhibitController', ['modelService', ExhibitController]);
}