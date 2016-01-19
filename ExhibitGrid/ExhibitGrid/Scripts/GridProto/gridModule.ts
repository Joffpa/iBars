
'use strict'

module app{

    export class ExhibitController {
        model: app.model.ExhibitVm;
        modelService: app.model.IModelService;

        constructor(modelService: app.model.IModelService) {
            this.modelService = modelService;
            this.model = modelService.getExhibitModel();
        }

        doExhibitLevelWork() {
            return true;
        }
                
    }
    
    class GridController{
        model;
        modelService: app.model.IModelService;

        constructor(modelService: app.model.IModelService) {
            this.modelService = modelService;
            var ctrlVm = this;
            this.model = modelService.getGridModel('');   
        }

        addRow(): void {
            this.modelService.addAnotherRow('');
        }

        addCol(): void {
            this.modelService.addAnotherColumn('');
        }
    }

    var exhibitApp = angular.module('app', ['app.model', 'app.directives', 'app.calc']);

    exhibitApp.controller('exhibitController', ['modelService', ExhibitController]);
}