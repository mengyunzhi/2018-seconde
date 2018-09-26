'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:MainAddCtrl
 * @description
 * # MainAddCtrl
 * Controller of the pjqApp
 * 教师管理 增加
 */
angular.module('pjqApp')
  .controller('MainAddCtrl', function($scope, $http, $state) {
    //初始化
    var self = this;
    self.init = function() {
      $scope.data = {
        username: '',
        name: '',
        email: '',
        sex: 'true'
      };
    };

    self.submit = function() {
      //把数据提交到/Teacher/地址，方法为post
      var url = '/Teacher/';
      $http.post(url, $scope.data)
        .then(function(response) {
          $state.go('main', {}, { reload: true });
          console.log('增加成功')
        }, function(response) {
          console.log('增加失败');
        });
    };

    self.init();
    $scope.submit = self.submit;
  });
