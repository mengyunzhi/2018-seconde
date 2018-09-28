'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:StudentEditCtrl
 * @description
 * # StudentEditCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
  .controller('StudentEditCtrl', function ($scope, $state, klass, student) {
    var self = this;
    self.init = function() {
    	self.id = $state.params.id;
    	$scope.student = {};
    	$scope.klasses = [];
    	student.getById(self.id, function(data) {
    		$scope.student = data;
    	});
    	klass.getAll(function(data) {
    		$scope.klasses = data;
    	});
    }();
    self.submit = function() {
    	student.update(self.id, $scope.student, function() {
    		$state.go('student', {}, {reload: true});
    	});
    };
    $scope.submit = self.submit;
  });
