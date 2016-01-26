module app.directives{

    'use strict'



    //var directives = angular.module('app.directives', ['app.calc', 'app.model'])
    var directives = angular.module('app.directives', ['app.model'])
        .directive('exhibitGrid',function () {
            return {
                restrict: 'A',
                templateUrl: '/templates/exhibitGrid.html',
                controllerAs: 'gridCtrl',
                scope: { gridVm: '=' },
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
                controller: ['$scope', 'calcService', CellController],
            }
        }])

        //.directive('exhibitCellNumInput', ['modelService', function (modelService) {
        //    return {
        //        restrict: 'A',
        //        templateUrl: '/templates/exhibitCellNumInput.html',
        //        controller: function ($scope, $element, $attrs) {

        //            console.log($scope);
        //            var ctrlVm = this;
        //            var thisCell = $scope.cell;
        //        },
        //        controllerAs: 'cellCtrl',
        //        link: function (scope, ele, attr, ctrl) {

        //        }
        //    }
        //}])

        //.directive('exhibitCellReadOnly', ['modelService', function (modelService) {
        //    return {
        //        restrict: 'A',
        //        templateUrl: '/templates/exhibitCellReadOnly.html',
        //        controller: function ($scope, $element, $attrs) {
        //            var ctrlVm = this;
        //            var thisCell = $scope.cell;

        //        },
        //        controllerAs: 'cellCtrl',
        //        link: function (scope, ele, attr, ctrl) {

        //        }
        //    }
        //}])
        ;
}


