
//import '.exhibit-grid.component.d.ts'
import {Component, View, DynamicComponentLoader, ElementRef} from 'angular2/core'
//import {EasRowComponent} from './eas-row.component'
//var grid = require('exhibit-grid.component');

 
@Component({
    selector: '[easApp]'
})
@View({
        template:  window['dynamicRow'].Template
        //,
        //directives: [window["dynamicRow"].EasRowComponent]
})
export class EasAppComponent {

}


