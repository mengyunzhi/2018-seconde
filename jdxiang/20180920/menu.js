'use strict';

/**
 * @ngdoc directive
 * @name webappApp.directive:menu
 * @description
 * # menu
 */
angular.module('webappApp')
  .directive('menu', function(routes, $state) {
    return {
      templateUrl: 'views/directive/menu.html',
      scope: {},
      restrict: 'E',
      link: function postLink(scope) {
        var self = this;
        self.init = function() {
          scope.routes = routes;
        }();
        self.isActive = function(name) {
          var currentState = $state.$current;
          if (currentState.parent !== null) {
            while (currentState.parent.parent !== null) {
              currentState = currentState.parent;
            };
          }
          if (currentState.name === name) {
          	return true;
          }
        };
        scope.isActive = self.isActive;
      }
    };
  });
