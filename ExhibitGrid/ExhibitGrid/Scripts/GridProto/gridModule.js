'use strict';
var app;
(function (app) {
    var ExhibitController = (function () {
        function ExhibitController(modelService) {
            this.modelService = modelService;
            this.model = modelService.getExhibitModel();
        }
        ExhibitController.prototype.doExhibitLevelWork = function () {
            return true;
        };
        return ExhibitController;
    })();
    app.ExhibitController = ExhibitController;
    var GridController = (function () {
        function GridController(modelService) {
            this.modelService = modelService;
            var ctrlVm = this;
            this.model = modelService.getGridModel('');
        }
        GridController.prototype.addRow = function () {
            this.modelService.addAnotherRow('');
        };
        GridController.prototype.addCol = function () {
            this.modelService.addAnotherColumn('');
        };
        return GridController;
    })();
    var exhibitApp = angular.module('app', ['app.model', 'app.directives', 'app.calc']);
    exhibitApp.controller('exhibitController', ['modelService', ExhibitController]);
})(app || (app = {}));
//# sourceMappingURL=gridModule.js.map