'use strict';

/**
 * @ngdoc directive
 * @name pjqApp.directive:lists
 * @description
 * # lists
 */
angular.module('pjqApp')
  .directive('listKlass', function(teacher) {
    var self = {};
    //获取所有教师
    self.getAllTeacher = function($scope) {
      teacher.getAllTeacher(function(teachers) {
        $scope.teachers = teachers;
      });
    };

    return {
      templateUrl: 'views/directives/listKlass.html',
      restrict: 'E',
      link: function postLink(scope) {
        self.getAllTeacher(scope);
      }
    };
  });
