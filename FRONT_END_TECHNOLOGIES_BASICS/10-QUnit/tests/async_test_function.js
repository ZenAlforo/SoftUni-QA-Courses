const { fetchData } = require("../functions_to_test/async_function");

QUnit.module("Testing fetchData functions", () => {
  QUnit.test("testing with valid url", async (assert) => {
    const data = await fetchData("https://api.zippopotam.us/bg/8000");
    assert.ok(
      data.hasOwnProperty("country"),
      "Data should have country property",
    );
    assert.equal(data.country, "Bulgaria", "Country should be Bulgaria");
    assert.ok(
      data.hasOwnProperty("country abbreviation"),
      "Data should have country abbreviation property",
    );
    assert.equal(
      data["country abbreviation"],
      "BG",
      "Country abbreviation should be BG",
    );
    assert.ok(
      data.hasOwnProperty("post code"),
      "Data should have post code property",
    );
    assert.equal(data["post code"], "8000", "Post code should be 8000");
    assert.ok(
      data.hasOwnProperty("places"),
      "Data should have places property",
    );
    assert.ok(Array.isArray(data.places), "Places should be an array");
    assert.ok(data.places.length > 0, "Places array should not be empty");
    assert.ok(
      data.places[0].hasOwnProperty("place name"),
      "Place should have place name property",
    );
    assert.ok(
      data.places[0]["place name"].includes("Burgas"),
      "Place name should be Burgas",
    );
    assert.equal(
      data.places[0]["state abbreviation"],
      "BGS",
      "State abbreviation should be BGS",
    );
  });

  QUnit.test("Testing with invalid postcode", async (assert) => {
    const data = await fetchData("https://api.zippopotam.us/bg/800099999");
    assert.notOk(data);
    assert.true(data === undefined);
  });

  QUnit.test("Testing with invalid url", async (assert) => {
    const data = await fetchData("https://api.zippopiotam.us/bg/");
    assert.equal(data, 'fetch failed');
  });
});
