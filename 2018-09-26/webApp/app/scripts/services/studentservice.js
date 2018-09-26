'use strict';

/**
 * @ngdoc service
 * @name pjqApp.studentservice
 * @description
 * # studentservice
 * Service in the pjqApp.
 */
angular.module('pjqApp')
    .service('studentservice', function($http) {
        var self = this;

        //删除
        self.delete = function(object, callback) {
            var url = '/Student/' + object.id;
            $http.delete(url)
                .then(function succsess(response) {
                    if (callback) { callback(response.data); }
                    console.log('删除成功');
                }, function error() {
                    console.log('删除失败');
                });
        };
        return{
        	delete: self.delete
        };
    });
