import { expect } from 'chai';
import { add, subtract } from '../src/index.js';

describe('Add function', () => {
  it('should add two numbers when numbers are positive', () => {
    expect(add(2, 3)).to.equal(5);
  });
  
  it('should add two numbers when numbers are mixed sign', () => {
    expect(add(-2, 8)).to.equal(6);
  });
  
  it('should add two numbers when numbers are negative', () => {
    expect(add(-3, -5)).to.equal(-8);
  });
});

describe("Subtract functin tests", () => {
  it("should get correct answer when numbers are positive and result is positive", () => {
    expect(subtract(15, 4)).to.equal(11);
  });

  it("should get correct answer when numbers are positive and result is negative", () => {
    expect(subtract(99, 109)).to.equal(-10);
  });

  it("should get correct answer when numbers are mixed sign and result is negative", () => {
    expect(subtract(-1, -45)).to.equal(44);
  });

  it("should get correct answer when numbers are mixed sign and result is positive", () => {
    expect(subtract(11, 10)).to.equal(1);
  });
  
  it("should get correct answer when numbers are negative and result is negative", () => {
    expect(subtract(-8, -3)).to.equal(-5);
  });

});