'use strict';

/**
 * @ngdoc directive
 * @name pjqApp.directive:listindex
 * @description
 * # listindex
 */
angular.module('pjqApp')
  .directive('listIndex', function($state, routes) {
    return {
      templateUrl: 'views/directives/listIndex.html',
      restrict: 'E',

      link: function postLink($scope) {
        var self = this;
        self.init = function() {

        };

        //导航栏点击选中
        self.isActive = function(state) {
          //获取当前路由哦
          var currentState = $state.$current;
          //存在parent属性
          if (currentState.parent) {
            //一直找到跟路由
            while (currentState.parent.parent !== null) {
              currentState = currentState.parent;

            }
            //判断根路由
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