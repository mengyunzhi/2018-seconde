'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:CourseIndexCtrl
 * @description
 * # CourseIndexCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
    .controller('CourseIndexCtrl', function($http, $scope) {
        var self = this;
        self.init = function() {
            var url = '/Course/';
            $http.get(url)
                .then(function success(response) {
                    $scope.course = response.data;
                }, function error() {
                    console.log('error');
                });
        };
        self.init();
    });
