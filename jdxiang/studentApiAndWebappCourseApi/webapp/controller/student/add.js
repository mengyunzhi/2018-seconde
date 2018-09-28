'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:StudentAddCtrl
 * @description
 * # StudentAddCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
  .controller('StudentAddCtrl', function ($scope, $state, klass, student) {
   	var self = this;	
   	self.init = function() {
   		$scope.student = {};
   		klass.getAll(function(data) {
   			$scope.klasses = data;
   		});
   	};
   	self.submit = function() {
   		student.add($scope.student, function() {
   			$state.go('student', {}, {reload: true});
   		});
   	};
   	self.init();
   	$scope.submit = self.submit;
  });
