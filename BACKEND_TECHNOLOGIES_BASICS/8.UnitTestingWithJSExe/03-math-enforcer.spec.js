import { mathEnforcer } from "./03-math-enforcer.js";
import { assert, expect } from "chai";

describe("Testing the function mathEnforcer", () => {
	let calculator = mathEnforcer;

	describe("Testing the addFive function", () => {
		it("Should return UNDEFINED when non number argument is passed", () => {
			// Arrange
			// Act
			const arrayArgResult = calculator.addFive([3]);
			const undefinedArgResult = calculator.addFive(undefined);
			const booleanArgResult = calculator.addFive(true);
			const stringArgResult = calculator.addFive("five");
			const stringNumberArgResult = calculator.addFive("4");
			const emptyStringArgResult = calculator.addFive("");
			const nullArgResult = calculator.addFive(null);
			const objectArgResult = calculator.addFive({ number: 3 });

			// Assert
			expect(arrayArgResult, "not working properly when array is passed")
				.to.be.undefined;
			expect(
				undefinedArgResult,
				"not working properly when undefined is passed"
			).to.be.undefined;
			expect(
				booleanArgResult,
				"not working properly when boolean is passed"
			).to.be.undefined;
			expect(
				stringArgResult,
				"not working properly when string is passed"
			).to.be.undefined;
			expect(
				stringNumberArgResult,
				"not working properly when stringified number is passed"
			).to.be.undefined;
			expect(
				emptyStringArgResult,
				"not working properly when empty string is passed"
			).to.be.undefined;
			expect(nullArgResult, "not working properly when null is passed").to
				.be.undefined;
			expect(
				objectArgResult,
				"not working properly when object is passed"
			).to.be.undefined;
		});

		it("Should return result when valid number is passed", () => {
			// Arrange

			// Act
			const floatingNumPassed = calculator.addFive(4.66666);
			const negativeIntPassed = calculator.addFive(-23);
			const positiveIntPassed = calculator.addFive(122121);
			const zeroIntPassed = calculator.addFive(0);
			// Assert

			assert.closeTo(
				floatingNumPassed,
				9.66,
				0.01,
				"Not working properly when floating point number is passed"
			);
			assert.equal(
				negativeIntPassed,
				-18,
				"Not working properly when negative integer number is passed"
			);
			assert.equal(
				positiveIntPassed,
				122126,
				"Not working properly when positive integer number is passed"
			);
			assert.equal(
				zeroIntPassed,
				5,
				"Not working properly when zero integer number is passed"
			);
		});

		it("Should return NaN when NaN is passed", () => {
			// Arrange

			// Act
			const resultWhenNaNpassed = calculator.addFive(NaN);

			// Assert
			assert.isNaN(
				resultWhenNaNpassed,
				"Not working properly when NaN passed"
			);
		});
	});

	describe("Testing the subtractTen function", () => {
		it("Should return UNDEFINED when non number argument is passed", () => {
			// Arrange
			// Act
			const arrayArgResult = calculator.subtractTen([3]);
			const undefinedArgResult = calculator.subtractTen(undefined);
			const booleanArgResult = calculator.subtractTen(true);
			const stringArgResult = calculator.subtractTen("five");
			const stringNumberArgResult = calculator.subtractTen("4");
			const emptyStringArgResult = calculator.subtractTen("");
			const nullArgResult = calculator.subtractTen(null);
			const objectArgResult = calculator.subtractTen({ number: 3 });

			// Assert
			expect(arrayArgResult, "not working properly when array is passed")
				.to.be.undefined;
			expect(
				undefinedArgResult,
				"not working properly when undefined is passed"
			).to.be.undefined;
			expect(
				booleanArgResult,
				"not working properly when boolean is passed"
			).to.be.undefined;
			expect(
				stringArgResult,
				"not working properly when string is passed"
			).to.be.undefined;
			expect(
				stringNumberArgResult,
				"not working properly when stringified number is passed"
			).to.be.undefined;
			expect(
				emptyStringArgResult,
				"not working properly when empty string is passed"
			).to.be.undefined;
			expect(nullArgResult, "not working properly when null is passed").to
				.be.undefined;
			expect(
				objectArgResult,
				"not working properly when object is passed"
			).to.be.undefined;
		});

		it("Should return result when valid number is passed", () => {
			// Arrange

			// Act
			const floatingNumPassed = calculator.subtractTen(4.66666);
			const negativeIntPassed = calculator.subtractTen(-23);
			const positiveIntPassed = calculator.subtractTen(122121);
			const zeroIntPassed = calculator.subtractTen(0);
			// Assert

			assert.closeTo(
				floatingNumPassed,
				-5.34,
				0.01,
				"Not working properly when floating point number is passed"
			);
			assert.equal(
				negativeIntPassed,
				-33,
				"Not working properly when negative integer number is passed"
			);
			assert.equal(
				positiveIntPassed,
				122111,
				"Not working properly when positive integer number is passed"
			);
			assert.equal(
				zeroIntPassed,
				-10,
				"Not working properly when zero integer number is passed"
			);
		});

				it("Should return NaN when NaN is passed", () => {
			// Arrange

			// Act
			const resultWhenNaNpassed = calculator.subtractTen(NaN);

			// Assert
			assert.isNaN(
				resultWhenNaNpassed,
				"Not working properly when NaN passed"
			);
		});
	});

	describe("Testing the sum function", () => {
		it("Should return UNDEFINED when first non number argument is passed", () => {
			// Arrange
			// Act
			const arrayArgResult = calculator.sum([3], 2);
			const undefinedArgResult = calculator.sum(undefined, 2);
			const booleanArgResult = calculator.sum(true, 2);
			const stringArgResult = calculator.sum("five", 3);
			const stringNumberArgResult = calculator.sum("4", 3);
			const emptyStringArgResult = calculator.sum("", 3);
			const nullArgResult = calculator.sum(null, 3);
			const objectArgResult = calculator.sum({ number: 3 }, 2);

			// Assert
			expect(arrayArgResult, "not working properly when array is passed")
				.to.be.undefined;
			expect(
				undefinedArgResult,
				"not working properly when undefined is passed"
			).to.be.undefined;
			expect(
				booleanArgResult,
				"not working properly when boolean is passed"
			).to.be.undefined;
			expect(
				stringArgResult,
				"not working properly when string is passed"
			).to.be.undefined;
			expect(
				stringNumberArgResult,
				"not working properly when stringified number is passed"
			).to.be.undefined;
			expect(
				emptyStringArgResult,
				"not working properly when empty string is passed"
			).to.be.undefined;
			expect(nullArgResult, "not working properly when null is passed").to
				.be.undefined;
			expect(
				objectArgResult,
				"not working properly when object is passed"
			).to.be.undefined;
		});

		it("Should return UNDEFINED when second non number argument is passed", () => {
			// Arrange
			// Act
			const arrayArgResult = calculator.sum(2, [3]);
			const undefinedArgResult = calculator.sum(2, undefined);
			const booleanArgResult = calculator.sum(2, true);
			const stringArgResult = calculator.sum(2, "five");
			const stringNumberArgResult = calculator.sum(3, "10");
			const emptyStringArgResult = calculator.sum(3, "");
			const nullArgResult = calculator.sum(3, null);
			const objectArgResult = calculator.sum(2, { number: 3 });

			// Assert
			expect(arrayArgResult, "not working properly when array is passed")
				.to.be.undefined;
			expect(
				undefinedArgResult,
				"not working properly when undefined is passed"
			).to.be.undefined;
			expect(
				booleanArgResult,
				"not working properly when boolean is passed"
			).to.be.undefined;
			expect(
				stringArgResult,
				"not working properly when string is passed"
			).to.be.undefined;
			expect(
				stringNumberArgResult,
				"not working properly when stringified number is passed"
			).to.be.undefined;
			expect(
				emptyStringArgResult,
				"not working properly when empty string is passed"
			).to.be.undefined;
			expect(nullArgResult, "not working properly when null is passed").to
				.be.undefined;
			expect(
				objectArgResult,
				"not working properly when object is passed"
			).to.be.undefined;
		});

		it("Should return result when valid arguments are passed", () => {
			// Arrange

			// Act
			const floatingNumPassed = calculator.sum(4.66666, 4);
			const negativeIntPassed = calculator.sum(-23, 4);
			const positiveIntPassed = calculator.sum(4, 122121);
			const zeroFirstArgPassed = calculator.sum(0, 4);
			const zeroSecondArgPassed = calculator.sum(4, 0);
			const bothArgsZeroPassed = calculator.sum(0, 0);
			const floatingNumSecondPassed = calculator.sum(4, -4.66666);

			// Assert

			assert.closeTo(
				floatingNumPassed,
				8.66,
				0.01,
				"Not working properly when floating point first parameter is passed"
			);
			assert.equal(
				negativeIntPassed,
				-19,
				"Not working properly when negative integer number is passed"
			);
			assert.equal(
				positiveIntPassed,
				122125,
				"Not working properly when positive integer number is passed"
			);
			assert.equal(
				zeroFirstArgPassed,
				4,
				"Not working properly when zero integer number is passed"
			);
			assert.equal(
				zeroSecondArgPassed,
				4,
				"Not working properly when zero integer number is passed"
			);
			assert.equal(
				bothArgsZeroPassed,
				0,
				"Not working properly when zero integer number is passed"
			);

			assert.closeTo(
				floatingNumSecondPassed,
				-0.66,
				0.01,
				"Not working properly when floating point number is passed"
			);
		});

		it("Should return NaN when some of the arguments passed are NaN", () => {
			// Arrange

			// Act
			const resultWhenOneParameterIsNaN = calculator.sum(10, NaN);

			// Assert

			assert.isNaN(
				resultWhenOneParameterIsNaN,
				"Not working properly when NaN parameter is passed"
			);
		});
	});
});
