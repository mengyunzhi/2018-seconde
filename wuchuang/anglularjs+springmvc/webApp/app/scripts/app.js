'use strict';

/**
 * @ngdoc overview
 * @name webAppApp
 * @description
 * # webAppApp
 *
 * Main module of the application.
 */
angular
  .module('webAppApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'ui.router'
  ])
  .config(function($provide) {
    $provide.constant('routes',
      [
    {
      name: 'main', // 名称
      url: '/main',
      controller: 'MainCtrl', // 控制器名称
      templateUrl: 'views/main.html',
      data: {
        title: '教师管理',
        show: true
      }
    },
    {
      name: 'main.add',
      url: '/add',
      templateUrl: 'views/main/add.html',
      controller: 'MainAddCtrl', // 控制器名称
      data: {
        title: '新增',
        show: false
      }
    },
    {
      name: 'main.view',
      url: '/view/:id',
      templateUrl: 'views/main/view.html',
      controller: 'MainViewCtrl',
      data: {
        title: '查看',
        show: false
      }
    },
    {
      name: 'main.edit',
      url: '/edit/:id',
      templateUrl: 'views/main/edit.html',
      controller: 'MainEditCtrl',
      data: {
        title: '编辑',
        show: false
      }
    },
    {
      name: 'klass', // 名称
      url: '/klass',
      controller: 'KlassIndexCtrl', // 控制器名称
      templateUrl: 'views/klass/index.html', // V层名称
      data: {
        title: '班级管理',
        show: true
      }
    },
    {
      name: 'klass.add',
      url: '/add',
      templateUrl: 'views/klass/add.html',
      controller: 'KlassAddCtrl', // 控制器名称
      data: {
        title: '新增',
        show: false
      }
    },
    {
      name: 'klass.edit',
      url: '/edit/:id',
      templateUrl: 'views/klass/edit.html',
      controller: 'KlassEditCtrl', // 控制器名称
      data: {
        title: '编辑',
        show: false
      }
    },
    {
      name: 'klass.view',
      url: '/view/:id',
      templateUrl: 'views/klass/view.html',
      controller: 'KlassViewCtrl',
      data: {
        title: '查看',
        show: false
      }
    }

      ]);
  })
.config(function($stateProvider, $urlRouterProvider, $provide, $httpProvider,routes) {
  // 循环注册路由
  angular.forEach(routes, function(value) {
      $stateProvider
    .state(value);
  });


  // 注册一个拦截器
  $provide.factory('myHttpInterceptor', function() {
    return {
      // optional method
      'request': function(config) {
        // 如果后缀为html则不改写
        var suffix = config.url.split('.').pop();
        if (suffix !== 'html') {
          config.url = 'http://127.0.0.1:8080' + config.url;
        }
        return config;
      }
    };
  });

  $httpProvider.interceptors.push('myHttpInterceptor');



  $urlRouterProvider.otherwise('/main');
});
