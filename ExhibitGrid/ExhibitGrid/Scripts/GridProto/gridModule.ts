module app{

    interface IGridController {
        model: {},
        addRow(): void,
        addCol(): void,
        modelService: {}
    }

    class GridController implements IGridController{

        model: {};
        modelService: {};

        constructor(gridModelService) {
            var ctrlVm = this;

            this.model = gridModelService.getModel();

            this.modelService = gridModelService;

            ctrlVm.addRow = function () {
                gridModelService.addAnotherRow();
            }

            ctrlVm.addCol = function () {
                gridModelService.addAnotherColumn();
            }
        }

        addRow(): void {
            //this.modelService.addAnotherRow();
        }

        addCol(): void {
            //modelService.addAnotherColumn();
        }

    }


    'use strict'
    var exhibitApp = angular.module('exhibitGrid', ['exhibitGrid.modelService', 'exhibitGrid.directives']);


    exhibitApp.controller('exhibitGridController', ['gridModelService', GridController]);
}