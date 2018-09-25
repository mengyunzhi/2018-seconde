'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:StudentIndexCtrl
 * @description
 * # StudentIndexCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
    .controller('StudentIndexCtrl', function($scope, $http, student) {
        var self = this;
        self.init = function() {
            var url = '/Student/';
            $http.get(url)
                .then(function success(response) {
                    $scope.student = response.data;
                }, function error() {
                    console.log('error');
                });
        }
    });
