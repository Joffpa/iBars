var app;
(function (app) {
    var directives;
    (function (directives_1) {
        'use strict';
        //var directives = angular.module('app.directives', ['app.calc', 'app.model'])
        var directives = angular.module('app.directives', ['app.model'])
            .directive('exhibitGrid', function () {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitGrid.html',
                controllerAs: 'gridCtrl',
                scope: { gridVm: '=' },
                controller: ['$scope', 'modelService', app.GridController]
            };
        })
            .directive('exhibitRow', ['$compile', 'modelService', 'calcService', function ($compile, modelService, calcService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/exhibitRow.html',
                    controllerAs: 'rowCtrl',
                    controller: ['$scope', 'modelService', app.RowController],
                };
            }])
            .directive('exhibitCell', ['$compile', 'modelService', function ($compile, modelService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/exhibitCell.html',
                    controller: ['$scope', 'calcService', app.CellController],
                    link: function (scope, element, attrs, controller, transcludeFn) {
                        if (scope.cell.Type == 'num-input') {
                            console.log(element);
                            console.log($('#' + scope.cell.RowCode + scope.cell.ColCode));
                        }
                    }
                };
            }]);
    })(directives = app.directives || (app.directives = {}));
})(app || (app = {}));
