  'use strict';

  /**
   * @ngdoc overview
   * @name webApp
   * @description
   * # webApp
   *
   * Main module of the application.
   */
  angular
    .module('webApp', [
      'ngAnimate',
      'ngCookies',
      'ngResource',
      'ngRoute',
      'ngSanitize',
      'ngTouch',
      'ui.router'
    ])
    .config(function($stateProvider, $urlRouterProvider, $provide, $httpProvider) {
      $stateProvider
        .state({
          name: 'main',
          url: '/main',
          controller: 'MainCtrl',
          templateUrl: 'views/main.html'
        })

        //配置klass路由
        .state({
          name: 'klass',
          url: '/klass',
          templateUrl: 'views/klass/index.html',
          controller: 'KlassIndexCtrl'
        })

        //配置Add路由
        .state({
          name: 'main.add',
          url: '/add',
          controller: 'MainAddCtrl',
          templateUrl: 'views/main/add.html'
        })

        //配置view路由
        .state({
          name: 'main.view',
          url: '/view/:id',
          controller: 'MainViewCtrl',
          templateUrl: 'views/main/view.html'
        })

        //配置edit路由
        .state({
          name: 'main.edit',
          url: '/edit/:id',
          controller: 'MainEditCtrl',
          templateUrl: 'views/main/edit.html'
        })

        //配置klass/Add路由
        .state({
          name: 'klass.add',
          url: '/add',
          controller: 'KlassAddCtrl',
          templateUrl: 'views/klass/add.html'
        })

        //配置klass/edit路由
        .state({
          name: 'klass.edit',
          url: '/edit/:id',
          controller: 'KlassEditCtrl',
          templateUrl: 'views/klass/edit.html'
        })

        //配置view路由
        .state({
          name: 'klass.view',
          url: '/view/:id',
          controller: 'KlassViewCtrl',
          templateUrl: 'views/klass/view.html'
        });
      $urlRouterProvider.otherwise('/main');

      // 注册一个拦截http的拦截器
      $provide.factory('myHttpInterceptor', function($q) {
        return {
          // 拦截请求信息
          'request': function(config) {
            //如果后缀不为html，则进行URL改写
            var suffix = config.url.split('.').pop();
            if (suffix !== 'html') {
              config.url = 'http://127.0.0.1:8080' + config.url;
            }
            return config;
          }
        };
      });
      $httpProvider.interceptors.push('myHttpInterceptor');
    });
