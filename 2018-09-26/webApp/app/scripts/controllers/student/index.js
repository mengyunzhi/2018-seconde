'use strict';

/**
 * @ngdoc function
 * @name pjqApp.controller:StudentIndexCtrl
 * @description
 * # StudentIndexCtrl
 * Controller of the pjqApp
 */
angular.module('pjqApp')
    .controller('StudentIndexCtrl', function($scope, $http, studentservice) {
        var self = this;
        self.init = function() {
            var url = '/Student/';
            $http.get(url)
                .then(function success(response) {
                    $scope.student = response.data;
                }, function error() {
                    console.log('error');
                });
        }

        self.removeStudent = function(id) {
            $scope.student = $scope.student.filter(function(_student) {
                if (_student.id === id) {
                    return false;
                } else {
                    return true;
                }
            });
        }

        self.delete = function(object) {
            studentservice.delete(object, function() {
                self.removeStudent(object.id);
                console.log('删除成功');
            })

        }
        self.init();
        $scope.delete = self.delete;
    });
