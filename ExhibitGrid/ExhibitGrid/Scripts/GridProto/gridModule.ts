(function () {
    'use strict'
    var exhibitApp = angular.module('exhibitGrid', ['exhibitGrid.modelService', 'exhibitGrid.directives']);


    exhibitApp.controller('exhibitGridController', ['gridModelService', function (gridModelService) {
        var ctrlVm = this;

        ctrlVm.model = gridModelService.getModel();

        ctrlVm.addRow = function () {
            gridModelService.addAnotherRow();
        }

        ctrlVm.addCol = function () {
            gridModelService.addAnotherColumn();
        }

    }]);
} ())