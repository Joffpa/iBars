var app;
(function (app) {
    var components;
    (function (components) {
        angular.module('app.component', ['app.model', 'app.calc'])
            .component('textCell', ['modelService', function (modelService) {
                return {
                    template: "\n                <div ng-switch=\"$ctrl.CellVm.IsEditable\" class=\"indent-{{$ctrl.CellVm.Indent}} {{$ctrl.CellVm.Class}}\" ng-hide=\"$ctrl.CellVm.IsBlank\" ng-style=\"$ctrl.getStyle()\">\n                    <input type=\"text\" class=\"k-textbox\" ng-switch-when=\"true\" ng-model=\"$ctrl.CellVm.Value\" style=\"text-align:left\" />\n                    <div ng-switch-when=\"false\" style=\"text-align:left\">\n                        {{$ctrl.CellVm.Value}}\n                    </div>\n                </div>\n                ",
                    controller: ['modelService', app.TextCellController],
                    bindings: {
                        cellvm: '<'
                    }
                };
            }]);
    })(components = app.components || (app.components = {}));
})(app || (app = {}));
//# sourceMappingURL=app.component.js.map