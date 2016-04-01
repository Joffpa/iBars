
module app.components {
    
    angular.module('app.component', ['app.model', 'app.calc'])
        .component('textCell', ['modelService', function (modelService) {
            return {
                template: `
                <div ng-switch="$ctrl.CellVm.IsEditable" class="indent-{{$ctrl.CellVm.Indent}} {{$ctrl.CellVm.Class}}" ng-hide="$ctrl.CellVm.IsBlank" ng-style="$ctrl.getStyle()">
                    <input type="text" class="k-textbox" ng-switch-when="true" ng-model="$ctrl.CellVm.Value" style="text-align:left" />
                    <div ng-switch-when="false" style="text-align:left">
                        {{$ctrl.CellVm.Value}}
                    </div>
                </div>
                `,
                controller: ['modelService', app.TextCellController],
                bindings: {
                    cellvm: '<'
                }
            }
    }]);

}