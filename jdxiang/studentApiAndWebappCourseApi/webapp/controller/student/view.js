'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:StudentViewCtrl
 * @description
 * # StudentViewCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
  .controller('StudentViewCtrl', function ($scope, $state, student) {
    var self = this;
    self.init = function() {
    	$scope.student = {};
    	student.getById($state.params.id, function(data) {
    		$scope.student = data;
    	});
    };
    self.init();
  });
