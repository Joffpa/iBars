
//import '.exhibit-grid.component.d.ts'
import {Component} from 'angular2/core'
//import {ExhibitGridComponent} from './exhibit-grid.component'
var grid = require('exhibit-grid.component');

 
@Component({
    selector: 'my-app',
    template:`
        <h1>My First Angular 2 App</h1>
        <exhibit-grid></exhibit-grid>
        `,
    directives: [grid.ExhibitGridComponent]
})
export class AppComponent {
    testprop: string;
}

