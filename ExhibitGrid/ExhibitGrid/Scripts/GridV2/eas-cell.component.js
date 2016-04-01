/// <reference path="../typings/angularjs/angular.d.ts" />
var Eas;
(function (Eas) {
    var Component = (function () {
        function Component(ng) {
            this.SelectCell =
                ng.core
                    .Component({
                    selector: "[easSelectCell]",
                    template: "<input type=\"checkbox\" />",
                    inputs: ["RowVm"],
                    directives: [
                        ng.common.COMMON_DIRECTIVES,
                        ng.common.FORM_DIRECTIVES
                    ]
                })
                    .Class({
                    constructor: function () {
                        this.RowVm;
                    },
                });
            this.TextCell =
                ng.core
                    .Component({
                    selector: "[easTextCell]",
                    template: "<div>{{CellVm.Value}}</div>",
                    inputs: ["CellVm"]
                })
                    .Class({
                    constructor: function () {
                        this.CellVm;
                    },
                });
            this.NumericCell =
                ng.core
                    .Component({
                    selector: "[easNumericCell]",
                    template: "<div>{{CellVm.Value}}</div>",
                    inputs: ["CellVm"]
                })
                    .Class({
                    constructor: function () {
                        this.CellVm;
                    },
                });
        }
        return Component;
    }());
    Eas.Component = Component;
})(Eas || (Eas = {}));
//# sourceMappingURL=eas-cell.component.js.map