'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:KlassViewCtrl
 * @description
 * # 班级查看
 * Controller of the pjqApp
 */
angular.module('pjqApp')
    .controller('KlassViewCtrl', function($http, $scope, $stateParams) {
        var self = this;
        self.init = function() {
            //接受ID
            var id = $stateParams.id;
            //用接收的ID去请求信息
            var url = '/Klass/' + id;

            $http.get(url)
                .then(function success(response) {
                    //将请求信息给V层
                    $scope.data = response.data;
                }, function error(response) {
                    console.log(url + 'error');
                });
        };

        //调用init方法 初始化
        self.init();
    });
