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
    .config(function($stateProvider, $urlRouterProvider) {
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

        //配置delete路由
        .state({
          name: 'main.delete',
          url: '/delete/:id',
          controller: 'MainDeleteCtrl'
        })

        //配置klass/Add路由
        .state({
          name: 'klass.add',
          url: '/add',
          controller: 'KlassAddCtrl',
          templateUrl: 'views/klass/add.html'
        });
      $urlRouterProvider.otherwise('/main');
    });
