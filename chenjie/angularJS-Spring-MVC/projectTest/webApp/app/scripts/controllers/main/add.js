'use strict';

/**
 * @ngdoc function
 * @name webApp.controller:MainAddCtrl
 * @description
 * # MainAddCtrl
 * Controller of the webApp
 */
angular.module('webApp')
  .controller('MainAddCtrl', function($scope,$http,$state) {
    //初始化操作
    var self = this;
    self.init = function() {
      $scope.teacher = {
        username: '',
        name: '',
        sex: 'true',
        email: ''
      };
    };

    self.submit = function() {
       
    	//进行数据的提交
    	var url = '/Teacher/';
    	$http.post(url,$scope.teacher)
    	.then(function success(response) {
            //进行跳转
    		$state.transitionTo('main',{},{reload: true});
    		console.log('addSuccess');
    	}, function error(response) {
    		console.log('addError');
    	});   	
    };

    self.init();
    $scope.submit = self.submit;
  });
