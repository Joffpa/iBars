module app.directives{

    'use strict'
    
    class RowController{

        RowVm: app.model.RowVm;
        modelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.RowVm = $scope.row;
            this.modelService = modelService;
        }
        
        getRowCssClass() {
            if (this.RowVm.Type == app.model.RowType.Data)
                return 'data-row';
            else if (this.RowVm.Type == app.model.RowType.Total)
                return 'total-row';
            else if (this.RowVm.Type == app.model.RowType.Header)
                return 'header-row';
        }
    }
    
    class NumericInputCellController {
        CellVm: app.model.DataCellVm;
        
    }

    class GridController{

        GridVm: app.model.ExhibitVm;
        modelService: app.model.IModelService;

        constructor($scope, modelService: app.model.IModelService) {
            this.GridVm = $scope.grid;
            this.modelService = modelService;
        } 

        addRow() {

        }

        addCol() {

        }
    }

    //var directives = angular.module('app.directives', ['app.calc', 'app.model'])
    var directives = angular.module('app.directives', ['app.model'])
        .directive('exhibitGrid',function () {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitGrid.html',
                controllerAs: 'gridCtrl',
                controller: ['$scope','modelService', GridController]
                //link: function (scope, element, attrs, tabsCtrl) {
                //    console.log('controller linked');
                //}
            }
        }) 
        
        .directive('exhibitRow', ['$compile', 'modelService', 'calcService', function ($compile, modelService, calcService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitRow.html',
                controllerAs: 'rowCtrl',
                controller: ['$scope', 'modelService', RowController],
            }
        }]) 

        .directive('exhibitCell', ['$compile', 'modelService', function ($compile, modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitCell.html',
                controller: function ($scope, $element, $attrs) {

                    console.log($scope);
                }
            }
        }])

        .directive('exhibitCellNumInput', ['modelService', function (modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitCellNumInput.html',
                controller: function ($scope, $element, $attrs) {

                    console.log($scope);
                    var ctrlVm = this;
                    var thisCell = $scope.cell;
                },
                controllerAs: 'cellCtrl',
                link: function (scope, ele, attr, ctrl) {

                }
            }
        }])

        .directive('exhibitCellReadOnly', ['modelService', function (modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitCellReadOnly.html',
                controller: function ($scope, $element, $attrs) {
                    var ctrlVm = this;
                    var thisCell = $scope.cell;

                },
                controllerAs: 'cellCtrl',
                link: function (scope, ele, attr, ctrl) {

                }
            }
        }]);
}


