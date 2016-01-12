

var app = angular.module('routing', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when('/routeA', {
        templateUrl: '/templates/routeA.html',
        controller: 'routeA'
    })
    .when('/routeB', {
        templateUrl: '/Home/RouteB',
        controller: 'routeB'
    });
    
}]);


app.controller('routeA', ['$scope', function ($scope) {

    var vm = $scope;

    vm.message = 'This is Route A';
    
}]);

app.controller('routeB', ['$scope', function ($scope) {

    var vm = $scope;

    vm.message = 'This is Route B';

}]);