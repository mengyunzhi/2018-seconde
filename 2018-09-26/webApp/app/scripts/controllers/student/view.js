'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:StudentViewCtrl
 * @description
 * # StudentViewCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
    .controller('StudentViewCtrl', function($http, $scope, $stateParams) {
        var self = this;
        self.init = function() {
            var id = $stateParams.id;
            var url = '/Student/' + id;

            $http.get(url)
                .then(function success(response) {
                    $scope.data = response.data;
                }, function error() {
                    console.log('error');
                });
        };
        self.init();
    });
