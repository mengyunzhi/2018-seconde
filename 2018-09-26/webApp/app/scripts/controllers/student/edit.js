'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:StudentEditCtrl
 * @description
 * # StudentEditCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
    .controller('StudentEditCtrl', function($scope, $http, $stateParams, $state) {
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

        self.submit = function() {
            var id = $stateParams.id;
            var url = '/Student/' + id;
            $http.put(url, $scope.data)
                .then(function success() {
                	$state.transitionTo('Student', {}, {reload:true});
                    console.log('更新成功');
                }, function error() {
                    conlose.log('error');
                });
        };
        self.init();
        $scope.submit = self.submit;
    });
