'use strict';

describe('Controller: MainEditCtrl', function () {

  // load the controller's module
  beforeEach(module('pjqApp'));

  var MainEditCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    MainEditCtrl = $controller('MainEditCtrl', {
      $scope: scope
      // place here mocked dependencies
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(MainEditCtrl.awesomeThings.length).toBe(3);
  });
});
