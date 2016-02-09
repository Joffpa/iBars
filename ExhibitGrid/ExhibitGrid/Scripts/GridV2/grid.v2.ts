
'use strict'

module app.v2 {

    export class GridController {

        GridVm: ExhibitGrid.ViewModel.v2.Interface.IGridVm;
        ModelService: app.v2.model.IModelService;

        constructor(modelService: app.v2.model.IModelService) {
            this.GridVm = modelService.getGridVm('MockGrid');
            //console.log(this.GridVm);
            this.ModelService = modelService;
        }
    }

    export class RowController {

        RowVm: ExhibitGrid.ViewModel.v2.Interface.IRowVm;
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

    export class TextCellController {

        CellVm: ExhibitGrid.ViewModel.v2.Interface.ITextCellVm;
        ModelService: app.v2.model.IModelService;

        constructor($scope, modelService: app.v2.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }

    }

    export class PostItCellController {

        CellVm: ExhibitGrid.ViewModel.v2.Interface.IPostItCellVm;
        ModelService: app.v2.model.IModelService;

        constructor($scope, modelService: app.v2.model.IModelService) {
            console.log($scope.cellVm);
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