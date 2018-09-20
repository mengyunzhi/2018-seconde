'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:KlassViewCtrl
 * @description
 * # KlassViewCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
	.controller('KlassViewCtrl', function($scope, $stateParams, klass) {
		var self = this;
		self.init = function() {
			$scope.klass = {
				name: '',
				username: '',
				sex: true,
				teacher: {}
			};
			klass.get($stateParams.id, function(data) {
				$scope.klass = data;
			});
		};
		self.init();
	});