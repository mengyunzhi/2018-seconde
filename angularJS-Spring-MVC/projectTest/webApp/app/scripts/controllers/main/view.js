'use strict';

/**
 * @ngdoc function
 * @name testApp.controller:MainViewCtrl
 * @description
 * # MainViewCtrl
 * Controller of the testApp
 */
angular.module('webApp')
  .controller('MainViewCtrl', function($stateParams, $http,$scope) {
    var self = this;
    self.init = function() {
      //接受ID
      var id = $stateParams.id;
      //使用这个ID去请求信息
      var url = 'http://127.0.0.1:8080/Teacher/' + id;
      $http.get(url).
      then(function success(response) {
        console.log('viewSuccess');
        //将请求来的信息绑定给V层
        $scope.teacher = response.data;
        
      }, function error(response) {
        console.log(url + 'viewError');
        console.log(response);
      });

    };

    //调用init方法来初始化
    self.init();
    
  });
