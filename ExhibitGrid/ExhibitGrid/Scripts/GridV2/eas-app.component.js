"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
//import '.exhibit-grid.component.d.ts'
var core_1 = require('angular2/core');
//import {EasRowComponent} from './eas-row.component'
//var grid = require('exhibit-grid.component');
var EasAppComponent = (function () {
    function EasAppComponent() {
    }
    EasAppComponent = __decorate([
        core_1.Component({
            selector: '[easApp]'
        }),
        core_1.View({
            template: window['dynamicRow'].Template
        })
    ], EasAppComponent);
    return EasAppComponent;
}());
exports.EasAppComponent = EasAppComponent;
//# sourceMappingURL=eas-app.component.js.map