'use strict';

/**
 * @ngdoc function
 * @name webAppApp.controller:KlassEditCtrl
 * @description
 * # KlassEditCtrl
 * Controller of the webAppApp
 */
angular.module('webAppApp')
  .controller('KlassEditCtrl', function ($scope, $http, $stateParams, $state, teacher) {
    var self = this;

    self.init = function() {
        var id = $stateParams.id;
        var url = '/Klass/' + id;
        $http.get(url)
        .then(function success(response) {
            $scope.data = response.data;
        }, function error(response) {
            console.log('请求失败' + url, response);
        });
    };


    self.submit = function() {
        var id = $stateParams.id;
        var url = '/Klass/' + id;

        $http.put(url, $scope.data)
        .then(function success(response) {
            $state.go('klass', {}, {reload: true}); 
        }, function error(response) {
            console.log('请求失败' + url, response);
        });
    };

    self.init();
    $scope.submit = self.submit;
  });
