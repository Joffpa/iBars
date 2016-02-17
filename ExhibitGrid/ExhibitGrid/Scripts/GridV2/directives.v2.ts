

module app.v2.directives {

    'use strict'
    
    var directives = angular.module('app.v2.directives', ['app.v2.model'])
        .directive('exhibitRow', ['modelService', function (modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/independantRow.html',
                controllerAs: 'rowCtrl',
                transclude: true,
                controller: ['$scope', 'modelService', app.v2.RowController]
            }
        }])
        .directive('textCell', ['modelService', function (modelService) {
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
        .directive('numericCell', ['modelService', function (modelService) {
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
        .directive('postitCell', ['modelService', function (modelService) {
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
        .directive('narrativeCell', ['modelService', function (modelService) {
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
        .directive('blankCell', ['modelService', function (modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/v2/blankCell.html',
                controllerAs: 'cellCtrl',
                transclude: true,
                scope: {
                    cellVm: '='
                },
                controller: ['$scope', 'modelService', app.v2.BlankCellController]
            }
        }])
        ;
}