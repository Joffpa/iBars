
//import '.exhibit-grid.component.d.ts'
import {Component, View, DynamicComponentLoader, ElementRef, Injectable, Inject, Input} from 'angular2/core'
//import {EasRowComponent} from './eas-row.component'
//import {GridModelService} from './grid-model.service'
//var grid = require('exhibit-grid.component');

//import {TemplateService} from './eas-template.service'
var appSelector = window['appSelector'];
var appTemplate = window['appTemplate'];

@Component({
    selector: appSelector,
    //providers: [GridModelService],
    inputs: ['gridCode']
}) 
@View({ 
    template: appTemplate,
    //directives: [EasRowComponent]
})
export class EasAppComponent {

    GridVm: ExhibitGrid.ViewModel.IGridVm;
    @Input()
    gridCode: string;
    constructor( @Inject(ElementRef) elementRef: ElementRef) {
        var native = elementRef.nativeElement;
        this.gridCode = native.getAttribute("gridCode");
    }
}

