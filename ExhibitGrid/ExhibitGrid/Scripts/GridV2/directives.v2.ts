

module app.v2.directives {

    'use strict'
    
    var directives = angular.module('app.v2.directives', ['app.v2.model'])
        .directive('exhibitRow', ['$compile', 'modelService', function ($compile, modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/independantRow.html',
                controllerAs: 'rowCtrl',
                transclude: true,
                controller: ['$scope', 'modelService', RowController]
            }
        }])
        .directive('exhibitCell', ['$compile', 'modelService', function ($compile, modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/independantRow.html',
                controllerAs: 'rowCtrl',
                transclude: true,
                controller: ['$scope', 'modelService', CellController]
            }
        }])
        ;
}