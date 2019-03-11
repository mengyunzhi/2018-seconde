'use strict';

/**
 * @ngdoc function
 * @name webAppApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the webAppApp
 */
angular.module('webAppApp')
  .controller('MainCtrl', function($scope, $http, $state) {
    var self = this;
    self.init = function() {
      var url = '/Teacher';

      $http.get(url)
        .then(function success(response) {
          $scope.lists = response.data;
        }, function error() {
          console.log('error');
        });
    };


    self.delete = function(teacher) {
      var url = '/Teacher/' + teacher.id;
      $http.delete(url)
        .then(function success() {
          $state.reload();
        }, function error() {
          console.log('删除失败');
        });
    };

    self.init();
    $scope.delete = self.delete;

  });
