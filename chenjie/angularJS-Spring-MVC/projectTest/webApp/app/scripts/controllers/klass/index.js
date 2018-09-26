'use strict';

/**
 * @ngdoc function
 * @name webApp.controller:KlassIndexCtrl
 * @description
 * # KlassIndexCtrl
 * Controller of the webApp
 * 班级管理首页 
 */
angular.module('webApp')
  .controller('KlassIndexCtrl', function($scope,$http,$state) {
    var self = this;
    self.init = function() {
      //定义url请求地址
      var url = 'http://127.0.0.1:8080/Klass/';
      
      $http.get(url)
        .then(function success(response) {
          $scope.klasses = response.data;
          console.log('klassIndexSuccess');
        }, function error(response) {
          console.log(url + 'klassIndexError');
          console.log(response);
        });
    }

    /**
     * 删除
     * @param  {[type]} object 要删除的对象
     * @return {}
     * panjie
     */
    self.delete = function(object) {
      // 应该去触发后台的删除操作
      klass.delete(object, function() {
        // 将元素隐藏掉
        object._delete = true;
      });
    };

    self.init();
    $scope.delete = self.delete;
  });
