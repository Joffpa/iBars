var app;
(function (app) {
    var GridController = (function () {
        function GridController(gridModelService) {
            this.modelService = gridModelService;
            var ctrlVm = this;
            this.model = gridModelService.getGridModel('');
        }
        GridController.prototype.addRow = function () {
            this.modelService.addAnotherRow('');
        };
        GridController.prototype.addCol = function () {
            this.modelService.addAnotherColumn('');
        };
        return GridController;
    })();
    'use strict';
    var exhibitApp = angular.module('exhibitGrid', ['exhibitGrid.modelService', 'exhibitGrid.directives']);
    exhibitApp.controller('exhibitGridController', ['gridModelService', GridController]);
})(app || (app = {}));
//# sourceMappingURL=gridModule.js.map