'use strict';
var app;
(function (app) {
    var GridController = (function () {
        function GridController(modelService) {
            this.ModelService = modelService;
            this.GridVm = this.ModelService.getGridVm('MockGrid');
        }
        return GridController;
    })();
    app.GridController = GridController;
    var RowController = (function () {
        function RowController($scope, modelService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
        }
        RowController.prototype.addRow = function () {
            alert('row added: ' + this.RowVm.RowCode);
        };
        RowController.prototype.deleteRow = function () {
            alert('row deleted: ' + this.RowVm.RowCode);
        };
        return RowController;
    })();
    app.RowController = RowController;
    var TextCellController = (function () {
        function TextCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        return TextCellController;
    })();
    app.TextCellController = TextCellController;
    var NumericCellController = (function () {
        function NumericCellController($scope, modelService) {
            //console.log($scope.cellVm);
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
            if (this.CellVm.ColCode.indexOf('Col_') >= 0) {
                //NOTE: the calcs are hacked in to repeat a pattern of column level calcs every three columns.
                //There is also a total row calc
                var colNum = parseInt(this.CellVm.ColCode.replace('Col_', ''));
                var thisRow = this.CellVm.RowCode;
                var totalRow = 'Row_1'; //the row that holds the total row result
                //col 0
                if (colNum % 3 == 0 && this.CellVm.RowCode != totalRow) {
                    var nextCol = 'Col_' + (colNum + 1);
                    var nextNextCol = 'Col_' + (colNum + 2);
                    $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                        scope.cellCtrl.ModelService.updateCellValue('MockGrid', thisRow, nextNextCol, newVal + scope.cellCtrl.ModelService.getCellValue('MockGrid', thisRow, nextCol));
                    });
                } //col 1
                else if (colNum % 3 == 1 && this.CellVm.RowCode != totalRow) {
                    $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                        var nextCol = 'Col_' + (colNum + 1);
                        var prevCol = 'Col_' + (colNum - 1);
                        scope.cellCtrl.ModelService.updateCellValue('MockGrid', thisRow, nextCol, newVal + scope.cellCtrl.ModelService.getCellValue('MockGrid', thisRow, prevCol));
                    });
                }
                if (this.CellVm.RowCode != totalRow) {
                    $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                        scope.cellCtrl.ModelService.updateCellValue('MockGrid', totalRow, scope.cellVm.ColCode, scope.cellCtrl.ModelService.sumAllCellsInColForTotalRow('MockGrid', totalRow, scope.cellVm.ColCode));
                    });
                }
            }
        }
        return NumericCellController;
    })();
    app.NumericCellController = NumericCellController;
    var PostItCellController = (function () {
        function PostItCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        PostItCellController.prototype.editPostIt = function () {
            alert("Post it for cell: " + this.CellVm.RowCode + " " + this.CellVm.ColCode);
        };
        return PostItCellController;
    })();
    app.PostItCellController = PostItCellController;
    var NarrativeCellController = (function () {
        function NarrativeCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        NarrativeCellController.prototype.editNarrative = function () {
            alert("Narrative for cell: " + this.CellVm.RowCode + " " + this.CellVm.ColCode);
        };
        return NarrativeCellController;
    })();
    app.NarrativeCellController = NarrativeCellController;
    var DropdownCellController = (function () {
        function DropdownCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        return DropdownCellController;
    })();
    app.DropdownCellController = DropdownCellController;
    var exhibitApp = angular
        .module('app', ['app.model', 'app.directives'])
        .controller('gridController', ['modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', RowController])
        .controller('textCellController', ['$scope', 'modelService', TextCellController]);
})(app || (app = {}));
//# sourceMappingURL=grid.js.map