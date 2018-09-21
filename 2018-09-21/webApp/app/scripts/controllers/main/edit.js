'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:MainEditCtrl
 * @description
 * # MainEditCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
  .controller('MainEditCtrl', function($scope, $http, $state, $stateParams) {
    var self = this;
    self.init = function() {
      //获取要编辑的ID
      var id = $stateParams.id;
      //用接收的ID去请求信息
      var url = '/Teacher/' + id;
      $http.get(url)
        .then(function success(response) {
          $scope.data = response.data;
        }, function error(response) {
          consloe.log(url + 'error');

        });
    };

    self.submit = function() {
      var id = $stateParams.id;
      var url = '/Teacher/' + id;
      $http.put(url, $scope.data)
        .then(function success(response) {
          $state.go('main', {}, { reload: true });
          console.log('更新成功');
        }, function error(response) {
          console.log('更新失败');
        });
    };
    self.init();
    $scope.submit = self.submit;
  });
