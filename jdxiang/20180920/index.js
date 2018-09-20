'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:KlassIndexCtrl
 * @description
 * # KlassIndexCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
  .controller('KlassIndexCtrl', function ($scope, $state, klass) {
    var self = this;
    self.init = function() {
    	$scope.klasses = {};
    	klass.getAll(function(data) {
    		$scope.klasses = data;
    	});
    };
    self.add = function() {
    	$state.go('klass.add', {}, {reload: true});
    };
    self.delete = function(id) {
        klass.delete(id, function() {
            $state.go('klass', {}, {reload: true});
        });
    };
    $scope.delete = self.delete;
    $scope.add = self.add;
    self.init();
  });
