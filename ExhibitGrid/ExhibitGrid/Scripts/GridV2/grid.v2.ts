
'use strict'

module app.v2 {

    //export class ExhibitController {
    //    exhibitVm: app.model.ExhibitVm;
    //    modelService: app.model.IModelService;
    //    currentGridVm: app.model.GridVm;

    //    constructor(modelService: app.model.IModelService) {
    //        this.modelService = modelService;
    //        this.exhibitVm = modelService.getExhibitModel();
    //        this.currentGridVm = modelService.getGridModel('MockGrid');
    //        //console.log(this.curentGridVm);
    //    }

    //    getRowModel(gridCode: string, rowCode: string) {
    //        return this.modelService.getRowModel(gridCode, rowCode);
    //    }

    //    ModifyFirstRow() {
    //        var row = this.modelService.getRowModel("MockGrid", "Row_0");
    //        row.SelectionCell.IncludeSpaceForCell = !row.SelectionCell.IncludeSpaceForCell;
    //    }
    //}

    export class GridController {

        GridVm: ExhibitGrid.ViewModel.IGridVm;
        ModelService: app.v2.model.IModelService;

        constructor(modelService: app.v2.model.IModelService) {
            this.GridVm = modelService.getGridVm('MockGrid');
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
            alert('row added' + this.RowVm.RowCode);
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