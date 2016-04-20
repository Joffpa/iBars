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
            var style = {};
            style['text-align'] = this.cellvm.Alignment;
            if (this.cellvm.Width) {
                style['width'] = this.cellvm.Width;
            } else {
                style['width'] = '100%';
            }
            return style;
        }

        onChange() {
            if (this.cellvm.NumValue < 0) {

            }

            this.CalcService.runCellCalcs(this.cellvm);
        }

        onBlur() {

        }

        $postLink() {
            if (!this.cellvm.IsBlank && this.cellvm.Type == "dropdown") {
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
            alert(this.cellvm.Value);

        }
    }

    // ReSharper disable once TsResolvedFromInaccessibleModule
    var exhibitApp = angular
        .module('app', ['app.model', 'app.calc', 'app.filters'])
        .component('easCell', {
            template:`
                    <div ng-switch="cellCtrl.cellvm.Type">
                        <div ng-switch-when='text' ng-switch="cellCtrl.cellvm.IsEditable" ng-style='cellCtrl.getStyle()' class="indent-{{cellCtrl.cellvm.Indent}} text-cell-th" ng-if="!cellCtrl.cellvm.IsBlank">
                            <input type="text" class='k-textbox' ng-switch-when='true' ng-model='cellCtrl.cellvm.Value'/>
                            <div ng-switch-when='false'>
                                {{cellCtrl.cellvm.Value}}
                            </div>
                        </div>
                        
                        <div ng-switch-when='numeric' ng-switch="cellCtrl.cellvm.IsEditable" ng-if="!cellCtrl.cellvm.IsBlank" ng-style="cellCtrl.getStyle()" class="numeric-cell-td">
                            <input ng-switch-when="true" type="number" class="k-textbox numeric" ng-model="cellCtrl.cellvm.NumValue" style="text-align:right" ng-change="cellCtrl.onChange()" ng-blur="cellCtrl.onBlur()"/>
                            <div ng-switch-when="false" style="text-align:right; padding-right:5px" maxlength="8" ng-class="cellCtrl.cellvm.NumValue < 0 ? 'negative-val' : 'positive-val'">
                                {{cellCtrl.cellvm.Value | negativeInParens}}
                        </div>
                        
                        <div ng-switch-when='percent' ng-switch="cellCtrl.cellvm.IsEditable" ng-if="!cellCtrl.cellvm.IsBlank" ng-style="cellCtrl.getStyle()" class="numeric-cell-td">
                            <div ng-switch-when="true" style="width:100%">
                                <input type="number" class="k-textbox percent" ng-model="cellCtrl.cellvm.NumValue" style="text-align:right" ng-change="cellCtrl.onChange()" ng-blur="cellCtrl.onBlur()"/> %
                            </div>
                            <div ng-switch-when="false" style="text-align:right; padding-right:5px" maxlength="8" ng-class="cellCtrl.cellvm.NumValue < 0 ? 'negative-val' : 'positive-val'">
                               {{cellCtrl.cellvm.Value | negativeInParens}} %
                           </div>
                        </div>
                        
                        <div ng-switch-when='postit' ng-if="!cellctrl.cellvm.IsBlank">
                            <i class="fa fa-map-pin fa-lg" style="cursor:pointer" ng-click="cellCtrl.editPostIt()"></i>
                        </div>
                        
                        <div ng-switch-when='narrative' ng-if="!cellCtrl.cellvm.IsBlank">
                            <i class="fa fa-sticky-note fa-lg" style="cursor:pointer" ng-click="cellCtrl.editNarrative()"></i>
                        </div>
                        
                        <div ng-switch-when='dropdown' ng-if="!cellCtrl.cellvm.IsBlank">
                            <input id="{{cellCtrl.cellvm.GridCode + '_' + cellCtrl.cellvm.RowCode + '_' + cellCtrl.cellvm.ColCode}}" ng-model="cellCtrl.cellvm.Text"/>
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