const QUnit = require("qunit");
const { fibonacci } = require("../functions_to_test/functions.js");

QUnit.module("testing 'fibonacci' function");

QUnit.test("passing valid number should return fibonacci sequence", (assert) => {
  assert.deepEqual(fibonacci(10), [0, 1, 1, 2, 3, 5, 8, 13, 21, 34], "result should be [0, 1, 1, 2, 3, 5, 8, 13, 21, 34]");
  assert.deepEqual(fibonacci(0), [], "result should be []");
  assert.deepEqual(fibonacci(1), [0], "result should be [0]");
  assert.deepEqual(fibonacci(-3), [0, 1], "result should be [0, 1] as it is the default value for n less than 2");
})

QUnit.test("passing non-numeric value should return default fibonacci sequence", (assert) => {
  assert.deepEqual(fibonacci("string"), [0, 1], "result should be [0, 1] as it is the default value for non-numeric input");
  assert.deepEqual(fibonacci(undefined), [0, 1], "result should be [0, 1] as it is the default value for non-numeric input");
  assert.deepEqual(fibonacci(null), [0, 1], "result should be [0, 1] as it is the default value for non-numeric input");
  assert.deepEqual(fibonacci(NaN), [0, 1], "result should be [0, 1] as it is the default value for non-numeric input");
  assert.deepEqual(fibonacci([2]), [0, 1], "result should be [0, 1] as it is the default value for non-numeric input");
  assert.deepEqual(fibonacci(""), [0, 1], "result should be [0, 1] as it is the default value for non-numeric input");
  assert.deepEqual(fibonacci({}), [0, 1], "result should be [0, 1] as it is the default value for non-numeric input");
  assert.deepEqual(fibonacci(true), [0, 1], "result should be [0, 1] as it is the default value for non-numeric input");
  assert.deepEqual(fibonacci(false), [0, 1], "result should be [0, 1] as it is the default value for non-numeric input");
});

