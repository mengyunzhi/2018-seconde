'use strict';

describe('Filter: sexFilter', function() {

    // load the filter's module
    beforeEach(module('pjqApp'));

    // initialize a new instance of the filter before each test
    var sexFilter;
    beforeEach(inject(function($filter) {
        sexFilter = $filter('sexFilter');
    }));

    it('为真时，返回男', function() {
        var text = 'true';
        expect(sexFilter(text)).toBe('男');
    });

    it('为假时，返回女', function() {
        var text = 'false';
        expect(sexFilter(text)).toBe('女');
    });

});
