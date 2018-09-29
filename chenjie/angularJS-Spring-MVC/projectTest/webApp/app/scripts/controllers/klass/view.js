'use strict';

/**
 * @ngdoc function
 * @name webApp.controller:KlassViewCtrl
 * @description
 * # KlassViewCtrl
 * Controller of the webApp
 */
angular.module('webApp')
  .controller('KlassViewCtrl', function($stateParams, $scope, $http) {
    var self = this;
    self.init = function() {
      //接受ID
      var id = $stateParams.id;
      //使用这个ID去请求信息
      var url = '/Klass/' + id;
      $http.get(url).
      then(function success(response) {
        //将请求来的信息绑定给V层
        $scope.klass = response.data;
        console.log(response);

      }, function error(response) {
        console.log(url + 'viewError');
        console.log(response);
      });
    };

    self.init();
  });
