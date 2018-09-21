'use strict';

/**
 * @ngdoc directive
 * @name webappApp.directive:page
 * @description
 * # page
 */
angular.module('webappApp')
	.directive('page', function() {
		return {
			templateUrl: 'views/directive/page.html',
			restrict: 'E',
			scope: {
				number: '=number',
				totalPages: '=',
				reloadPage: '=',
				first: '=',
				last: '='
			},
			link: function postLink(scope) {
				var self = this;
				self.showPage = 5;
				self.halfShowPage = parseInt(self.showPage / 2);
				self.creatPage = function() {
					var totalPages = scope.totalPages;
					var beginPage = 1;
					var endPage = totalPages;
					var showPage = self.showPage;
					var number = scope.number + 1;
					var halfShowPage = self.halfShowPage;
					var pages = [];
					if (number + halfShowPage > showPage) {
						if (number + halfShowPage > totalPages) {
							beginPage = totalPages - showPage + 1;
							endPage = totalPages;
						} else {
							beginPage = number - halfShowPage;
							endPage = number + halfShowPage;
						}
					} else {
						beginPage = 1;
						endPage = showPage;
					}
					if (showPage > totalPages) {
						beginPage = 1;
						endPage = totalPages;
					}
					for (var i = beginPage; i <= endPage; i++) {
						pages.push(i);
					}
					scope.pages = pages;
				};
				self.reloadByNumber = function(number) {
					if (number >= 0 && number < scope.totalPages) {
						scope.reloadPage(number);
					}
				};
				scope.$watch('number', function() {
					self.creatPage();
				});
				scope.$watch('totalPages', function() {
					self.creatPage();
				});
				scope.reloadByNumber = self.reloadByNumber;
			}
		};
	});