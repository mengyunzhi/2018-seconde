'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:KlassAddCtrl
 * @description
 * # KlassAddCtrl
 * 班级管理  增加
 */
angular.module('pjqApp')
  .controller('KlassAddCtrl', function($scope, $http, $state, klass) {
    var self = this;
    self.init = function() {
      $scope.data = {
        name: '',
        teacher: {}
      };
    };

    self.submit = function() {
      var url = '/Klass/';
      $http.post(url, $scope.data)
        .then(function success(response) {
          $state.transitionTo('klass', {}, { reload: true });
          console.log('增加成功');
        }, function error() {
          console.log('增加失败');
        });

    };

    self.init();
    $scope.submit = self.submit;
  });
