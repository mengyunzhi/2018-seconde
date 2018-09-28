'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:CourseAddCtrl
 * @description
 * # CourseAddCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
    .controller('CourseAddCtrl', function($scope,$http) {
        var self = this;
        self.init = function() {
            $scope.data = {
                name: '',
                student: {}
            };
        };

        self.submit = function() {
            var url = '/Course/';
            $http.post(url,$scope.data)
                .then(function success() {
                    console.log('增加成功');
                }, function error() {
                    console.log('error');
                });
            
        };
        self.init();
        $scope.submit = self.submit;
    });
