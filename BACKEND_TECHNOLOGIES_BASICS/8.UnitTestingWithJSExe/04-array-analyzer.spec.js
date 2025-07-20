import { analyzeArray } from "./04-array-analyzer.js";
import { assert, expect } from "chai";

describe("Testing the function analyzeArray", () => {
	it("Should return UNDEFINED when passing nonArray argument", () => {
		// Arrange

		// Act
		const floatingNumPassed = analyzeArray(5.55);
		const negativeIntPassed = analyzeArray(-10);
		const positiveIntPassed = analyzeArray(5);
		const zeroArgPassed = analyzeArray(0);
		const stringArgPassed = analyzeArray("string");
		const booleanArgPassed = analyzeArray(false);
		const floatingNumSecondPassed = analyzeArray(5);

		// Assert
		assert.isUndefined(floatingNumPassed);
		assert.isUndefined(negativeIntPassed);
		assert.isUndefined(positiveIntPassed);
		assert.isUndefined(zeroArgPassed);
		assert.isUndefined(stringArgPassed);
		assert.isUndefined(booleanArgPassed);
		assert.isUndefined(floatingNumSecondPassed);
	});

	it("Should return UNDEFINED when passing empty array argument", () => {
		// Arrange

		// Act
		const emptyArrayResult = analyzeArray([]);

		// Assert
		assert.isUndefined(emptyArrayResult);
	});

	it("Should return UNDEFINED when passing array with elements that are not numbers", () => {
		// Arrange

		// Act
		const arrayWithEmptyElements = analyzeArray([5, 3, , 4, 9]);
		const arrayWithStringElements = analyzeArray([5, 3, "14", 4, 9]);
		const arrayWithBooleanElements = analyzeArray([5, 3, true, 4, 9]);
		const arrayWithNullElements = analyzeArray([5, 3, null, 4, 9]);
		const arrayWithUndefinedElements = analyzeArray([
			5,
			3,
			undefined,
			4,
			9,
		]);
		const arrayWithArrayElements = analyzeArray([5, 3, [20], 4, 9]);
		const arrayWithEmptyStringElements = analyzeArray([5, 3, "", 4, 9]);
		const arrayWithObjectElements = analyzeArray([
			5,
			3,
			{ number: 10 },
			4,
			9,
		]);

		// Assert
		assert.isUndefined(
			arrayWithEmptyElements,
			"Not working properly when array with some EMPTY element passed"
		);
		assert.isUndefined(
			arrayWithStringElements,
			"Not working properly when array with array with some STRING element passed"
		);
		assert.isUndefined(
			arrayWithBooleanElements,
			"Not working properly when array with array with some BOOLEAN element passed"
		);
		assert.isUndefined(
			arrayWithUndefinedElements,
			"Not working properly when array with array with some UNDEFINED element passed"
		);
		assert.isUndefined(
			arrayWithNullElements,
			"Not working properly when array with array with some NULL element passed"
		);
		assert.isUndefined(
			arrayWithArrayElements,
			"Not working properly when array with array with some ARRAY element passed"
		);
		assert.isUndefined(
			arrayWithEmptyStringElements,
			"Not working properly when array with array with some EMPTY STRING element passed"
		);
		assert.isUndefined(
			arrayWithObjectElements,
			"Not working properly when array with array with some OBJECT element passed"
		);
	});

	it("Should return correctAnswer when passing array with elements that are NaN", () => {
		// Arrange
		const input = [5, 3, NaN, 4, 9, NaN];
		const expected = { min: 3, max: 9, length: 6 };

		// Act
		const arrayWithNaNElements = analyzeArray(input);
        console.log(arrayWithNaNElements);

		// Assert

		assert.deepEqual(
			arrayWithNaNElements,
			expected,
			"Not working properly when array with some NaN element passed"
		);
	});

	it("Should return correct Answer when passing array with all positive integer elements", () => {
		// Arrange
		const input = [5, 3, 20, 4, 9, 15, 17];
		const expected = { min: 3, max: 20, length: 7 };

		// Act
		const result = analyzeArray(input);
        console.log(result);

		// Assert

		assert.deepEqual(
			result,
			expected,
			"Not working properly when array with with positive integer elements passed"
		);
	});

	it("Should return correct Answer when passing array with some floating elements", () => {
		// Arrange
		const input = [5, 3.8, 20.5, 15.59, 15.6];
		const expected = { min: 3.8, max: 20.5, length: 5 };

		// Act
		const result = analyzeArray(input);
        console.log(result);

		// Assert

		assert.deepEqual(
			result,
			expected,
			"Not working properly when array with SOME FLOATING elements passed"
		);
	});

	it("Should return correct Answer when passing array with some NEGATIVE elements", () => {
		// Arrange
		const input = [5, 3.8, -20.5, 15.59, 15.6];
		const expected = { min: -20.5, max: 15.6, length: 5 };

		// Act
		const result = analyzeArray(input);
        console.log(result);

		// Assert

		assert.deepEqual(
			result,
			expected,
			"Not working properly when array with NEGATIVE elements passed"
		);
	});

	it("Should return correct Answer when passing array with one element", () => {
		// Arrange
		const input = [15.6];
		const expected = { min: 15.6, max: 15.6, length: 1 };

		// Act
		const result = analyzeArray(input);
        console.log(result);

		// Assert
		assert.deepEqual(
			result,
			expected,
			"Not working properly when array with one element passed"
		);
	});
});
