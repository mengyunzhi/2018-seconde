'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:CourseIndexCtrl
 * @description
 * # CourseIndexCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
  .controller('CourseIndexCtrl', function ($scope, $state) {
    var self = this;
    self.add = function() {
    	$state.go('course.add', {}, {reload: true});
    };
    $scope.add = self.add;
  });
