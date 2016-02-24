

module app.directives {

    'use strict'
    
    var directives = angular.module('app.directives', ['app.model', 'app.calc'])
        //.directive('compileCell', ['$compile', 'modelService', function ($compile, modelService) {
        //    return {
        //        restrict: 'A',
        //        replace: false,
        //        terminal: true, 
        //        priority: 1000, 
        //        scope: {
        //            cellVm: '='
        //        },
        //        compile: function compile(element, attrs) {
        //            return {
        //                pre: function preLink(scope, iElement, iAttrs, controller) {
        //                    //console.log(scope);
        //                    iElement.attr(scope.cellVm.Directive, '');
        //                    iElement.removeAttr("compile-cell"); //remove the attribute to avoid indefinite loop
        //                    iElement.removeAttr("data-compile-cell"); //also remove the same attribute with data- prefix in case users specify data-common-things in the html

        //                },
        //                post: function postLink(scope, iElement, iAttrs, controller) {
        //                    $compile(iElement)(scope);
        //                }
        //            };
        //        }
        //    };
        //}])
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
            }
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
                controller: ['$scope', 'modelService', 'calcService', app.NumericCellController]
            }
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
            }
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
            }
        }])
        .directive('dropdownCell', ['modelService', function (modelService) {
            return {
                restrict: 'A',
                templateUrl: '/templates/dropdownCell.html',
                controllerAs: 'cellCtrl',
                transclude: true,
                scope: {
                    cellVm: '='
                },
                controller: ['$scope', 'modelService', app.DropdownCellController],
                compile: function compile(tElement, tAttrs, transclude) {
                    return  function postLink(scope, element, attrs, ctrl) {
                        //console.log(element.find('input'));
                        element.find('input').kendoDropDownList({
                            dataTextField: "Text",
                            dataValueField: "Value",
                            enable: scope.cellVm.IsEditable,
                            dataSource: {
                                transport: {
                                    read: {
                                        url: "/Home/GetDdOptions?rowCode=" + scope.cellVm.RowCode + "&colCode=" + scope.cellVm.ColCode,
                                        dataType: "json"
                                    }
                                }
                            }
                        });
                    }
                }
            }
        }])
        ;
}