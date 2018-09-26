'use strict';

/**
 * @ngdoc function
 * @name webApp.controller:KlassAddCtrl
 * @description
 * # KlassAddCtrl
 * Controller of the webApp
 * 班级管理 增加
 */
angular.module('webApp')
  .controller('KlassAddCtrl', function($scope, $http,$state) {

    // 需要获取所有教师信息的后台API
    // 需要一个保存班级信息的后台API
    // 
    var self = this;

    self.init = function() {
      $scope.klass = {
        name: '',
        teacher: {}
      };
      self.getAllTeachers();
      // self.submit();
    };
    /**
     * 获取所有教师
     * @Author   chen_jie
     * @DateTime 2018-09-26T11:31:10+0800
     * @return   {[type]}                 [description]
     */
    self.getAllTeachers = function() {
    	var url = 'http://127.0.0.1:8080/Teacher/';
    	$http.get(url)
    	.then(function success(response) {
    		$scope.teachers = response.data;
    	}, function error(response) {
    		console.log("请求教师列表错误");
    	});
    };

    self.submit = function() {
      var url = 'http://127.0.0.1:8080/Klass/';
      console.log('submit');
      $http.post(url, $scope.klass)
        .then(function success(response) {
          console.log(response);
          $state.transitionTo('klass', {}, { reload: true });
        }, function error() {
          console.log('请求教师列表发生错误');
        });
    };


    self.init();
    $scope.submit = self.submit;

  });
