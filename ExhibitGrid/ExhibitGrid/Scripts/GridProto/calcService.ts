/// <reference path="../typings/angularjs/angular.d.ts" />
module app.calc {

    'use strict'

    export class CalcService {

        constructor(modelService: app.model.IModelService) {
            
        }

    }
    
    var service = angular.module('app.calc', ['app.model']);
     
    
    service.factory('calcService', ['modelService', function (modelService) {
        return new CalcService(modelService);

    }]);
}
