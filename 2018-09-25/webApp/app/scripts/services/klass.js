'use strict';

/**
 * @ngdoc service
 * @name pjqApp.klass
 * @description
 * # klass
 * 班级
 * Service in the pjqApp.
 */
angular.module('pjqApp')
    .service('klass', function($http) {

        var self = this;

         self.getAllKlass = function(callback) {
            var url = '/Klass/';
            $http.get(url)
                .then(function success(response) {
                    if (callback) {
                        callback(response.data);
                    }
                }, function error() {
                    console.log('error');
                });
        };

        //删除
        self.delete = function(object, callback) {
            var url = '/Klass/' + object.id;
            $http.delete(url)
                .then(function succsess(response) {
                    if (callback) { callback(response.data); }
                    // $state.reload();
                    console.log('删除成功');
                }, function error() {
                    console.log('删除失败');
                });
        };

        //分页
        self.page = function(params, callback) {
            var url = '/Klass/page';

            //使用参数发起get请求
            $http.get(url, { params: params })
                .then(function success(response) {
                    if (callback) {
                        callback(response.data);
                    }
                }, function error(response) {
                    console.log('error', response);
                });
        };

        return {
            getAllKlass: self.getAllKlass,
            delete: self.delete,
            page: self.page
        };
    });
