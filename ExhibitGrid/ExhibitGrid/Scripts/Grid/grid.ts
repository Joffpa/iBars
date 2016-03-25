/// <reference path="../typings/angularjs/angular.d.ts" />

"use strict";

module app {

    export class GridController {

        GridVm: ExhibitGrid.ViewModel.IGridVm;
        ModelService: app.model.IModelService;

        constructor(modelService: app.model.IModelService) {
            this.ModelService = modelService;
            var gridCode = window["gridModel"].gridCode;
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
            this.ModelService.collapseChildren(this.RowVm.GridCode, this.RowVm.RowCode);
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

        getStyle() {
            return { 'width': this.CellVm.Width };
        }

        constructor($scope, modelService: app.model.IModelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
    } 

    export class NumericCellController {

        CellVm: ExhibitGrid.ViewModel.ICellVm;
        ModelService: app.model.IModelService;
        CalcService: app.calc.ICalcService;

        getStyle() {
            if (this.CellVm.Width) {
                return { 'width': this.CellVm.Width };
            }
            return { 'width': '110px' };
        }
        constructor($scope, modelService: app.model.IModelService, calcService: app.calc.ICalcService) {
            //console.log($scope);
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
            this.CalcService = calcService;

            if ((this.CellVm.Calcs && this.CellVm.Calcs.length > 0) || this.CellVm.ParentRowCode) {
                $scope.$watch('cellVm.NumValue', (newVal, oldVal, scope) => {
                    scope.cellCtrl.CalcService.runCellCalcs(this.CellVm, newVal);
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
            //console.log($scope.cellVm);

        }

        editNarrative() {
            alert(this.CellVm.Value);
            
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