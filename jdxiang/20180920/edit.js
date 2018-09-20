'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:KlassEditCtrl
 * @description
 * # KlassEditCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
  .controller('KlassEditCtrl', function ($scope, $stateParams, $state, klass, teacher) {
    var self = this;
    self.init = function() {
    	$scope.klass = {
    		name: '',
    		username: '',
    		teacher: {},
    		sex: true
    	};
    	klass.get($stateParams.id, function(data) {
    		$scope.klass = data;
    	});
    	teacher.getAllTeacher(function(data) {
    		$scope.teacheres = data;
    	});
    };
    self.submit = function() {
    	klass.updata($stateParams.id, $scope.klass, function() {
    		$state.go('klass', {}, {reload: true});
    	});
    };
    $scope.submit = self.submit;
    self.init();
  });
