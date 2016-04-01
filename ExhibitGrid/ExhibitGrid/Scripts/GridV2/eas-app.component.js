"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
//import '.exhibit-grid.component.d.ts'
var core_1 = require('angular2/core');
//import {EasRowComponent} from './eas-row.component'
//import {GridModelService} from './grid-model.service'
//var grid = require('exhibit-grid.component');
//import {TemplateService} from './eas-template.service'
var appSelector = window['appSelector'];
var appTemplate = window['appTemplate'];
var EasAppComponent = (function () {
    function EasAppComponent(elementRef) {
        var native = elementRef.nativeElement;
        this.gridCode = native.getAttribute("gridCode");
    }
    __decorate([
        core_1.Input()
    ], EasAppComponent.prototype, "gridCode", void 0);
    EasAppComponent = __decorate([
        core_1.Component({
            selector: appSelector,
            //providers: [GridModelService],
            inputs: ['gridCode']
        }),
        core_1.View({
            template: appTemplate,
        }),
        __param(0, core_1.Inject(core_1.ElementRef))
    ], EasAppComponent);
    return EasAppComponent;
}());
exports.EasAppComponent = EasAppComponent;
//# sourceMappingURL=eas-app.component.js.map