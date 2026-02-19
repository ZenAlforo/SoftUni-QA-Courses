const { isEven } = require("../functions_to_test/functions.js");

const QUnit = require("qunit");

QUnit.module("testing 'isEven' function", () => {
  QUnit.test("passing positive even number should return true", (assert) => {
    assert.equal(isEven(4), true, "result should be true");
  });

  QUnit.test("passing positive odd number should return false", (assert) => {
    assert.notOk(isEven(5), "result should be false");
  });

  QUnit.test("passing negative even number should return true", (assert) => {
    assert.equal(isEven(-6), true, "result should be true");
  });

  QUnit.test("passing negative odd number should return false", (assert) => {
    assert.notOk(isEven(-7), "result should be false");
  });

  QUnit.test("passing zero should return true", (assert) => {
    assert.equal(isEven(0), true, "result should be true");
  });

  QUnit.test("passing non-integer number should return false", (assert) => {
    assert.notOk(isEven(2.6), "result should be false");
    assert.notOk(isEven(-3.5), "result should be false");
  });

  QUnit.test("passing string value should return false", (assert) => {
    assert.notOk(isEven("string"), "result should be false for string");
  });

  QUnit.test("passing undefined should return false", (assert) => {
    assert.notOk(isEven(undefined), "result should be false for undefined");
  });

  QUnit.test("passing null should return true", (assert) => {
    assert.ok(isEven(null), "result should be true for null");
  });
});
