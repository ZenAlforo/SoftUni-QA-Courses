import { expect } from 'chai';
import { add, subtract } from '../src/index.js';

describe('Add function', () => {
  it('should add two numbers', () => {
    expect(add(2, 3)).to.equal(5);
  });
});

describe("Subtract functin tests", () => {
  it("should subtract two numbers", () => {
    expect(subtract(4, 4)).to.equal(0);
  });
});