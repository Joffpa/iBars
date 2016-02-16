

module app.v2.directives {

    'use strict'
    
    var directives = angular.module('app.v2.directives', ['app.v2.model'])
        .directive('exhibitRow', ['$compile', 'modelService', function ($compile, modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/independantRow.html',
                controllerAs: 'rowCtrl',
                transclude: true,
                controller: ['$scope', 'modelService', app.v2.RowController]
            }
        }])
        .directive('textCell', ['$compile', 'modelService', function ($compile, modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/v2/textCell.html',
                controllerAs: 'cellCtrl',
                transclude: true,
                scope: {
                    cellVm: '='
                },
                controller: ['$scope', 'modelService', app.v2.TextCellController]
            }
        }])
        .directive('numericCell', ['$compile', 'modelService', function ($compile, modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/v2/numericCell.html',
                controllerAs: 'cellCtrl',
                transclude: true,
                scope: {
                    cellVm: '='
                },
                controller: ['$scope', 'modelService', app.v2.NumericCellController]
            }
        }])
        .directive('postitCell', ['$compile', 'modelService', function ($compile, modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/v2/postitCell.html',
                controllerAs: 'cellCtrl',
                transclude: true,
                scope: {
                    cellVm: '='
                },
                controller: ['$scope', 'modelService', app.v2.PostItCellController]
            }
        }])
        .directive('narrativeCell', ['$compile', 'modelService', function ($compile, modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/v2/narrativeCell.html',
                controllerAs: 'cellCtrl',
                transclude: true,
                scope: {
                    cellVm: '='
                },
                controller: ['$scope', 'modelService', app.v2.NarrativeCellController]
            }
        }])
        ;
}