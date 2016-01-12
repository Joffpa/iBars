
(function () {
    'use strict'

    var directives = angular.module('exhibitGrid.directives', ['exhibitGrid.calc'])

        .directive('exhibitRow', ['$compile', 'gridModelService', 'calcService', function ($compile, gridModelService, calcService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitRow.html',
                //link: function (scope, ele, attr, ctrl) {
                //    var generatedTemplate;
                //    if (scope.row.CellType == 'num') {
                //    } else {
                //    }
                //    ele.append($compile(generatedTemplate)(scope));
                //},
                controllerAs: 'rowCtrl',
                controller: function ($scope, $element, $attrs) {
                    var ctrlVm = this;
                    ctrlVm.row = $scope;

                }
            }
        }]) 

        .directive('exhibitCell', ['$compile', 'gridModelService', function ($compile, gridModelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitCell.html'
            }
        }])

        .directive('exhibitCellNumInput', ['gridModelService', function (gridModelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitCellNumInput.html',
                controller: function ($scope, $element, $attrs) {
                    var ctrlVm = this;
                    var thisCell = $scope.cell;

                },
                controllerAs: 'cellCtrl',
                link: function (scope, ele, attr, ctrl) {

                }
            }
        }])

        .directive('exhibitCellReadOnly', ['gridModelService', function (gridModelService) {
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
} ())


