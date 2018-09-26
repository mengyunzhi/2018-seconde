   'use strict';

   /**
    * @ngdoc function
    * @name pjqApp.controller:KlassIndexCtrl
    * @description
    * # KlassIndexCtrl
    * 班级管理   首页
    */
   angular.module('pjqApp')
       .controller('KlassIndexCtrl', function($scope, $http,$state, klass) {
           var self = this;
           //初始化
           self.init = function() {
               $scope.params = { page: 0, size: 3 };
               self.load();

               // var url = '/Klass/';
               // $http.get(url)
               //     .then(function success(response) {
               //         $scope.klass = response.data;
               //     }, function error() {
               //         console.log('error');
               //     });
           };

           //加载数据
           self.load = self.reload = function() {
               klass.page($scope.params, function(data) {
                   $scope.data = data;
               });
           };

           //分页时重新加载数据
           self.reloadByPage = function(page) {
               $scope.params.page = page;          
               self.reload();
           };

           //选择每页大小时重新加载数据
           self.reloadBySize = function(size) {
               $scope.params.size = size;
               self.load();
           };

           //过滤删除方法
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
           self.init();
           $scope.delete = self.delete;
           $scope.reloadByPage = self.reloadByPage;
           $scope.reloadBySize = self.reloadBySize;

       });
