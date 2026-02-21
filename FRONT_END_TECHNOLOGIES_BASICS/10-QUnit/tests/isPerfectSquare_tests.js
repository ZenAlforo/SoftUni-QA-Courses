const { isPerfectSquare } = require("../functions_to_test/functions.js");

QUnit.module("Testing isPerfectSquare function", () => {
  QUnit.test("testing with perfect square number", (assert) => {
    assert.ok(isPerfectSquare(16), "result should be true for 16");
  });

  QUnit.test("testing with non-perfect square number", (assert) => {
    assert.notOk(isPerfectSquare(20), "result should be false for 20");
  });

  QUnit.test("testing with zero", (assert) => {
    assert.ok(isPerfectSquare(0), "result should be true for 0");
  });

  QUnit.test("testing with negative number", (assert) => {
    assert.notOk(isPerfectSquare(-4), "result should be false for -4");
  });

  QUnit.test("testing with non-numeric input", (assert) => {
    assert.notOk(
      isPerfectSquare("string"),
      "should return false for non-numeric string input",
    );
    assert.notOk(
      isPerfectSquare("2"),
      "should return false for numeric string input",
    );
    assert.notOk(
      isPerfectSquare(undefined),
      "should return false for undefined input",
    );
    assert.ok(isPerfectSquare(null), "should return true for null input");
    assert.notOk(isPerfectSquare(NaN), "should return false for NaN input");
    assert.ok(isPerfectSquare([]), "should return true for empty array input");
    assert.ok(
      isPerfectSquare([4]),
      "should return true for array with numeric perfect square element input",
    );
    assert.notOk(
      isPerfectSquare([3]),
      "should return false for array with numeric non perfect square element input",
    );
    assert.notOk(isPerfectSquare({}), "should return false for object input");
    assert.ok(
      isPerfectSquare(true),
      "should return true for boolean true input",
    );
    assert.ok(
      isPerfectSquare(false),
      "should return true for boolean false input",
    );
  });
});
