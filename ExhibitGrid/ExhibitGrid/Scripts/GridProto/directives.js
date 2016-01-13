var app;
(function (app) {
    var directives;
    (function (directives_1) {
        'use strict';
        var RowController = (function () {
            function RowController(scope, element, attrs) {
                this.RowVm = scope;
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
        var directives = angular.module('exhibitGrid.directives', ['exhibitGrid.calc'])
            .directive('exhibitRow', ['$compile', 'gridModelService', 'calcService', function ($compile, gridModelService, calcService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/exhibitRow.html',
                    controllerAs: 'rowCtrl',
                    controller: RowController
                };
            }])
            .directive('exhibitCell', ['$compile', 'gridModelService', function ($compile, gridModelService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/exhibitCell.html'
                };
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
                };
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
                };
            }]);
    })(directives = app.directives || (app.directives = {}));
})(app || (app = {}));
//# sourceMappingURL=directives.js.map