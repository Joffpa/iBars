/// <reference path="../typings/angularjs/angular.d.ts" />

"use strict";

module CellApp {

    export class GridController {

        GridVm: ExhibitGrid.ViewModel.IGridVm;
        ModelService: app.model.IModelService;

        constructor($attrs, modelService: app.model.IModelService) {
            console.log($attrs.gridCode);
            this.ModelService = modelService;
            var gridCode = $attrs.gridcode;
            this.GridVm = this.ModelService.getGridVm(gridCode);
        }
    }

    export class RowController {

        RowVm: ExhibitGrid.ViewModel.IRowVm;
        ModelService: app.model.IModelService;
        CalcService: app.calc.ICalcService;

        constructor($scope, modelService: app.model.IModelService, calcService: app.calc.ICalcService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
            this.CalcService = calcService;
        }

        collapseChildren() {
            this.ModelService.collapseChildren(this.RowVm.GridCode, this.RowVm.RowCode);
        }

        addRow() {
            alert('row added: ' + this.RowVm.RowCode);
        }

        deleteRow() {
            alert('row deleted: ' + this.RowVm.RowCode);
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
            this.CalcService.runCellCalcs(this.cellvm);
        }

        onPercentChange() {
            this.CalcService.runCellCalcs(this.cellvm);
        }

        onBlur() {
            this.ModelService.formatCellNumber(this.cellvm);
        }


        onFocus() {
            console.log("unformat");
            this.ModelService.unformatCellNumber(this.cellvm);
        }

        $postLink() {
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
        .module('app', ['app.model', 'app.calc', 'app.filters'])
        .component('easCell', {
            template: `
                    <div ng-switch="cellCtrl.cellvm.Type" data-toggle="tooltip" title="This is some very long tooltip text to confirm the tooltip works">
                        <div ng-switch-when="text" ng-switch="cellCtrl.cellvm.IsEditable" ng-style='cellCtrl.getStyle()' class="indent-{{cellCtrl.cellvm.Alignment}}-{{cellCtrl.cellvm.Indent}} text-cell-th" >
                            <input type="text" class='k-textbox' ng-switch-when='true' ng-model='cellCtrl.cellvm.Value'/>
                            <div ng-switch-when='false'>
                                {{cellCtrl.cellvm.Value}}
                            </div>
                        </div>
                        
                        <div ng-switch-when="numeric" ng-switch="cellCtrl.cellvm.IsEditable" ng-style="cellCtrl.getStyle()" class="numeric-cell">
                            <input ng-switch-when="true" type="text" class="k-textbox numeric" ng-model="cellCtrl.cellvm.Value" ng-change="cellCtrl.onNumChange()" ng-blur="cellCtrl.onBlur()" ng-focus="cellCtrl.onFocus()" maxlength="{{cellCtrl.cellvm.MaxChars}}"/>
                            <div ng-switch-when="false" style="padding-right:5px" ng-class="parseFloat(cellCtrl.cellvm.Value) < 0 ? 'negative-val' : 'positive-val'">
                                {{cellCtrl.cellvm.Value | negativeInParens}}
                            </div>
                        </div>
                        
                        <div ng-switch-when="percent" ng-switch="cellCtrl.cellvm.IsEditable"  ng-style="cellCtrl.getStyle()" class="percent-cell">
                            <div ng-switch-when="true">
                                <input type="text" class="k-textbox percent" ng-model="cellCtrl.cellvm.Value"  ng-change="cellCtrl.onPercentChange()" ng-blur="cellCtrl.onBlur()" ng-focus="cellCtrl.onFocus()" maxlength="{{cellCtrl.cellvm.MaxChars}}" />%
                            </div>
                            <div ng-switch-when="false" style="padding-right:5px" ng-class="parseFloat(cellCtrl.cellvm.Value) < 0 ? 'negative-val' : 'positive-val'">
                               {{cellCtrl.cellvm.Value | negativeInParens}} %
                           </div>
                        </div>
                        
                        <div ng-switch-when="postit">
                            <i class="fa fa-map-pin fa-lg" style="cursor:pointer" ng-click="cellCtrl.editPostIt()"></i>
                        </div>
                        
                        <div ng-switch-when="narrative">
                            <i class="fa fa-sticky-note fa-lg" style="cursor:pointer" ng-click="cellCtrl.editNarrative()"></i>
                        </div>
                        
                        <div ng-switch-when="dropdown">
                            <input id="{{cellCtrl.cellvm.GridCode + '_' + cellCtrl.cellvm.RowCode + '_' + cellCtrl.cellvm.ColCode}}" ng-model="cellCtrl.cellvm.Text"/>
                        </div>
                        
                        <div ng-switch-when="blank">
                        </div>
                    </div>
                    `
            ,
            controllerAs: 'cellCtrl',
            controller: EasCellController,
            bindings: {
                cellvm: '<'
            }
        })
        .controller('gridController', ['$attrs', 'modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', 'calcService', RowController]);
}