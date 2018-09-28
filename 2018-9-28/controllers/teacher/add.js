'use strict';

/**
 * @ngdoc function
 * @name wabAppApp.controller:TeacherAddCtrl
 * @description
 * # TeacherAddCtrl
 * Controller of the wabAppApp
 */
angular.module('wabAppApp')
    .controller('TeacherAddCtrl', function ($http, $scope, teacher) {
        var self = this;
        
        //initial increase
        self.init = function () {
            $scope.data = {
                username: '',
                password: '',
                email: '',
                sex: ''
            };
        };
        //add the teacher
        self.addTeacher = function(object) {
          teacher.addTeacher(object);
        };
        
        
        
        $scope.addTeacher = self.addTeacher;
        self.init();
    });
