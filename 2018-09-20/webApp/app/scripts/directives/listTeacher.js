'use strict';

/**
 * @ngdoc directive
 * @name pjqApp.directive:listTeacher
 * @description
 * # listTeacher
 */
angular.module('pjqApp')
  .directive('listTeacher', function () {
    return {
      templateUrl: 'views/directives/listTeacher.html',
      restrict: 'E',
    };
  });
