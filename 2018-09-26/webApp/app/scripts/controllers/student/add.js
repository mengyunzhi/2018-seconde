'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:StudentAddCtrl
 * @description
 * # StudentAddCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
    .controller('StudentAddCtrl', function($scope, $http, $state) {
        var self = this;
        self.init = function() {
            $scope.data = {
                name: '',
                email: '',
                sex: '',
                klass: []
            };
        };

        self.submit = function() {
            var url = '/Student/';
            $http.post(url, $scope.data)
                .then(function success() {
                    $state.transitionTo('Student', {}, { reload: true });
                    console.log('增加成功');
                }, function error() {
                    console.log('error');
                });
        };
        self.init();
        $scope.submit = self.submit;
    });
