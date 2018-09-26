'use strict';

/**
 * @ngdoc directive
 * @name pjqApp.directive:listStudent
 * @description
 * # listStudent
 */
angular.module('pjqApp')
    .directive('listStudent', function(klass) {
        var self = {};
        //获取所有班级
        self.getAllKlass = function($scope) {
            klass.getAllKlass(function(klasses) {
                $scope.klasses = klasses;
            });
        };
        
        return {
            templateUrl: 'views/directives/listStudent.html',
            restrict: 'E',
            link: function postLink(scope) {
                self.getAllKlass(scope);
            }
        };
    });
