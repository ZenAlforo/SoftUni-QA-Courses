const QUnit = require("qunit");
const { divide } = require("../functions_to_test/functions.js");
const { assert } = require("console");

QUnit.module("Testing 'divide' functionality", () => {
  QUnit.test("divide positive numbers correctly", (assert) => {
    assert.equal(divide(20, 2), 10, "Should return 10");
    assert.equal(divide(20, 8), 2.5, "Should return 2.5");
  });

  QUnit.test("divide with one negative numbers correctly", (assert) => {
    assert.equal(divide(-20, 2), -10, "Should return -10");
    assert.equal(divide(20, -8), -2.5, "Should return -2.5");
  });

  QUnit.test("divide with two negative numbers correctly", (assert) => {
    assert.equal(divide(-20, -2), 10, "Should return 10");
    assert.equal(divide(-20, -8), 2.5, "Should return 2.5");
  });

  QUnit.test("divide zero by a number", (assert) => {
    assert.equal(divide(0, 5), 0, "Should return 0");
    assert.equal(divide(0, -5), 0, "Should return 0");
  });

  QUnit.test("divide a number by one", (assert) => {
    assert.equal(divide(20, 1), 20, "Should return 20");
    assert.equal(divide(-20, 1), -20, "Should return -20");
  });

  QUnit.test("divide a number by itself", (assert) => {
    assert.equal(divide(20, 20), 1, "Should return 1");
    assert.equal(divide(-20, -20), 1, "Should return 1");
  });

  QUnit.test("divide with one floating numbers correctly", (assert) => {
    assert.equal(divide(10.5, 2), 5.25, "Should return 5.25");
    assert.equal(divide(10.5, 3), 3.5, "Should return 3.5");
  });

  QUnit.test("divide with two floating numbers correctly", (assert) => {
    let result = divide(10.5, 3.3);
    assert.ok(
      Math.abs(result - 3.1818181818181817) < 0.00000000000001,
      "Should return 3.1818181818181817",
    );
  });

  QUnit.test("divide number to zero", (assert) => {
    assert.throws(() => divide(2, 0), "should throw error");
  });

  QUnit.test("divide number to a string number", (assert) => {
    assert.equal(divide(2, "4"), 0.5, "should return 0.5");
  });

  QUnit.test("divide number to a non-numeric string", (assert) => {
    assert.ok(isNaN(divide(2, "string")), "should return NaN");
  });

  QUnit.test("divide non-numeric value to a number", (assert) => {
    assert.ok(isNaN(divide("string", 2)), "should return NaN");
  });

  QUnit.test("divide two non-numeric strings", (assert) => {
    assert.ok(isNaN(divide("string1", "string2")), "should return NaN");
  });
});
