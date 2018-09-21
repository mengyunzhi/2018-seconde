'use strict';

/**
 * @ngdoc directive
 * @name pjqApp.directive:listPage
 * @description
 * # listPage
 */
angular.module('pjqApp')
    .directive('listPage', function() {
        return {
            scope: {
                size:'=',
                reload: '=',
                number: '=',
                totalPages: '=',     
            },

            templateUrl: 'views/directives/listPage.html',
            restrict: 'E',
            link: function postLink(scope) {
                var self = this;
                //当前显示的页数
                self.maxPageCount = 5;

                self.init = function() {
                    //监听number
                    scope.$watch('number', self.watchNumber);
                    scope.$watch('size', self.watchSize);
                };

                //当前显示的页数一半取余
                self.getHalfMaxPageCount = function() {
                    return Math.floor(self.maxPageCount / 2);

                };

                //生成分页信息
                self.generatePage = function(page, maxPageCount, totalPages) {
                    var pages = [];
                    var beginPage = 1;      
                    var endPage = self.maxPageCount;
                    var halfMaxPageCount = self.getHalfMaxPageCount();

                    //判断是否不是前几页
                    if (page + halfMaxPageCount > self.maxPageCount) {
                        if (page + halfMaxPageCount > totalPages) {
                            //是后几页
                            beginPage = totalPages - halfMaxPageCount * 2;
                            endPage = totalPages;
                        } else {
                            //中间几页
                            beginPage = page - halfMaxPageCount;
                            endPage = page + halfMaxPageCount;
                        }
                    }

                    //判断总页码是否超出了范围
                    endPage = endPage > totalPages ? totalPages : endPage;
                    beginPage = beginPage > 0 ? beginPage : 1;

                    for (var i = beginPage; i <= endPage; i++) {
                        pages.push(i);
                    }
                    return pages;
                };


                self.reloadPage = function() {
                  scope.pages = self.generatePage(scope.number + 1, scope.maxPageCount, scope.totalPages);
                };


                //监听当前页是否发生变化
                self.watchNumber = function(newValue) {
                    if (typeof(newValue) !== 'undefined') {
                        self.reloadPage();
                    }
                };

                //监听Size
                self.watchSize = function(newValue) {
                    if (typeof(newValue) !== 'undefined') {
                        self.reloadPage();
                    }
                };

                //点击更换页码
                self.changePage = function(page) {
                    scope.reload(page - 1);
                };

                //点击页码时点亮
                self.isActive = function(page) {
                    if (page - 1 === scope.number) {
                        return true;
                    } else {
                        return false;
                    }
                };
                self.init();
                scope.changePage = self.changePage;
                scope.isActive = self.isActive;
            }
        };
    });
