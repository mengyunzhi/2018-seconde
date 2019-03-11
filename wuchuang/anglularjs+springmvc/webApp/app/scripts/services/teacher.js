'use strict';

/**
 * @ngdoc service
 * @name webAppApp.teacher
 * @description
 * # teacher
 * Service in the webAppApp.
 */
angular.module('webAppApp')
  .service('teacher', function ($http) {
    // AngularJS will instantiate a singleton by calling "new" on this function
    var self = this;

    self.getAllTeachers = function(callback) {
        var url = '/Teacher/';
        $http.get(url)
        .then(function success(response) {
            if (callback) {
                callback(response.data);
            }
            
        }, function error() {
            console.log('请求错误');
        });
    };

    return {
        getAllTeachers: self.getAllTeachers
    };
  });
