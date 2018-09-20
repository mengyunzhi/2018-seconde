'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:KlassAddCtrl
 * @description
 * # KlassAddCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
  .controller('KlassAddCtrl', function ($scope, $state, klass, teacher) {
    var self = this;
    self.init = function() {
    	$scope.teacheres = [];
    	$scope.klass = {
    		name: '',
    		username: '',
    		sex: ''
    	};
    	teacher.getAllTeacher(function(data) {
    		$scope.teacheres = data;
    	});
    };
    self.add = function() {
    	klass.add($scope.klass, function() {
    		$state.go('klass', {}, {reload: true});
    	});
    };
    $scope.submit = self.add;
    self.init();
  });
