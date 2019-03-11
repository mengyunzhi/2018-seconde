'use strict';

/**
 * @ngdoc function
 * @name webAppApp.controller:KlassAddCtrl
 * @description
 * # KlassAddCtrl
 * Controller of the webAppApp
 */
angular.module('webAppApp')
  .controller('KlassAddCtrl', function ($scope, $http, $state, teacher) {
    // 获取所有教师信息后台
    // 保存班级信息后台
    
    var self = this;

    self.init = function() {
        $scope.data = {
            name: '',
            teacher: {}
        };
    }


    self.submit = function() {
        var url = '/Klass/';
        $http.post(url, $scope.data)
        .then(function success(response) {
            $state.transitionTo('klass', {}, {reload:true});
        }, function error(response) {
            console.log('请求错误');
        })
    }

    self.init();
    $scope.submit = self.submit;
  });
