const QUnit = require("qunit");
const { factorial } = require("../functions_to_test/functions.js");

QUnit.module("Testing 'factorial' function");

QUnit.test("getting factorial of valid number", (assert) => {
  assert.equal(factorial(8), 40320, "should result to 40320");
  assert.equal(factorial(7), 5040, "should result to 5040");
});

QUnit.test("getting factorial of zero", (assert) => {
  assert.equal(factorial(0), 1, "should result to 1");
});

QUnit.test("getting factorial of one", (assert) => {
  assert.equal(factorial(1), 1, "should result to 1");
});

QUnit.test("getting error when using non valid numbers", (assert) => {
  assert.throws(() => factorial(-10), "should throw error");
});
