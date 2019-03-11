'use strict';

/**
 * @ngdoc directive
 * @name webAppApp.directive:menu
 * @description
 * # menu
 */
angular.module('webAppApp')
  .directive('menu', function($state, routes) {
    return {
      templateUrl: 'views/directive/menu.html',
      restrict: 'E',
      link: function postLink($scope) {
        var self = this;

        self.init = function() {

        };

        self.isActive = function(state) {
          var currentState = $state.$current;
          console.log($state);
          if (currentState.parent) {
            while (currentState.parent.parent !== null) {
              currentState = currentState.parent;
            }
            if (currentState.name === state.name) {
              return true;
            } else {
              return false;
            }
          }

        };

        self.init();
        $scope.isActive = self.isActive;
        $scope.routes = routes;
      }
    };
  });
