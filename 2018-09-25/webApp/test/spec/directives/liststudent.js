'use strict';

describe('Directive: listStudent', function () {

  // load the directive's module
  beforeEach(module('pjqApp'));

  var element,
    scope;

  beforeEach(inject(function ($rootScope) {
    scope = $rootScope.$new();
  }));

  it('should make hidden element visible', inject(function ($compile) {
    element = angular.element('<list-student></list-student>');
    element = $compile(element)(scope);
    expect(element.text()).toBe('this is the listStudent directive');
  }));
});
