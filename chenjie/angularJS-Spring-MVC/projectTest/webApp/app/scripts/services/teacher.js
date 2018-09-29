'use strict';

/**
 * @ngdoc service
 * @name webApp.Teacher
 * @description
 * # Teacher
 * Service in the webApp.
 */
angular.module('webApp')
  .service('teacher', function($http) {
    var self = this;
    /**
     * @Author   chen_jie
     * @DateTime 2018-09-28T20:51:41+0800
     * @param    {getAllTeachers}               callback [description]
     * @return   {[type]}                          [description]
     */
    self.getAllTeachers = function(callback) {
      var url = '/Teacher/';
      $http.get(url)
        .then(function success(response) {
          if (callback) {
            callback(response.data);
          }
        }, function error() {
          console.log('请求教师列表错误');
        });
    };

    /**
     * 删除教师
     * @Author   chen_jie
     * @DateTime 2018-09-29T10:11:41+0800
     * @param    {[type]}                 object   [description]
     * @param    {Function}               callback [description]
     * @return   {[type]}                          [description]
     */
    self.delete = function(object, callback) {
      var url = '/Teacher/' + object.id;
      $http.delete(url)
        .then(function success(response) {
          if (callback) { callback(); }
          console.log('success', response);
        }, function error(response) {
          console.log('error', response);
        });
    };

    return {
      getAllTeachers: self.getAllTeachers,
      delete: self.delete
    };
  });
