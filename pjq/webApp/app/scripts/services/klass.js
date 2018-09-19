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
        self.page = function(page, size, callback) {
            var url = '/Klass/page';

            //定义参数
            var params = { page: page, size: size };
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
            delete: self.delete,
            page: self.page
        };
    });
