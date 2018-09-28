'use strict';

/**
 * @ngdoc service
 * @name webappApp.student
 * @description
 * # student
 * Service in the webappApp.
 */
angular.module('webappApp')
  .service('student', function ($http) {
    // AngularJS will instantiate a singleton by calling "new" on this function
    var baseUrl = '/student/';
    var self = this;
    self.add = function(data, callBack) {
    	$http.post(baseUrl, data)
    	.then(function() {
    		callBack();
    	}, function() {
    		console.log('fail to add student');
    	});
    };
    self.getAll = function(callBack) {
    	$http.get(baseUrl)
    	.then(function(response) {
    		callBack(response.data);
    	}, function() {
    		console.log('fail to get all student');
    	});
    };
    self.getById = function(id, callBack) {
    	$http.get(baseUrl + id)
    	.then(function(response) {
    		callBack(response.data);
    	}, function() {
    		console.log('fail to get student');
    	});
    };
    self.delete = function(id, callBack) {
    	$http.delete(baseUrl + id)
    	.then(function() {
    		callBack();
    	}, function() {
    		console.log('fail to delete student');
    	});
    };
    self.update = function(id, data, callBack) {
    	$http.put(baseUrl + id, data)
    	.then(function() {
    		callBack();
    	}, function() {
    		console.log('fail to update student');
    	});
    };
  });
