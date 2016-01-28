
'use strict'

module app{

    export class ExhibitController {
        exhibitVm: app.model.ExhibitVm;
        modelService: app.model.IModelService;
        currentGridVm: app.model.GridVm;

        constructor(modelService: app.model.IModelService) {
            this.modelService = modelService;
            this.exhibitVm = modelService.getExhibitModel();
            this.currentGridVm = modelService.getGridModel('MockGrid');
            //console.log(this.curentGridVm);
        }                     

        getRowModel(gridCode: string, rowCode: string) {
            return this.modelService.getRowModel(gridCode, rowCode);
        }

        ModifyFirstRow() {
            var row = this.modelService.getRowModel("MockGrid", "Row_0");
            row.SelectionCell.IncludeSpaceForCell = !row.SelectionCell.IncludeSpaceForCell;
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

        addRow() {
            alert('row added' + this.RowVm.RowCode);
        }
    }

    export class IndependantRowController {

        RowVm: app.model.RowVm;
        ModelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.RowVm = $scope.rowVm;
            this.ModelService = modelService;

            console.log("i row ctrl const");
            console.log($scope);
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