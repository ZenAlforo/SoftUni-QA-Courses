const { assert } = require("node:console");
const { pascalsTriangle } = require("../functions_to_test/functions.js");

QUnit.module("Testing pascalsTriangle function", () => {
  QUnit.test("testing with 0 as parameter", (assert) => {
    assert.deepEqual(pascalsTriangle(0), [], "should return empty array");
  });

  QUnit.test("testing with 1 as parameter", (assert) => {
    assert.deepEqual(
      pascalsTriangle(1),
      [[1]],
      "should return jagged array [[1]]",
    );
  });

  QUnit.test("testing with 5 as parameter", (assert) => {
    assert.deepEqual(
      pascalsTriangle(5),
      [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]],
      "should return triangle as follows [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]]",
    );
  });

  QUnit.test("testing with 8 as parameter", (assert) => {
    assert.deepEqual(
      pascalsTriangle(8),
      [
        [1],
        [1, 1],
        [1, 2, 1],
        [1, 3, 3, 1],
        [1, 4, 6, 4, 1],
        [1, 5, 10, 10, 5, 1],
        [1, 6, 15, 20, 15, 6, 1],
        [1, 7, 21, 35, 35, 21, 7, 1],
      ],
      "should return triangle as follows [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1], [1, 5, 10, 10, 5, 1], [1, 6, 15, 20, 15, 6, 1], [1, 7, 21, 35, 35, 21, 7, 1]]",
    );
  });

  QUnit.test("testing with negative number as parameter", (assert) => {
    assert.deepEqual(
      pascalsTriangle(-3),
      [],
      "should return empty array for negative input",
    );
  });

  QUnit.test("testing with floating number as parameter", (assert) => {
    assert.deepEqual(
      pascalsTriangle(3.5),
      [[1], [1, 1], [1, 2, 1], [1, 3, 3, 1]],
      "should return triangle for floating point input",
    );
  });

  QUnit.test("testing with non-numeric parameter", (assert) => {
    assert.deepEqual(
      pascalsTriangle("string"),
      [],
      "should return empty array for non numeric string input",
    );
    assert.deepEqual(
      pascalsTriangle("2"),
      [[1], [1, 1]],
      "should return triangle for string that represents a number",
    );
    assert.deepEqual(
      pascalsTriangle(undefined),
      [],
      "should return empty array for undefined passed as input",
    );
    assert.deepEqual(
      pascalsTriangle(null),
      [],
      "should return empty array for null input",
    );
    assert.deepEqual(
      pascalsTriangle(NaN),
      [],
      "should return empty array for NaN input",
    );
    assert.deepEqual(
      pascalsTriangle([2]),
      [[1], [1, 1]],
      "should return triangle for array with 1 numeric element input",
    );
    assert.deepEqual(
      pascalsTriangle(""),
      [],
      "should return empty array for empty string input",
    );
    assert.deepEqual(
      pascalsTriangle({}),
      [],
      "should return empty array for empty object input",
    );
    assert.deepEqual(
      pascalsTriangle(true),
      [[1]],
      "should return [[1]] for boolean true input",
    );
    assert.deepEqual(
      pascalsTriangle(false),
      [],
      "should return empty array for boolean false input",
    );
  });
});
