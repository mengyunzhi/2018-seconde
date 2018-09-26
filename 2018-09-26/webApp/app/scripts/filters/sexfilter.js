'use strict';

/**
 * @ngdoc filter
 * @name pjqApp.filter:sexFilter
 * @function
 * @description
 * # sexFilter
 * Filter in the pjqApp.
 */
angular.module('pjqApp')
    .filter('sexFilter', function() {
        return function(input) {
            var output = '';
            if (input) {
                output = '男';
            }
            else {
                output = '女';
            }
            return output;
        };
    });
