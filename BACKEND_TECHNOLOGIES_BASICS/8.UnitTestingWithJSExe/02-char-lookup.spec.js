import { lookupChar } from "./02-char-lookup.js";
import { assert, expect } from "chai";

describe("Testing the function lookupChar", () => {
	it("Should return undefined when non string is passed with valid index passed", () => {
		// Arrange

		// Act
		const objectArgPassed = lookupChar({ animal: "cat" });
		const numericInputPassed = lookupChar(2000, 2);
		const nullArgPassed = lookupChar(null, 2);
		const undefinedArgPassed = lookupChar(undefined, 1);
		const booleanArgPassed = lookupChar(false, 1);

		// Assert
		expect(
			objectArgPassed,
			"program did not work properly when object input is passed"
		).to.be.undefined;
		expect(
			numericInputPassed,
			"program did not work properly when numeric input is passed"
		).to.be.undefined;
		expect(
			nullArgPassed,
			"program did not work properly when null input is passed"
		).to.be.undefined;
		expect(
			undefinedArgPassed,
			"program did not work properly when undefined input is passed"
		).to.be.undefined;
		expect(
			booleanArgPassed,
			"program did not work properly when boolean input is passed"
		).to.be.undefined;
	});

	it("Should return Incorrect index when valid string and non number index is passed", () => {
		// Arrange

		// Act
		const stringIndexPassed = lookupChar("cat", "1");
		const floatingIndexPassed = lookupChar("cat", 4.5);

		// Assert
		expect(
			stringIndexPassed,
			"program did not work properly when string index is passed"
		).to.be.undefined;
        		expect(
			floatingIndexPassed,
			"program did not work properly when floating index is passed"
		).to.be.undefined;
	});

	it("Should return Incorrect index when EMPTY string and invalid index is passed", () => {
		// Arrange

		// Act
		const arrayArgPassed = lookupChar("", 0);

		// Assert
		expect(
			arrayArgPassed,
			"program did not work properly when empty string is passed"
		).to.equal("Incorrect index");
	});

	it("Should return Incorrect index when valid string and BIGGER index is passed", () => {
		// Arrange

		// Act
		const arrayArgPassed = lookupChar("cat", 3);

		// Assert
		expect(
			arrayArgPassed,
			"program did not work properly when BIGGER index is passed"
		).to.equal("Incorrect index");
	});

	it("Should return Incorrect index when valid string and NEGATIVE index is passed", () => {
		// Arrange

		// Act
		const arrayArgPassed = lookupChar("cat", -3);

		// Assert
		expect(
			arrayArgPassed,
			"program did not work properly when NEGATIVE index is passed"
		).to.equal("Incorrect index");
	});

	it("Should return Incorrect index when valid string and valid index are passed", () => {
		// Arrange
        const input = "doggy"
        const expected = "g";

		// Act
		const arrayArgPassed = lookupChar(input, 3);

		// Assert
		expect(
			arrayArgPassed,
			"program did not work properly when both arguments are valid"
		).to.equal(expected);
	});
});
