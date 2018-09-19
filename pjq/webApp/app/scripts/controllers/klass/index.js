'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:KlassIndexCtrl
 * @description
 * # KlassIndexCtrl
 * 班级管理   首页
 */
angular.module('pjqApp')
    .controller('KlassIndexCtrl', function($scope, $http, klass) {
        var self = this;
        var page = 0;

        self.init = function(page) {
            klass.page(page, 3, function(data) {
                $scope.data = data;
            });
            // var url = '/Klass/';

            //  $http.get(url)
            //      .then(function success(response) {
            //          $scope.klass = response.data;
            //      }, function error() {
            //          console.log('error');
            //      });
        };

        self.removeKlass = function(id) {
            $scope.data.content = $scope.data.content.filter(function(_klass) {
                if (_klass.id === id) {
                    return false;
                }
                return true;
            });
        };

        //删除
        self.delete = function(object) {
            klass.delete(object, function() {
                self.removeKlass(object.id);
            });
        };
        self.init(page);
        $scope.delete = self.delete;
        $scope.reload = self.init;

    });
