'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:StudentAddCtrl
 * @description
 * # StudentAddCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
    .controller('StudentAddCtrl', function($scope, $http,klass) {
        var self = this;
        self.init = function() {
            $scope.data = {
                name: '',
                Klass: {},
                email: '',
                sex: ''
            };
            // self.getAllKlass();
        };

        self.getAllKlass = function(){
            var url = '/Klass/';
            $http.get(url)
            .then(function success(response){
                $scope.data.klasses = response.data;
            }, function error(){
                console.log('error');
            });
        }

        self.submit = function() {
            var url = '/Student/';
            $http.post(url, $scope.data)
                .then(function success() {
                    console.log('增加成功');
                }, function error() {
                    console.log('error');
                });
        };
        self.init();
        $scope.submit = self.submit;
    });
