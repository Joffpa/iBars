/// <reference path="../typings/angularjs/angular.d.ts" />

'use strict';

module app {

    export class GridController {

        GridVm: ExhibitGrid.ViewModel.IGridVm;
        ModelService: app.model.IModelService;

        constructor(modelService: app.model.IModelService) {
            this.ModelService = modelService;
            var gridCode = window['gridModel'].gridCode;
            this.GridVm = this.ModelService.getGridVm(gridCode);
        }
    }

    export class RowController {

        RowVm: ExhibitGrid.ViewModel.IRowVm;
        ModelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
        }

        collapseChildren() {
            this.RowVm.CollapseableChildren.forEach((val, idx) => {
                var child = this.ModelService.getRowVm(this.RowVm.GridCode, val);
                child.IsCollapsed = !child.IsCollapsed;
            });
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
        CalcService: app.calc.ICalcService;
        
        constructor($scope, modelService: app.model.IModelService, calcService: app.calc.ICalcService) {
            console.log($scope);
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
            this.CalcService = calcService;

            if (this.CalcService.cellHasCalcs(this.CellVm.GridCode, this.CellVm.RowCode, this.CellVm.ColCode)) {
                $scope.$watch('cellVm.Value', (newVal, oldVal, scope) => {
                    scope.cellCtrl.CalcService.runCalcsForCell(scope.cellVm.GridCode, scope.cellVm.RowCode, scope.cellVm.ColCode, newVal);
                });
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

    // ReSharper disable once TsResolvedFromInaccessibleModule
    var exhibitApp = angular
        .module('app', ['app.model', 'app.directives', 'app.calc', 'app.filters'])    
        .controller('gridController', ['modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', RowController]);

}