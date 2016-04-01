/// <reference path="../typings/angularjs/angular.d.ts" />


module Eas {
    export class Component {
        SelectCell;
        TextCell;
        NumericCell;        
        constructor(ng) {
            this.SelectCell =
                ng.core
                    .Component({
                        selector: "[easSelectCell]",
                        template: `<input type="checkbox" />`,
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
    }
}