'use strict';

describe('Service: Klass', function () {

  // load the service's module
  beforeEach(module('testApp'));

  // instantiate service
  var Klass;
  beforeEach(inject(function (_Klass_) {
    Klass = _Klass_;
  }));

  it('should do something', function () {
    expect(!!Klass).toBe(true);
  });

});
