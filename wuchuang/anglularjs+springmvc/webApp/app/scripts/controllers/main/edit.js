'use strict';

/**
 * @ngdoc function
 * @name webAppApp.controller:MainEditCtrl
 * @description
 * # MainEditCtrl
 * Controller of the webAppApp
 */
angular.module('webAppApp')
  .controller('MainEditCtrl', function($stateParams, $http, $scope, $state) {
    var self = this;
    self.init = function() {
        // 接受ID
        var id = $stateParams.id;
        // 使用ID请求信息
        var url = '/Teacher/' + id;
        $http.get(url)
        .then(function success(response) {
            // 绑定V层
            $scope.data = response.data;
        }, function error(response) {
            console.log(url+'error');
            console.log(response);
        });
    };

    self.submit = function() {
        var id = $stateParams.id;
        var url = '/Teacher/' + id;

        $http.put(url, $scope.data)
        .then(function success(response){
            console.log('更新成功')
            $state.go('main', {}, {reload: true});
        }, function error(response){
            console.log('更新失败')
        })
    }
    self.init();
    $scope.submit = self.submit;
  });
