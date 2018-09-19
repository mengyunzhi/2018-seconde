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

        .state({
          name: 'about',
          url: '/about',
          templateUrl: 'views/about.html',
          controller: 'AboutCtrl'
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
        }); 
      $urlRouterProvider.otherwise('/main');
    });
