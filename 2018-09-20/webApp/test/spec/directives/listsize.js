'use strict';

describe('Directive: listSize', function () {

  // load the directive's module
  beforeEach(module('pjqApp'));

  var element,
    scope;

  beforeEach(inject(function ($rootScope) {
    scope = $rootScope.$new();
  }));

  it('should make hidden element visible', inject(function ($compile) {
    element = angular.element('<list-size></list-size>');
    element = $compile(element)(scope);
    expect(element.text()).toBe('this is the listSize directive');
  }));
});
