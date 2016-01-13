module app{
    

    interface IGridController {
        model: app.model.IGridVm,
        modelService: app.model.IModelService,
        addRow(): void,
        addCol(): void
    }

    interface IExhibitController {
        
    }



    class GridController implements IGridController{

        model;
        modelService: app.model.IModelService;

        constructor(gridModelService: app.model.IModelService) {
            this.modelService = gridModelService;
            var ctrlVm = this;
            this.model = gridModelService.getGridModel('');   
        }

        addRow(): void {
            this.modelService.addAnotherRow('');
        }

        addCol(): void {
            this.modelService.addAnotherColumn('');
        }

    }


    interface IRowController {
        
    }


    'use strict'
    var exhibitApp = angular.module('exhibitGrid', ['exhibitGrid.modelService', 'exhibitGrid.directives']);


    exhibitApp.controller('exhibitGridController', ['gridModelService', GridController]);
}