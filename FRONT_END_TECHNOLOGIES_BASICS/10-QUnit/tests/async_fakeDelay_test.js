const { fakeDelay } = require("../functions_to_test/async_function");

QUnit.module("testing fakeDelay function", () => {
  QUnit.test("testing with valid delay", async (assert) => {
    const start = Date.now();
    await fakeDelay(1000);
    const end = Date.now();
    const difference = end - start;
    assert.ok(difference >= 1000, "Delay is at least 1000ms");
  });
});
