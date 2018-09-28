'use strict';

/**
 * @ngdoc overview
 * @name wabAppApp
 * @description
 * # wabAppApp
 *
 * Main module of the application.
 */
angular
    .module('wabAppApp', [
        'ngAnimate',
        'ngAria',
        'ngCookies',
        'ngMessages',
        'ngResource',
        'ngRoute',
        'ngSanitize',
        'ngTouch',
        'ui.router'
    ])
    .config(function ($provide) {
        $provide.constant('routers',
            [
                {
                    name: 'main',
                    url: '/main',
                    templateUrl: 'views/teacher/index.html',
                    controller: 'MainCtrl',
                    data: {}
                },
                {
                    name: 'main.add',
                    url:'/add',
                    templateUrl: 'views/teacher/add.html',
                    controller: 'TeacherAddCtrl',
                    data: {}
                }
                
            ]);
    })
    .config(function ($stateProvider, $urlRouterProvider, $provide, $httpProvider, routers) {
        //循环注册路由
        angular.forEach(routers, function (value) {
            $stateProvider
                .state(value);
        });
        
        $urlRouterProvider.otherwise('/main');
        
        //注册一个用于拦截的拦截器
        
        $provide.factory('myHttpInterceptor', function () {
            return {
                //拦截请求信息
                'request': function (config) {
                    //如果需要改写就改写
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

  
