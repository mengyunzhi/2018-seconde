'use strict';

/**
 * @ngdoc function
 * @name webAppApp.controller:MainAddCtrl
 * @description
 * # MainAddCtrl
 * Controller of the webAppApp
 */
angular.module('webAppApp')
  .controller('MainAddCtrl', function ($scope, $http, $state) {
    // 初始化
    var self = this;
    self.init = function() {
        $scope.data = {
            username: '',
            name: '',
            sex: 'true',
            email: ''
        };
    };
    self.submit = function() {
        var url = '/Teacher/';
        $http.post(url, $scope.data)
        .then(function(response) {
            $state.go('main', {}, {reload: true});
        }, function(response) {
            console.log('error');
        });
    }

    self.init();
    $scope.submit = self.submit;
  });
