/// <reference path="../typings/angularjs/angular.d.ts" />
"use strict";
var CellApp;
(function (CellApp) {
    var GridController = (function () {
        function GridController($attrs, modelService) {
            this.ModelService = modelService;
            var gridCode = $attrs.gridcode;
            this.GridVm = this.ModelService.getGridVm(gridCode);
        }
        return GridController;
    }());
    CellApp.GridController = GridController;
    var RowController = (function () {
        function RowController($scope, modelService, calcService, addRowService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
            this.CalcService = calcService;
            this.AddRowService = addRowService;
        }
        RowController.prototype.collapseChildren = function () {
            this.ModelService.collapseChildren(this.RowVm, true);
        };
        RowController.prototype.unCollapseChildren = function () {
            this.ModelService.collapseChildren(this.RowVm, false);
        };
        RowController.prototype.addRow = function () {
            this.AddRowService.addRowsFromRowTemplate(this.RowVm);
        };
        RowController.prototype.deleteRow = function () {
            this.AddRowService.deleteRow(this.RowVm);
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
            //var numVal = this.ModelService.unformatNumber(this.cellvm.Value, this.cellvm.DecimalPlaces);
            //if (numVal && numVal < 0) {
            //    this.cellvm.TextColor = "red";
            //} else {
            //    this.cellvm.TextColor = "";
            //}
            this.CalcService.runCellCalcs(this.cellvm);
        };
        EasCellController.prototype.onPercentChange = function () {
            this.CalcService.runCellCalcs(this.cellvm);
        };
        EasCellController.prototype.onBlur = function () {
            this.ModelService.formatCellValue(this.cellvm);
        };
        EasCellController.prototype.onFocus = function () {
            this.ModelService.unformatCellValue(this.cellvm);
        };
        EasCellController.prototype.$postLink = function () {
            if (this.cellvm.HoverBase || this.cellvm.HoverAddition) {
                var cellReference = this.cellvm;
                this.$element.kendoTooltip({
                    showOn: "mouseenter",
                    //width: 120,
                    position: "top",
                    show: function () {
                        this.refresh();
                    },
                    content: function () {
                        var hoverText = "";
                        if (cellReference.HoverBase) {
                            hoverText = cellReference.HoverBase;
                        }
                        if (cellReference.HoverAddition) {
                            if (hoverText !== "") {
                                hoverText += '</br>';
                            }
                            hoverText += cellReference.HoverAddition;
                        }
                        return hoverText;
                    }
                });
            }
            if (this.cellvm.Type == "dropdown") {
                var cellVm = this.cellvm;
                this.$element.kendoDropDownList({
                    dataTextField: "Text",
                    dataValueField: "Value",
                    enable: true,
                    change: function (e) {
                        cellVm.Value = this.value();
                    },
                    dataSource: {
                        transport: {
                            read: {
                                url: commonUI.getWebRoot() + "Home/GetDdOptions",
                                dataType: "json"
                            }
                        }
                    },
                    dataBound: function (e) {
                        this.value(cellVm.Value);
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
        .module('app.main', ['app.model', 'app.calc', 'app.filters', 'app.addRow'])
        .component('easCell', {
        template: "\n                    <div ng-switch=\"cellCtrl.cellvm.Type\">\n                        <div ng-switch-when=\"text\" ng-switch=\"cellCtrl.cellvm.IsEditable\" ng-style='cellCtrl.getStyle()' class=\"indent-{{cellCtrl.cellvm.Alignment}}-{{cellCtrl.cellvm.Indent}} text-cell-th\" >\n                            <input type=\"text\" class='k-textbox' ng-style=\"cellCtrl.getStyle()\" ng-switch-when='true' ng-model='cellCtrl.cellvm.Value'/>\n                            <div ng-switch-when='false'>\n                                {{cellCtrl.cellvm.Value}}\n                            </div>\n                        </div>\n                        \n                        <div ng-switch-when=\"numeric\" ng-switch=\"cellCtrl.cellvm.IsEditable\" ng-style=\"cellCtrl.getStyle()\" class=\"numeric-cell\">\n                            <input ng-switch-when=\"true\" type=\"text\" ng-style=\"cellCtrl.getStyle()\" class=\"k-textbox numeric\" ng-model=\"cellCtrl.cellvm.Value\" ng-change=\"cellCtrl.onNumChange()\" ng-blur=\"cellCtrl.onBlur()\" ng-focus=\"cellCtrl.onFocus()\" maxlength=\"{{cellCtrl.cellvm.MaxChars}}\"/>\n                            <div ng-switch-when=\"false\" style=\"padding-right:5px\">\n                                {{cellCtrl.cellvm.Value}}\n                            </div>\n                        </div>\n                        \n                        <div ng-switch-when=\"percent\" ng-switch=\"cellCtrl.cellvm.IsEditable\"  ng-style=\"cellCtrl.getStyle()\" class=\"percent-cell\">\n                            <div ng-switch-when=\"true\">\n                                <input type=\"text\" class=\"k-textbox percent\" style=\"width:85%;color:inherit;text-decoration-color:inherit;text-align:inherit;\" ng-model=\"cellCtrl.cellvm.Value\"  ng-change=\"cellCtrl.onPercentChange()\" ng-blur=\"cellCtrl.onBlur()\" ng-focus=\"cellCtrl.onFocus()\" maxlength=\"{{cellCtrl.cellvm.MaxChars}}\" /> \n                                <span style=\"width:15%\"> %\n                                </span>\n                            </div>\n                            <div ng-switch-when=\"false\" style=\"padding-right:5px\">\n                               {{cellCtrl.cellvm.Value}} %\n                           </div>\n                        </div>\n                        \n                        <div ng-switch-when=\"postit\">\n                            <i class=\"fa fa-map-pin fa-lg\" style=\"cursor:pointer\" ng-click=\"cellCtrl.editPostIt()\"></i>\n                        </div>\n                        \n                        <div ng-switch-when=\"narrative\">\n                            <i class=\"fa fa-sticky-note fa-lg\" style=\"cursor:pointer\" ng-click=\"cellCtrl.editNarrative()\"></i>\n                        </div>\n                        \n                        <div ng-switch-when=\"blank\">\n                        </div>\n                    </div>\n                    ",
        controllerAs: 'cellCtrl',
        controller: ['modelService', 'calcService', '$element', EasCellController],
        bindings: {
            cellvm: '<'
        }
    })
        .controller('gridController', ['$attrs', 'modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', 'calcService', 'addRowService', RowController]);
})(CellApp || (CellApp = {}));
//# sourceMappingURL=dynamicCellGrid.js.map