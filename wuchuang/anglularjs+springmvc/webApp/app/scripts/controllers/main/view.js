'use strict';

/**
 * @ngdoc function
 * @name webAppApp.controller:MainViewCtrl
 * @description
 * # MainViewCtrl
 * Controller of the webAppApp
 */
angular.module('webAppApp')
  .controller('MainViewCtrl', function ($stateParams, $http, $scope) {
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
    self.init();
  });
