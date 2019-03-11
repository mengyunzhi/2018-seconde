'use strict';

/**
 * @ngdoc function
 * @name webAppApp.controller:KlassIndexCtrl
 * @description
 * # KlassIndexCtrl
 * Controller of the webAppApp
 */
angular.module('webAppApp')
  .controller('KlassIndexCtrl', function($http, $scope, klass) {
    var self = this;
    self.init = function() {
        var url = '/Klass/';
        $http.get(url)
        .then(function success(response) {
            $scope.lists = response.data;
        }, function error(response) {
            console.log('请求错误');
        })
    };

    self.delete = function(object) {
        // 触发后台的删除操作
        klass.delete(object, function() {
            // 将元素隐藏
            object._delete = true;
        })     
    }
    self.init();
    $scope.delete = self.delete;
  });
