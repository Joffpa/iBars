/// <reference path="../typings/angularjs/angular.d.ts" />

"use strict";

module CellApp {

    export class GridController {
        GridVm: ExhibitGrid.ViewModel.IGridVm;
        ModelService: app.model.IModelService;

        constructor($attrs, modelService: app.model.IModelService) {
            this.ModelService = modelService;
            var gridCode = $attrs.gridcode;
            this.GridVm = this.ModelService.getGridVm(gridCode);
        }
    }

    export class RowController {

        RowVm: ExhibitGrid.ViewModel.IRowVm;
        ModelService: app.model.IModelService;
        CalcService: app.calc.ICalcService;
        AddRowService: app.addRow.IAddRowService;

        constructor($scope, modelService: app.model.IModelService, calcService: app.calc.ICalcService, addRowService: app.addRow.IAddRowService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
            this.CalcService = calcService;
            this.AddRowService = addRowService;
        }

        collapseChildren() {
            this.ModelService.collapseChildren(this.RowVm, true);
        }

        unCollapseChildren() {
            this.ModelService.collapseChildren(this.RowVm, false);
        }

        addRow() {
            this.AddRowService.addRowsFromRowTemplate(this.RowVm);
        }

        deleteRow() {
            this.AddRowService.deleteRow(this.RowVm);
        }

        update(val) {
        }
         
    }

    export class EasCellController {

        cellvm: ExhibitGrid.ViewModel.ICellVm;
        ModelService: app.model.IModelService;
        CalcService: app.calc.ICalcService;
        $element;

        constructor(modelService: app.model.IModelService, calcService: app.calc.ICalcService, $element) {
            var ctrl = this;
            ctrl.ModelService = modelService;
            ctrl.CalcService = calcService;
            ctrl.$element = $element;
        }

        getStyle() {
            return this.ModelService.getCellStyle(this.cellvm);
        }

        getMaxLen() {

        }

        onNumChange() {
            //var numVal = this.ModelService.unformatNumber(this.cellvm.Value, this.cellvm.DecimalPlaces);
            //if (numVal && numVal < 0) {
            //    this.cellvm.TextColor = "red";
            //} else {
            //    this.cellvm.TextColor = "";
            //}
            this.CalcService.runCellCalcs(this.cellvm);
        }

        onPercentChange() {
            this.CalcService.runCellCalcs(this.cellvm);
        }

        onBlur() {
            this.ModelService.formatCellValue(this.cellvm);
        }
        
        onFocus() {
            this.ModelService.unformatCellValue(this.cellvm);
        }

        $postLink() {
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
                    change: function(e) {
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
        }

        editPostIt() {
            alert("Post it for cell: " + this.cellvm.RowCode + " " + this.cellvm.ColCode);
        }

        editNarrative() {
            alert("Narrative Library Popup (not yet implemented in prototype).");
        }
    }

    // ReSharper disable once TsResolvedFromInaccessibleModule
    var exhibitApp = angular
        .module('app', ['app.model', 'app.calc', 'app.filters', 'app.addRow'])
        .component('easCell', {
            template: `
                    <div ng-switch="cellCtrl.cellvm.Type">
                        <div ng-switch-when="text" ng-switch="cellCtrl.cellvm.IsEditable" ng-style='cellCtrl.getStyle()' class="indent-{{cellCtrl.cellvm.Alignment}}-{{cellCtrl.cellvm.Indent}} text-cell-th" >
                            <input type="text" class='k-textbox' ng-style="cellCtrl.getStyle()" ng-switch-when='true' ng-model='cellCtrl.cellvm.Value'/>
                            <div ng-switch-when='false'>
                                {{cellCtrl.cellvm.Value}}
                            </div>
                        </div>
                        
                        <div ng-switch-when="numeric" ng-switch="cellCtrl.cellvm.IsEditable" ng-style="cellCtrl.getStyle()" class="numeric-cell">
                            <input ng-switch-when="true" type="text" ng-style="cellCtrl.getStyle()" class="k-textbox numeric" ng-model="cellCtrl.cellvm.Value" ng-change="cellCtrl.onNumChange()" ng-blur="cellCtrl.onBlur()" ng-focus="cellCtrl.onFocus()" maxlength="{{cellCtrl.cellvm.MaxChars}}"/>
                            <div ng-switch-when="false" style="padding-right:5px">
                                {{cellCtrl.cellvm.Value}}
                            </div>
                        </div>
                        
                        <div ng-switch-when="percent" ng-switch="cellCtrl.cellvm.IsEditable"  ng-style="cellCtrl.getStyle()" class="percent-cell">
                            <div ng-switch-when="true">
                                <input type="text" class="k-textbox percent" style="width:85%;color:inherit;text-decoration-color:inherit;text-align:inherit;" ng-model="cellCtrl.cellvm.Value"  ng-change="cellCtrl.onPercentChange()" ng-blur="cellCtrl.onBlur()" ng-focus="cellCtrl.onFocus()" maxlength="{{cellCtrl.cellvm.MaxChars}}" /> 
                                <span style="width:15%"> %
                                </span>
                            </div>
                            <div ng-switch-when="false" style="padding-right:5px">
                               {{cellCtrl.cellvm.Value}} %
                           </div>
                        </div>
                        
                        <div ng-switch-when="postit">
                            <i class="fa fa-map-pin fa-lg" style="cursor:pointer" ng-click="cellCtrl.editPostIt()"></i>
                        </div>
                        
                        <div ng-switch-when="narrative">
                            <i class="fa fa-sticky-note fa-lg" style="cursor:pointer" ng-click="cellCtrl.editNarrative()"></i>
                        </div>
                        
                        <div ng-switch-when="blank">
                        </div>
                    </div>
                    `
            ,
            controllerAs: 'cellCtrl',
            controller: ['modelService', 'calcService', '$element', EasCellController],
            bindings: {
                cellvm: '<'
            }
        })
        .controller('gridController', ['$attrs', 'modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', 'calcService', 'addRowService', RowController]);
}