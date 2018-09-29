'use strict';

/**
 * @ngdoc service
 * @name webApp.Klass
 * @description
 * # Klass
 * Service in the webApp.
 */
angular.module('webApp')
  .service('klass', function($http) {
    var self = this;

    /**
     * 删除班级
     * @Author   chen_jie
     * @DateTime 2018-09-29T08:34:06+0800
     * @param    {[type]}                 object   [description]
     * @param    {delete}               callback [description]
     * @return   {[type]}                          [description]
     */
    self.delete = function(object, callback) {
    	var url = '/Klass/' + object.id;
    	$http.delete(url)
    	.then(function success(response) {
    		if (callback) { callback(); }
    		console.log('success', response);
    	}, function error(response) {
    		console.log('error', response);
    	});
    };
    return {
      delete: self.delete
    };
  });
