'use strict';

/**
 * @ngdoc directive
 * @name pjqApp.directive:listSize
 * @description
 * # 每页大小
 */
angular.module('pjqApp')
  .directive('listSize', function () {
    return {
    	scope:{
    		ngModel:'=',
    		reload: '=',
        totalPages: '=',
    	},
      templateUrl: 'views/directives/listSize.html',
      restrict: 'E',
    };
  });
