'use strict';

/**
 * @ngdoc directive
 * @name webappApp.directive:teacherlist
 * @description
 * # teacherlist
 */
angular.module('webappApp')
  .directive('teacherList', function () {
    return {
      templateUrl: 'views/directive/teacherlist.html',
      restrict: 'E',
      scope: {
      	teacheres: '=',
      	teacher: '='
      },
      link: function postLink(scope, element, attrs) {
        scope.empty = {};
      }
    };
  });
