var app;
(function (app) {
    var directives;
    (function (directives_1) {
        'use strict';
        var directives = angular.module('app.directives', ['app.model'])
            .directive('textCell', ['modelService', function (modelService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/textCell.html',
                    controllerAs: 'cellCtrl',
                    transclude: true,
                    scope: {
                        cellVm: '='
                    },
                    controller: ['$scope', 'modelService', app.TextCellController]
                };
            }])
            .directive('numericCell', ['modelService', function (modelService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/numericCell.html',
                    controllerAs: 'cellCtrl',
                    transclude: true,
                    scope: {
                        cellVm: '='
                    },
                    controller: ['$scope', 'modelService', app.NumericCellController]
                };
            }])
            .directive('postitCell', ['modelService', function (modelService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/postitCell.html',
                    controllerAs: 'cellCtrl',
                    transclude: true,
                    scope: {
                        cellVm: '='
                    },
                    controller: ['$scope', 'modelService', app.PostItCellController]
                };
            }])
            .directive('narrativeCell', ['modelService', function (modelService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/narrativeCell.html',
                    controllerAs: 'cellCtrl',
                    transclude: true,
                    scope: {
                        cellVm: '='
                    },
                    controller: ['$scope', 'modelService', app.NarrativeCellController]
                };
            }])
            .directive('blankCell', ['modelService', function (modelService) {
                return {
                    restrict: 'A',
                    templateUrl: '/templates/blankCell.html',
                    controllerAs: 'cellCtrl',
                    transclude: true,
                    scope: {
                        cellVm: '='
                    },
                    controller: ['$scope', 'modelService', app.BlankCellController]
                };
            }]);
    })(directives = app.directives || (app.directives = {}));
})(app || (app = {}));
//# sourceMappingURL=directives.js.map