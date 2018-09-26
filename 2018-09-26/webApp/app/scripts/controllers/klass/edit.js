'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:KlassEditCtrl
 * @description
 * # KlassEditCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
  .controller('KlassEditCtrl', function($scope, $http, $stateParams,$state, klass) {
    var self = this;
    self.init = function() {
      //获取当前编辑的ID
      var id = $stateParams.id;
      //用接收的ID去请求信息
      var url = '/Klass/' + id;
      $http.get(url)
        .then(function success(response) {
          $scope.data = response.data;
        }, function error() {
          console.log('error');
        });
    };

    //提交数据
    self.submit = function() {
      var id = $stateParams.id;
      var url = '/Klass/' + id;
      $http.put(url, $scope.data)
        .then(function success() {
          $state.transitionTo('klass', {}, { reload: true });
          console.log('更新成功');
        }, function error() {
          console.log('更新失败');
        });
    };

    self.init();
    $scope.submit = self.submit;
  });
