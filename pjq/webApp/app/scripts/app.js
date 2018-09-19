'use strict';

/**
 * @ngdoc overview
 * @name pjqApp
 * @description
 * # pjqApp
 *
 * Main module of the application.
 */
angular
  .module('pjqApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'ui.router'
  ])
  .config(function($provide) {
    $provide.constant('routes', [
      //教师首页
      {
        name: 'main', //名称
        url: '/main',
        controller: 'MainCtrl', // 控制器名称
        templateUrl: 'views/main.html', //v层名称
        data:{title:'教师管理',show:true}
      },
      //创建一个教师增加路由
      {
        name: 'main.add', //继承main路由，并声明自己的名字为add
        url: '/add', //相当于 /main/add  由于继承了main路由
        controller: 'MainAddCtrl', // 控制器名称
        templateUrl: 'views/main/add.html',
        data:{title:'增加',show:false}
      },
      //创建一个教师查看路由
      {
        name: 'main.view',
        url: '/view/:id',
        controller: 'MainViewCtrl',
        templateUrl: 'views/main/view.html',
        data:{title:'查看',show:false}
      },
      //创建一个教师编辑路由
      {
        name: 'main.edit',
        url: '/edit/:id',
        controller: 'MainEditCtrl',
        templateUrl: 'views/main/edit.html',
        data:{title:'编辑',show:false}
      },
      //班级首页
      {
        name: 'klass', //名称
        url: '/klass',
        controller: 'KlassIndexCtrl', // 控制器名称
        templateUrl: 'views/klass/index.html', //v层名称
        data:{title:'班级管理',show:true}
      },
      //创建一个班级增加路由
      {
        name: 'klass.add',
        url: '/add',
        controller: 'KlassAddCtrl',
        templateUrl: 'views/klass/add.html',
        data:{title:'增加',show:false}
      },
      //创建一个班级编辑路由
      {
        name: 'klass.edit',
        url: '/edit/:id',
        controller: 'KlassEditCtrl',
        templateUrl: 'views/klass/edit.html',
        data:{title:'编辑',show:false} 
      }
    ]);
  })

  .config(function($stateProvider, $urlRouterProvider, $provide, $httpProvider,routes) {
    //循环注册路由
    angular.forEach(routes, function(value) {
      $stateProvider 
        .state(value);
    });

    $urlRouterProvider.otherwise('/main');

    //注册一个用于拦截http的拦截器
    $provide.factory('myHttpInterceptor', function() {
      return {
        //拦截请求信息
        'request': function(config) {
          //如果以html结尾，那么就不进行URL改写，否则就进行改写
          var suffix = config.url.split('.').pop();
          if (suffix !== 'html') {
            config.url = 'http://127.0.0.1:8080' + config.url;
          }

          return config;
        },
      };
    });

    $httpProvider.interceptors.push('myHttpInterceptor');
  });

