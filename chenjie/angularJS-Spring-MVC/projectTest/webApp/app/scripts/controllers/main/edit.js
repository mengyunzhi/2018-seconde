'use strict';

/**
 * @ngdoc function
 * @name webApp.controller:MainEditCtrl
 * @description
 * # MainEditCtrl
 * Controller of the webApp
 * 教师管理 编辑
 * 陈杰
 */
angular.module('webApp')
  .controller('MainEditCtrl', function($stateParams, $http, $scope,$state) {
    var self = this;
    self.init = function() {
      //根据ID实例化要编辑的Teacher
      var id = $stateParams.id;
      //使用这个ID去请求信息
      var url = 'http://127.0.0.1:8080/Teacher/' + id;
      $http.get(url)
        .then(function success(response) {
          console.log('editSuccess');
          //将请求来的信息绑定给V层
          $scope.teacher = response.data;

        }, function error(response) {
          console.log(url + 'editError');
          console.log(response);
        });
    };

    self.submit = function() {
      var id = $stateParams.id;
      var url = 'http://127.0.0.1:8080/Teacher/' + id;
      $http.put(url, $scope.teacher)
      	.then(function success(response) {
      		//进行跳转
    		$state.go('main',{},{reload: true});
      		console.log("updatasuccess");
      	}, function error(response) {
      		console.log("updataerror");
      	});
    };

    self.init();
    $scope.submit = self.submit;

  });
