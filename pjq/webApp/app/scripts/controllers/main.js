'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the pjqApp
 */
// testApp模块中定义一个名为'MainCtrl'的控制器
angular.module('pjqApp')
  .controller('MainCtrl', function($scope, $http, $state) {
    var self = this;
    self.init = function() {
      var url = '/Teacher';

      $http.get(url)
        .then(function success(response) {
          $scope.list = response.data;
        }, function error() {
          console.log('error');
        });
    };
    
    //删除
    self.delete = function(teacher) {
      var url = '/Teacher/' + teacher.id;
      $http.delete(url)
        .then(function success() {
          $state.reload();
          console.log('删除成功');
        }, function error() {
          console.log('删除失败');
        });
    };

    self.init();
    $scope.delete = self.delete;
  });
