const QUnit = require("qunit");
const { sum } = require("../functions_to_test/functions.js");

QUnit.module("Testing 'sum' function");

QUnit.test("adds positive numbers correctly", (assert) => {
  assert.equal(sum(1, 9), 10, "The answer should be 10");
});

QUnit.test("adds negative and positive numbers correctly", (assert) => {
  assert.equal(sum(-8, 9), 1, "The answer should be 1");
});

QUnit.test("adds negative numbers correctly", (assert) => {
  assert.equal(sum(-5, -5), -10, "The answer should be -10");
});

QUnit.test("adds floating numbers correctly", (assert) => {
  assert.equal(sum(1.5, 2.5), 4.0, "The answer should be 4");
  const result = sum(0.1, 0.2);
  assert.ok(Math.abs(result - 0.3) < 0.001, "The answer should be 0.3");
  assert.equal(Math.floor(sum(0.5, 0.1) * 10), 6, "The answer should be 0.6");
});

QUnit.test("adds zero correctly", (assert) => {
  assert.equal(sum(0, 0), 0, "The answer should be 0");
  assert.equal(sum(5, 0), 5, "The answer should be 5");
  assert.equal(sum(0, -3), -3, "The answer should be -3");
});

QUnit.test("adds non-numeric values", (assert) => {
  assert.equal(sum("5", "10"), "510", "The answer should be 510");
  assert.equal(sum("5", 10), "510", "The answer should be 510");
});

QUnit.test("adds non-numeric values that cannot be converted", (assert) => {
  assert.ok(isNaN(sum("abc", "def")), "The answer should be NaN");
  assert.equal(sum("abc", "d"), "abcd", "The answer should be abcd");
  assert.ok(isNaN(sum("abc", 10)), "The answer should be NaN");
});
