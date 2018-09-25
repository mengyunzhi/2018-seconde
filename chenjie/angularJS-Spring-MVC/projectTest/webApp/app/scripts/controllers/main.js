'use strict';

/**
 * @ngdoc function
 * @name webApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the webApp
 */
// webApp模块中定义一个名为'MainCtrl'的控制器
angular.module('webApp')
  .controller('MainCtrl', function($scope, $http, $state) {
    var self = this;

    //初始化界面
    self.init = function() {
      //定义url请求地址
      var url = 'http://127.0.0.1:8080/Teacher'; //http请求地址
      // 调用这个对象的then方法，当上面的请求成功时，调用第一个参数(success)，
      // 并且把请求的信息给success方法的第一个参数
      // 当请求失败时，调用第二个方法error
      $http.get(url)
        .then(function success(response) {
          $scope.teachers = response.data;
          console.log('mainSuccess');
        }, function error(response) {
          console.log(url + 'mainError');
          console.log(response);
        });
    };

    //定义删除方法
    self.delete = function(teacher) {
      var id = teacher.id;
      //使用这个ID去请求信息
      var url = 'http://127.0.0.1:8080/Teacher/' + id;
      $http.delete(url)
        .then(function success() {
          console.log('deletesuccess');
          $state.reload();
        }, function error() {
          console.log(url + 'deletEerror');

        });

    };

    self.init();
    $scope.delete = self.delete; //绑定删除方法


  });
