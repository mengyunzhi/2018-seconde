'use strict';

/**
 * @ngdoc function
 * @name webApp.controller:KlassEditCtrl
 * @description
 * # KlassEditCtrl
 * Controller of the webApp
 */
angular.module('webApp')
  .controller('KlassEditCtrl', function($http, $state, $stateParams, $scope) {
    var self = this;
    self.init = function() {
      //根据ID实例化要编辑的Klass
      var id = $stateParams.id;
      //使用这个ID去请求信息
      var url = '/Klass/' + id;

      $http.get(url)
        .then(function success(response) {
          console.log('editSuccess');
          //将请求来的信息绑定给V层
          $scope.klass = response.data;

        }, function error(response) {
          console.log(url + 'editError');
          console.log(response);
        });
    };

    self.submit = function() {
      var id = $stateParams.id;
      var url = '/Klass/' + id;
      $http.put(url, $scope.klass)
        .then(function success(response) {
          //进行跳转
          $state.transitionTo('klass', {}, { reload: true });
          console.log("updatasuccess");
        }, function error(response) {
          console.log("updataerror");
        });
    };

    self.init();
    $scope.submit = self.submit;
  });
