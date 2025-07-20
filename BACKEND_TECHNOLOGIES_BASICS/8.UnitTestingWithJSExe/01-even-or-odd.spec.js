import { isOddOrEven } from "./01-even-or-odd.js";
import { assert, expect } from "chai";

describe("Testing the function isOddOrEven", () => {
	it("Should return undefined if non string argument is passed", () => {
		// Arrange
		// Act
		let undefinedArgumentResult = isOddOrEven(undefined);
		let nullArgumentResult = isOddOrEven(null);
		let arrayArgumentResult = isOddOrEven(["Cat"]);
		let objectArgumentResult = isOddOrEven({ name: "cat" });
		let numberArgumentResult = isOddOrEven(10);
		let booleanArgumentResult = isOddOrEven(true);

		// Assert
		assert.equal(
			undefinedArgumentResult,
			undefined,
			"the program accepts undefined as possible correct input"
		);
		assert.equal(
			nullArgumentResult,
			undefined,
			"the program accepts null as possible correct input"
		);
		assert.equal(
			arrayArgumentResult,
			undefined,
			"the program accepts array as possible correct input"
		);
		assert.equal(
			objectArgumentResult,
			undefined,
			"the program accepts object as possible correct input"
		);
		assert.equal(
			numberArgumentResult,
			undefined,
			"the program accepts number as possible correct input"
		);
		assert.equal(
			booleanArgumentResult,
			undefined,
			"the program accepts boolean as possible correct input"
		);
	});

	it("Should return even if empty string is passed", () => {
		// Arrange
		let input = "";
		let expected = "even";

		// Act
		let result = isOddOrEven(input);

		// Assert
		expect(result).to.equal(
			expected,
			"there was problem operation with empty string"
		);
	});

	it("Should return even if even length string is passed", () => {
		// Arrange
		let input = "baby";
		let expected = "even";

		// Act
		let result = isOddOrEven(input);

		// Assert
		expect(result).to.equal(
			expected,
			"there was problem operation with even string"
		);
	});

	it("Should return odd if odd length string is passed", () => {
		// Arrange
		let input = "cat";
		let expected = "odd";

		// Act
		let result = isOddOrEven(input);

		// Assert
		expect(result).to.equal(
			expected,
			"there was problem operation with odd string"
		);
	});

	it("Should return correct value if different length strings are passed", () => {
		// Arrange
		let inputs = ["catfish", "bone", "flower", "to"];

		// Act & Assert
		for (let input of inputs) {
			let expected = input.length % 2 == 0 ? "even" : "odd";

			let result = isOddOrEven(input);
		
			expect(result).to.equal(expected, "the program does not work properly when many strings are passed in a row");
		}

	});
});
