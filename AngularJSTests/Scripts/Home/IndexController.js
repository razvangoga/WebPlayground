'use strict';

var personsApp = angular.module('personsApp', []);
personsApp.directive('convertToNumber', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            ngModel.$parsers.push(function (val) {
                return parseInt(val, 10);
            });
            ngModel.$formatters.push(function (val) {
                return '' + val;
            });
        }
    };
});

personsApp.controller('personsController', function($scope, $http) {

    $scope.person = {};
    $scope.personId = 0;

    $http.get('/Home/GetPerson').then(personLoadSuccess, personLoadError);

    function personLoadSuccess(response) {
        $scope.person = response.data;
        console.log(response.data);
    };

    function personLoadError(response) {
        console.log(response);
    };

    this.save = function () {
        console.log($scope.person);
        console.log($scope.person.Name.$error.required);
        console.log($scope.personId);
    }
});