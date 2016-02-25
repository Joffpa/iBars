var app;
(function (app) {
    var directives;
    (function (directives_1) {
        'use strict';
        var directives = angular.module('app.directives', ['app.model', 'app.calc'])
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
                    controller: ['$scope', 'modelService', 'calcService', app.NumericCellController]
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
                        return function postLink(scope, element, attrs, ctrl) {
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
                        };
                    }
                };
            }]);
    })(directives = app.directives || (app.directives = {}));
})(app || (app = {}));
