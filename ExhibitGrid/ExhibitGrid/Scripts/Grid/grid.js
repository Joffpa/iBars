/// <reference path="../typings/angularjs/angular.d.ts" />
"use strict";
var app;
(function (app) {
    var GridController = (function () {
        function GridController($attrs, modelService) {
            console.log($attrs.gridCode);
            this.ModelService = modelService;
            var gridCode = $attrs.gridcode;
            this.GridVm = this.ModelService.getGridVm(gridCode);
        }
        return GridController;
    }());
    app.GridController = GridController;
    var RowController = (function () {
        function RowController($scope, modelService, calcService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
            this.CalcService = calcService;
        }
        RowController.prototype.collapseChildren = function () {
            //this.ModelService.collapseChildren(this.RowVm.GridCode, this.RowVm.RowCode);
        };
        RowController.prototype.addRow = function () {
            alert('row added: ' + this.RowVm.RowCode);
        };
        RowController.prototype.deleteRow = function () {
            alert('row deleted: ' + this.RowVm.RowCode);
        };
        RowController.prototype.update = function (val) {
        };
        return RowController;
    }());
    app.RowController = RowController;
    var TextCellController = (function () {
        function TextCellController() {
        }
        TextCellController.prototype.getStyle = function () {
            if (this.cellvm.Width) {
                return { 'width': this.cellvm.Width };
            }
            return { 'width': '100%' };
        };
        return TextCellController;
    }());
    app.TextCellController = TextCellController;
    var NumericCellController = (function () {
        function NumericCellController(modelService, calcService) {
            var ctrl = this;
            ctrl.ModelService = modelService;
            ctrl.CalcService = calcService;
        }
        NumericCellController.prototype.getStyle = function () {
            if (this.cellvm.Width) {
                return { 'width': this.cellvm.Width };
            }
            return { 'width': '110px' };
        };
        NumericCellController.prototype.onChange = function () {
            this.CalcService.runCellCalcs(this.cellvm);
        };
        NumericCellController.prototype.onBlur = function () {
        };
        return NumericCellController;
    }());
    app.NumericCellController = NumericCellController;
    var PercentCellController = (function () {
        function PercentCellController(modelService, calcService) {
            var ctrl = this;
            ctrl.ModelService = modelService;
            ctrl.CalcService = calcService;
        }
        PercentCellController.prototype.getStyle = function () {
            if (this.cellvm.Width) {
                return { 'width': this.cellvm.Width };
            }
            return { 'width': '110px' };
        };
        PercentCellController.prototype.onChange = function () {
            console.log("change");
            this.CalcService.runCellCalcs(this.cellvm);
        };
        PercentCellController.prototype.onBlur = function () {
        };
        return PercentCellController;
    }());
    app.PercentCellController = PercentCellController;
    var PostItCellController = (function () {
        function PostItCellController() {
        }
        PostItCellController.prototype.editPostIt = function () {
            alert("Post it for cell: " + this.cellvm.RowCode + " " + this.cellvm.ColCode);
        };
        return PostItCellController;
    }());
    app.PostItCellController = PostItCellController;
    var NarrativeCellController = (function () {
        function NarrativeCellController() {
        }
        NarrativeCellController.prototype.editNarrative = function () {
            alert(this.cellvm.Value);
        };
        return NarrativeCellController;
    }());
    app.NarrativeCellController = NarrativeCellController;
    var DropdownCellController = (function () {
        function DropdownCellController($element) {
            this.element = $element;
        }
        DropdownCellController.prototype.$postLink = function () {
            if (!this.cellvm.IsBlank) {
                this.element.kendoDropDownList({
                    dataTextField: "Text",
                    dataValueField: "Value",
                    enable: true,
                    dataSource: {
                        transport: {
                            read: {
                                url: commonUI.getWebRoot() + "Home/GetDdOptions",
                                dataType: "json"
                            }
                        }
                    }
                });
            }
        };
        return DropdownCellController;
    }());
    app.DropdownCellController = DropdownCellController;
    // ReSharper disable once TsResolvedFromInaccessibleModule
    var exhibitApp = angular
        .module('app', ['app.model', 'app.directives', 'app.calc', 'app.filters'])
        .component('textCell', {
        template: "\n                <div ng-switch=\"cellCtrl.cellvm.IsEditable\" class=\"indent-{{cellCtrl.cellvm.Indent}} {{cellCtrl.cellvm.Class}} text-cell-th\" ng-if=\"!cellCtrl.cellvm.IsBlank\" ng-style=\"cellCtrl.getStyle()\">\n                    <input type=\"text\" class=\"k-textbox\" ng-switch-when=\"true\" ng-model=\"cellCtrl.cellvm.Value\" style=\"text-align:left\" />\n                    <div ng-switch-when=\"false\" style=\"text-align:left\">\n                        {{cellCtrl.cellvm.Value}}\n                    </div>\n                </div>\n                ",
        controllerAs: 'cellCtrl',
        controller: TextCellController,
        bindings: {
            cellvm: '<'
        }
    })
        .component('numericCell', {
        template: "\n                    <div ng-switch=\"cellCtrl.cellvm.IsEditable\" ng-if=\"!cellCtrl.cellvm.IsBlank\" ng-style=\"cellCtrl.getStyle()\" class=\"numeric-cell-td\">\n                        <input ng-switch-when=\"true\" type=\"number\" class=\"k-textbox numeric\" ng-model=\"cellCtrl.cellvm.NumValue\" style=\"text-align:right\" ng-change=\"cellCtrl.onChange()\" ng-blur=\"cellCtrl.onBlur()\"/>\n                        <div ng-switch-when=\"false\" style=\"text-align:right; padding-right:20px\" maxlength=\"8\" ng-class=\"cellCtrl.cellvm.NumValue < 0 ? 'negative-val' : 'positive-val'\">\n                            {{cellCtrl.cellvm.Value | negativeInParens}}\n                        </div>\n                    </div>\n                    ",
        controllerAs: 'cellCtrl',
        controller: NumericCellController,
        bindings: {
            cellvm: '<'
        }
    })
        .component('percentCell', {
        template: "\n                    <div ng-switch=\"cellCtrl.cellvm.IsEditable\" ng-if=\"!cellCtrl.cellvm.IsBlank\" ng-style=\"cellCtrl.getStyle()\" class=\"numeric-cell-td\">\n                        <div ng-switch-when=\"true\" style=\"width:100%\">\n                            <input type=\"number\" class=\"k-textbox percent\" ng-model=\"cellCtrl.cellvm.NumValue\" style=\"text-align:right\" ng-change=\"cellCtrl.onChange()\" ng-blur=\"cellCtrl.onBlur()\"/> %\n                        </div>\n                        <div ng-switch-when=\"false\" style=\"text-align:right; padding-right:20px\" maxlength=\"8\" ng-class=\"cellCtrl.cellvm.NumValue < 0 ? 'negative-val' : 'positive-val'\">\n                            {{cellCtrl.cellvm.Value | negativeInParens}} %\n                        </div>\n                    </div>\n                    ",
        controllerAs: 'cellCtrl',
        controller: PercentCellController,
        bindings: {
            cellvm: '<'
        }
    })
        .component('postitCell', {
        template: "\n                    <div ng-if=\"!cellctrl.cellvm.IsBlank\">\n                        <i class=\"fa fa-map-pin fa-lg\" style=\"cursor:pointer\" ng-click=\"cellCtrl.editPostIt()\"></i>\n                    </div>\n                    ",
        controllerAs: 'cellCtrl',
        controller: PostItCellController,
        bindings: {
            cellvm: '<'
        }
    })
        .component('narrativeCell', {
        template: "\n                    <div ng-if=\"!cellCtrl.cellvm.IsBlank\">\n                        <i class=\"fa fa-sticky-note fa-lg\" style=\"cursor:pointer\" ng-click=\"cellCtrl.editNarrative()\"></i>\n                    </div>\n                    ",
        controllerAs: 'cellCtrl',
        controller: NarrativeCellController,
        bindings: {
            cellvm: '<'
        }
    })
        .component('dropdownCell', {
        template: "\n                    <div ng-if=\"!cellCtrl.cellvm.IsBlank\">\n                        <input id=\"{{cellCtrl.cellvm.GridCode + '_' + cellCtrl.cellvm.RowCode + '_' + cellCtrl.cellvm.ColCode}}\" ng-model=\"cellCtrl.cellvm.Text\"/>\n                    </div>\n                    ",
        controllerAs: 'cellCtrl',
        controller: DropdownCellController,
        bindings: {
            cellvm: '<'
        }
    })
        .controller('gridController', ['$attrs', 'modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', 'calcService', RowController]);
})(app || (app = {}));
//# sourceMappingURL=grid.js.map