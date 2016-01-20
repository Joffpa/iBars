var app;
(function (app) {
    var directives;
    (function (directives_1) {
        'use strict';
        var RowController = (function () {
            function RowController($scope, modelService) {
                this.RowVm = $scope.row;
                this.modelService = modelService;
            }
            RowController.prototype.getRowCssClass = function () {
                if (this.RowVm.Type == app.model.RowType.Data)
                    return 'data-row';
                else if (this.RowVm.Type == app.model.RowType.Total)
                    return 'total-row';
                else if (this.RowVm.Type == app.model.RowType.Header)
                    return 'header-row';
            };
            return RowController;
        })();
        var NumericInputCellController = (function () {
            function NumericInputCellController() {
            }
            return NumericInputCellController;
        })();
        var GridController = (function () {
            function GridController($scope, modelService) {
                this.GridVm = $scope.grid;
                this.modelService = modelService;
            }
            GridController.prototype.addRow = function () {
            };
            GridController.prototype.addCol = function () {
            };
            return GridController;
        })();
        //var directives = angular.module('app.directives', ['app.calc', 'app.model'])
        var directives = angular.module('app.directives', ['app.model'])
            .directive('exhibitGrid', function () {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitGrid.html',
                controllerAs: 'gridCtrl',
                controller: ['$scope', 'modelService', GridController]
            };
        })
            .directive('exhibitRow', ['$compile', 'modelService', 'calcService', function ($compile, modelService, calcService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/exhibitRow.html',
                    controllerAs: 'rowCtrl',
                    controller: ['$scope', 'modelService', RowController],
                };
            }])
            .directive('exhibitCell', ['$compile', 'modelService', function ($compile, modelService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/exhibitCell.html',
                    controller: function ($scope, $element, $attrs) {
                        console.log($scope);
                    }
                };
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
                };
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
                };
            }]);
    })(directives = app.directives || (app.directives = {}));
})(app || (app = {}));
//# sourceMappingURL=directives.js.map