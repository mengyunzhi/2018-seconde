'use strict';

/**
 * @ngdoc service
 * @name pjqApp.teacher
 * @description
 * # 教师
 * Service in the pjqApp.
 */
angular.module('pjqApp')
    .service('teacher', function($http) {

        var self = this;
        //获取教师的信息
        self.getAllTeacher = function(callback) {
            var url = '/Teacher/';
            $http.get(url)
                .then(function success(response) {
                    if (callback) {
                        callback(response.data);
                    }
                }, function error() {
                    console.log('error');
                });
        };

        return {
            getAllTeacher: self.getAllTeacher
        };
    });
