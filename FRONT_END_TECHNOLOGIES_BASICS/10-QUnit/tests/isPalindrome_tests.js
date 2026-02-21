const { assert } = require("node:console");
const { isPalindrome } = require("../functions_to_test/functions.js");

QUnit.module("Testing isPalindrome function", () => {
  QUnit.test("testing with palindrome", (assert) => {
    assert.ok(isPalindrome("racecar"), 'result should be "true"');
    assert.ok(
      isPalindrome("A man, a plan, a canal, Panama!"),
      'result should be "true"',
    );
  });

  QUnit.test("testing with invalid palindrome word", (assert) => {
    assert.notOk(isPalindrome("hello"), 'result should be "false"');
  });

  QUnit.test("testing with empty string", (assert) => {
    assert.notOk(isPalindrome(""), 'result should be "false"');
  });

  QUnit.test("testing with empty string", (assert) => {
    assert.notOk(isPalindrome(""), 'result should be "false"');
  });

  QUnit.test("testing with string of numbers which is palindrome", (assert) => {
    assert.ok(isPalindrome("121"), 'result should be "true"');
  });

  QUnit.test("testing with array or object", (assert) => {
    assert.throws(() => isPalindrome([]), "result should throw error");
    assert.throws(() => isPalindrome({}), "result should throw error");
    assert.throws(
      () => isPalindrome({ cac: "cac" }),
      "result should throw error",
    );
    assert.throws(() => isPalindrome([3, 3, 3]), "result should throw error");
    assert.throws(() => isPalindrome([3]), "result should throw error");
  });
});
0

