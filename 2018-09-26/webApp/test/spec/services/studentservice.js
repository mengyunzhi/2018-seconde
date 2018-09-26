'use strict';

describe('Service: studentservice', function () {

  // load the service's module
  beforeEach(module('pjqApp'));

  // instantiate service
  var studentservice;
  beforeEach(inject(function (_studentservice_) {
    studentservice = _studentservice_;
  }));

  it('should do something', function () {
    expect(!!studentservice).toBe(true);
  });

});
