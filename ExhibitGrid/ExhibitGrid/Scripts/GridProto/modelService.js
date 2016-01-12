/// <reference path="../typings/lodash/lodash.d.ts" />
(function () {
    'use strict';
    var service = angular.module('exhibitGrid.modelService', []);
    service.factory('gridModelService', function () {
        var viewModel = {
            Cols: ['Col_Txt', 'Col_A', 'COL_B', 'COL_C'],
            Rows: [
                {
                    RowCode: 'Row_0', RowParents: null, RowClass: 'header-row', RowText: 'Header Text',
                    Cells: [
                        { ColCode: 'Col_Txt', CellClass: 'blank-cell', CellType: 'text', CellValue: null, CellWidth: '2x', IsEditable: false },
                        { ColCode: 'Col_A', CellClass: 'header-cell', CellType: 'text', CellValue: 'Column A', CellWidth: '1x', IsEditable: false },
                        { ColCode: 'Col_B', CellClass: 'header-cell', CellType: 'text', CellValue: 'Column B', CellWidth: '1x', IsEditable: false },
                        { ColCode: 'Col_C', CellClass: 'header-cell', CellType: 'text', CellValue: 'Column C', CellWidth: '1x', IsEditable: false }
                    ]
                },
                {
                    RowCode: 'Row_1', RowParents: null, RowClass: 'total-row', RowText: 'Row 1 text',
                    Cells: [
                        { ColCode: 'Col_Txt', CellClass: 'text-cell', CellType: 'text', CellValue: 'text', CellWidth: '2x', IsEditable: false },
                        { ColCode: 'Col_A', CellClass: 'data-cell', CellType: 'num', CellValue: 50, CellWidth: '1x', IsEditable: true },
                        { ColCode: 'Col_B', CellClass: 'data-cell', CellType: 'num', CellValue: 100, CellWidth: '1x', IsEditable: true },
                        { ColCode: 'Col_C', CellClass: 'data-cell', CellType: 'num', CellValue: 150, CellWidth: '1x', IsEditable: true }
                    ]
                },
                {
                    RowCode: 'Row_2', RowParents: ['Row_1'], RowClass: 'data-row', RowText: 'Row 2 text',
                    Cells: [
                        { ColCode: 'Col_Txt', CellClass: 'text-cell', CellType: 'text', CellValue: 'text', CellWidth: '2x', IsEditable: false },
                        { ColCode: 'Col_A', CellClass: 'data-cell', CellType: 'num', CellValue: 200, CellWidth: '1x', IsEditable: true },
                        { ColCode: 'Col_B', CellClass: 'data-cell', CellType: 'num', CellValue: 250, CellWidth: '1x', IsEditable: true },
                        { ColCode: 'Col_C', CellClass: 'data-cell', CellType: 'num', CellValue: 300, CellWidth: '1x', IsEditable: true }
                    ]
                },
                {
                    RowCode: 'Row_3', RowParents: ['Row_1'], RowClass: 'data-row', RowText: 'Row 3 text',
                    Cells: [
                        { ColCode: 'Col_Txt', CellClass: 'text-cell', CellType: 'text', CellValue: 'more text', CellWidth: '2x', IsEditable: true },
                        { ColCode: 'Col_A', CellClass: 'data-cell', CellType: 'num', CellValue: 350, CellWidth: '1x', IsEditable: true },
                        { ColCode: 'Col_B', CellClass: 'data-cell', CellType: 'num', CellValue: 400, CellWidth: '1x', IsEditable: true },
                        { ColCode: 'Col_C', CellClass: 'data-cell', CellType: 'num', CellValue: 450, CellWidth: '1x', IsEditable: true }
                    ]
                }
            ]
        };
        function S4() {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        }
        function GetGuid() {
            return (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
        }
        var logCounter = 0;
        return {
            getModel: function () {
                return viewModel;
            },
            getColumns: function () {
                return viewModel.Cols;
            },
            getChildRows: function (rowCode, pluckProp) {
                var rows = _.where(viewModel.Rows, { 'RowParents': [rowCode] });
                if (pluckProp) {
                    rows = _.pluck(rows, pluckProp);
                }
                return rows;
            },
            addAnotherRow: function () {
                var rowNum = viewModel.Rows.length;
                var cells = [];
                _.forEach(viewModel.Rows[0].Cells, function (va, idx) {
                    if (idx == 0) {
                        cells.push({
                            ColCode: 'Col_Txt', CellClass: 'text-cell', CellType: 'text', CellValue: 'Row ' + rowNum, CellWidth: '2x'
                        });
                    }
                    else {
                        cells.push({
                            ColCode: 'Col_' + String.fromCharCode(idx + 64), CellClass: 'data-cell', CellType: 'num', CellValue: 500, CellWidth: '1x'
                        });
                    }
                });
                viewModel.Rows.push({
                    RowCode: 'Row_' + rowNum, RowParents: null, RowClass: 'data-row', Cells: cells, RowText: 'Row ' + rowNum + ' Text'
                });
            },
            addAnotherColumn: function () {
                var colLetter = String.fromCharCode(viewModel.Rows[0].Cells.length + 64);
                _.forEach(viewModel.Rows, function (val, idx) {
                    if (idx == 0) {
                        val.Cells.push({
                            ColCode: 'Col_' + colLetter, CellClass: 'header-cell', CellType: 'text', CellValue: 'Column ' + colLetter, CellWidth: '1x', IsEditable: false
                        });
                    }
                    else {
                        val.Cells.push({
                            ColCode: 'Col_' + colLetter, CellClass: 'data-cell', CellType: 'num', CellValue: 800, CellWidth: '1x', IsEditable: true
                        });
                    }
                });
            },
            getCellValue: function (coordinate) {
            },
            logHelper: function (message) {
                console.log(logCounter + ': ' + message);
                logCounter++;
            }
        };
    });
})();
