
//import '.exhibit-grid.component.d.ts'
import {Component, View, DynamicComponentLoader, ElementRef, Injectable, Inject} from 'angular2/core'
import {EasRowComponent} from './eas-row.component'
import {GridModelService} from './grid-model.service'
//var grid = require('exhibit-grid.component');


@Component({
    selector: '[easApp]',
    providers: [GridModelService],
    inputs: ['gridCode']
})
@View({ 
    template: "<tr><td>one</td><td>two</td></tr>",
    directives: [EasRowComponent]
})
export class EasAppComponent {
    GridVm: ExhibitGrid.ViewModel.IGridVm;
    gridCode: string;
    constructor( @Inject(ElementRef) elementRef: ElementRef) {
        var native = elementRef.nativeElement;
        this.gridCode = native.getAttribute("gridCode");
        console.log(this.gridCode);
    }
}


