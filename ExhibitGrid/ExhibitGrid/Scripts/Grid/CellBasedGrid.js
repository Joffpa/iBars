/// <reference path="../typings/angularjs/angular.d.ts" />
"use strict";
var CellApp;
(function (CellApp) {
    var GridController = (function () {
        function GridController($attrs, modelService) {
            console.log($attrs.gridCode);
            this.ModelService = modelService;
            var gridCode = $attrs.gridcode;
            this.GridVm = this.ModelService.getGridVm(gridCode);
        }
        return GridController;
    }());
    CellApp.GridController = GridController;
    var RowController = (function () {
        function RowController($scope, modelService, calcService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
            this.CalcService = calcService;
        }
        RowController.prototype.collapseChildren = function () {
            this.ModelService.collapseChildren(this.RowVm.GridCode, this.RowVm.RowCode);
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
    CellApp.RowController = RowController;
    var EasCellController = (function () {
        function EasCellController(modelService, calcService, $element) {
            var ctrl = this;
            ctrl.ModelService = modelService;
            ctrl.CalcService = calcService;
            ctrl.$element = $element;
        }
        EasCellController.prototype.getStyle = function () {
            return this.ModelService.getCellStyle(this.cellvm);
        };
        EasCellController.prototype.getMaxLen = function () {
        };
        EasCellController.prototype.onNumChange = function () {
            this.CalcService.runCellCalcs(this.cellvm);
        };
        EasCellController.prototype.onPercentChange = function () {
            this.CalcService.runCellCalcs(this.cellvm);
        };
        EasCellController.prototype.onBlur = function () {
            this.ModelService.formatCellNumber(this.cellvm);
        };
        EasCellController.prototype.onFocus = function () {
            console.log("unformat");
            this.ModelService.unformatCellNumber(this.cellvm);
        };
        EasCellController.prototype.$postLink = function () {
            if (this.cellvm.Type == "dropdown") {
                this.$element.kendoDropDownList({
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
        EasCellController.prototype.editPostIt = function () {
            alert("Post it for cell: " + this.cellvm.RowCode + " " + this.cellvm.ColCode);
        };
        EasCellController.prototype.editNarrative = function () {
            alert("Narrative Library Popup (not yet implemented in prototype).");
        };
        return EasCellController;
    }());
    CellApp.EasCellController = EasCellController;
    // ReSharper disable once TsResolvedFromInaccessibleModule
    var exhibitApp = angular
        .module('app', ['app.model', 'app.calc', 'app.filters'])
        .component('easCell', {
        template: "\n                    <div ng-switch=\"cellCtrl.cellvm.Type\" data-toggle=\"tooltip\" title=\"This is some very long tooltip text to confirm the tooltip works\">\n                        <div ng-switch-when=\"text\" ng-switch=\"cellCtrl.cellvm.IsEditable\" ng-style='cellCtrl.getStyle()' class=\"indent-{{cellCtrl.cellvm.Alignment}}-{{cellCtrl.cellvm.Indent}} text-cell-th\" >\n                            <input type=\"text\" class='k-textbox' ng-switch-when='true' ng-model='cellCtrl.cellvm.Value'/>\n                            <div ng-switch-when='false'>\n                                {{cellCtrl.cellvm.Value}}\n                            </div>\n                        </div>\n                        \n                        <div ng-switch-when=\"numeric\" ng-switch=\"cellCtrl.cellvm.IsEditable\" ng-style=\"cellCtrl.getStyle()\" class=\"numeric-cell\">\n                            <input ng-switch-when=\"true\" type=\"text\" class=\"k-textbox numeric\" ng-model=\"cellCtrl.cellvm.Value\" ng-change=\"cellCtrl.onNumChange()\" ng-blur=\"cellCtrl.onBlur()\" ng-focus=\"cellCtrl.onFocus()\" maxlength=\"{{cellCtrl.cellvm.MaxChars}}\"/>\n                            <div ng-switch-when=\"false\" style=\"padding-right:5px\" ng-class=\"parseFloat(cellCtrl.cellvm.Value) < 0 ? 'negative-val' : 'positive-val'\">\n                                {{cellCtrl.cellvm.Value | negativeInParens}}\n                            </div>\n                        </div>\n                        \n                        <div ng-switch-when=\"percent\" ng-switch=\"cellCtrl.cellvm.IsEditable\"  ng-style=\"cellCtrl.getStyle()\" class=\"percent-cell\">\n                            <div ng-switch-when=\"true\">\n                                <input type=\"text\" class=\"k-textbox percent\" ng-model=\"cellCtrl.cellvm.Value\"  ng-change=\"cellCtrl.onPercentChange()\" ng-blur=\"cellCtrl.onBlur()\" ng-focus=\"cellCtrl.onFocus()\" maxlength=\"{{cellCtrl.cellvm.MaxChars}}\" />%\n                            </div>\n                            <div ng-switch-when=\"false\" style=\"padding-right:5px\" ng-class=\"parseFloat(cellCtrl.cellvm.Value) < 0 ? 'negative-val' : 'positive-val'\">\n                               {{cellCtrl.cellvm.Value | negativeInParens}} %\n                           </div>\n                        </div>\n                        \n                        <div ng-switch-when=\"postit\">\n                            <i class=\"fa fa-map-pin fa-lg\" style=\"cursor:pointer\" ng-click=\"cellCtrl.editPostIt()\"></i>\n                        </div>\n                        \n                        <div ng-switch-when=\"narrative\">\n                            <i class=\"fa fa-sticky-note fa-lg\" style=\"cursor:pointer\" ng-click=\"cellCtrl.editNarrative()\"></i>\n                        </div>\n                        \n                        <div ng-switch-when=\"dropdown\">\n                            <input id=\"{{cellCtrl.cellvm.GridCode + '_' + cellCtrl.cellvm.RowCode + '_' + cellCtrl.cellvm.ColCode}}\" ng-model=\"cellCtrl.cellvm.Text\"/>\n                        </div>\n                        \n                        <div ng-switch-when=\"blank\">\n                        </div>\n                    </div>\n                    ",
        controllerAs: 'cellCtrl',
        controller: EasCellController,
        bindings: {
            cellvm: '<'
        }
    })
        .controller('gridController', ['$attrs', 'modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', 'calcService', RowController]);
})(CellApp || (CellApp = {}));
//# sourceMappingURL=CellBasedGrid.js.map