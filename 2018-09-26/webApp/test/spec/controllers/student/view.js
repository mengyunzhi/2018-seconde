'use strict';

describe('Controller: StudentViewCtrl', function () {

  // load the controller's module
  beforeEach(module('pjqApp'));

  var StudentViewCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    StudentViewCtrl = $controller('StudentViewCtrl', {
      $scope: scope
      // place here mocked dependencies
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(StudentViewCtrl.awesomeThings.length).toBe(3);
  });
});
