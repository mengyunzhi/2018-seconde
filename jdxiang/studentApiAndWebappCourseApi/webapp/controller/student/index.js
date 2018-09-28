'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:StudentIndexCtrl
 * @description
 * # StudentIndexCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
  .controller('StudentIndexCtrl', function ($scope, $state, student) {
    var self = this;
    self.init = function() {
    	$scope.students = [];
    	student.getAll(function(data) {
    		$scope.students = data;
    	});
    };
    self.add = function() {
    	$state.go('student.add', {}, {reload: true});
    };
    self.delete = function(id) {
    	student.delete(id, function() {
    		$state.go('student', {}, {reload: true});
    	});
    };
    self.init();
    $scope.delete = self.delete;
    $scope.add = self.add;
  });
