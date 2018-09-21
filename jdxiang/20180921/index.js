'use strict';

/**
 * @ngdoc function
 * @name webappApp.controller:KlassIndexCtrl
 * @description
 * # KlassIndexCtrl
 * Controller of the webappApp
 */
angular.module('webappApp')
  .controller('KlassIndexCtrl', function ($scope, $state, klass) {
    var self = this;
    self.init = function() {
    	$scope.klasses = {};
        $scope.data = {};
        $scope.data.number = 0;
        $scope.data.size = 5;
        self.reload();
    };
    self.reload = function() {
        klass.getByPage($scope.data.number,$scope.data.size,function(data) {
            $scope.data = data;
            $scope.klasses = $scope.data.content;
        });
    };
    self.add = function() {
    	$state.go('klass.add', {}, {reload: true});
    };
    self.delete = function(id) {
        klass.delete(id, function() {
            $state.go('klass', {}, {reload: true});
        });
    };
    self.reloadByNumber = function(number) {
        $scope.data.number = number;
        self.reload();
    };
    $scope.delete = self.delete;
    $scope.add = self.add;
    $scope.reloadByNumber = self.reloadByNumber;
    self.init();
  });
