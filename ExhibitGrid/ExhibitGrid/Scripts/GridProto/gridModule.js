var app;
(function (app) {
    var GridController = (function () {
        function GridController(gridModelService) {
            var ctrlVm = this;
            this.model = gridModelService.getModel();
            this.modelService = gridModelService;
            ctrlVm.addRow = function () {
                gridModelService.addAnotherRow();
            };
            ctrlVm.addCol = function () {
                gridModelService.addAnotherColumn();
            };
        }
        GridController.prototype.addRow = function () {
            //this.modelService.addAnotherRow();
        };
        GridController.prototype.addCol = function () {
            //modelService.addAnotherColumn();
        };
        return GridController;
    })();
    'use strict';
    var exhibitApp = angular.module('exhibitGrid', ['exhibitGrid.modelService', 'exhibitGrid.directives']);
    exhibitApp.controller('exhibitGridController', ['gridModelService', GridController]);
})(app || (app = {}));
//# sourceMappingURL=gridModule.js.map