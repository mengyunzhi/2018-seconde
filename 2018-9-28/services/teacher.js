'use strict';

/**
 * @ngdoc service
 * @name wabAppApp.teacher
 * @description
 * # teacher
 * Service in the wabAppApp.
 */
angular.module('wabAppApp')
  .service('teacher', function ($http) {
    // AngularJS will instantiate a singleton by calling "new" on this function
      var self = this;
      self.addTeacher = function (object) {
        var url = '/Teacher/add';
        console.log(object);
        $http.post(url, object)
            .then(function success() {
                console.log('success');
            }, function error() {
                console.log('error');
            });
      };
  });
