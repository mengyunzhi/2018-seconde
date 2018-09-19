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
  .controller('MainCtrl', function($scope, $http) {
    //定义url请求地址
    var url = 'http://127.0.0.1:8080/Teacher'; //http请求地址

    //请求成功执行代码
    var success = function(response) {
      $scope.teachers = response.data;
      console.log("success");
    };

    //请求失败执行代码
    var error = function(response) {
      console.log('error');
    };

    //发起请求，并获取一个primise对象
    var promise = $http.get(url);

    // 调用这个对象的then方法，当上面的请求成功时，调用第一个参数(success)，
    // 并且把请求的信息给success方法的第一个参数
    // 当请求失败时，调用第二个方法error
    promise.then(success, error);


  });
