const { nthPrime } = require("../functions_to_test/functions.js");

QUnit.module("Testing nthPrime function", () => {
  QUnit.test("testing 1th prime", (assert) => {
    assert.equal(nthPrime(1), 2, "should return 2 when 1 is passed");
  });
  QUnit.test("testing 5th prime", (assert) => {
    assert.equal(nthPrime(5), 11, "should return 11 when 5 is passed");
  });
  QUnit.test("testing 11th prime", (assert) => {
    assert.equal(nthPrime(11), 31, "should return 31 when 11 is passed");
  });
});
