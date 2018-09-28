'use strict';

/**
 * @ngdoc directive
 * @name pjqApp.directive:listCourse
 * @description
 * # listCourse
 */
angular.module('pjqApp')
    .directive('listCourse', function(studentservice) {
        var self = {};
        //获取学生
        self.getAllStudent = function($scope) {
            studentservice.getAllStudent(function(students) {
                $scope.students = students;
            });
        };
        return {
            templateUrl: 'views/directives/listCourse.html',
            restrict: 'E',
            link: function postLink(scope) {
            	self.getAllStudent(scope);

            }
        };
    });
