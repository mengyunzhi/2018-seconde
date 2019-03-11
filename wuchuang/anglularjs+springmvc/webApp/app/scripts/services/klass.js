'use strict';

/**
 * @ngdoc service
 * @name webAppApp.klass
 * @description
 * # klass
 * Service in the webAppApp.
 */
angular.module('webAppApp')
  .service('klass', function ($http) {
    // AngularJS will instantiate a singleton by calling "new" on this function
    var self = this;
    self.delete = function(object, callback) {
        var url = '/Klass/' + object.id;
        $http.delete(url)
        .then(function success() {
            if (callback) {callback();}
        }, function error(response) {
            console.log('error', response);
        });
         
    };

    return {
        delete: self.delete
    };
  });
