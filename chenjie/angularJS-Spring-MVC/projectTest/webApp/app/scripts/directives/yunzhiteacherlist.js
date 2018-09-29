'use strict';

/**
 * @ngdoc directive
 * @name testApp.directive:yunzhiTeacherList
 * @description
 * # yunzhiTeacherList
 */
angular.module('webApp')
  .directive('yunzhiTeacherList', function(teacher) {
    var self = {};
    /**
     * 获取所有教师
     * @Author   chen_jie
     * @DateTime 2018-09-26T11:31:10+0800
     * @return   {[type]}                 [description]
     */
    self.getAllTeachers = function($scope) {
      teacher.getAllTeachers(function(teachers) {
        $scope.teachers = teachers;
      });
    };
    return {
      templateUrl: 'views/directive/yunzhiTeacherList.html', //模板
      restrict: 'E', //渲染形式
      link: function postLink($scope) {
        self.getAllTeachers($scope);
      }
    };
  });
