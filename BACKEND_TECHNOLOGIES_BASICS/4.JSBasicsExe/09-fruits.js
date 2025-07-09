function getFruitCosts(fruit, weightInGrams, pricePerKilo) {
    'use strict';

    let fruitCost = 0;

    fruitCost = weightInGrams / 1000 * pricePerKilo;

    console.log(`I need $${fruitCost.toFixed(2)} to buy ${(weightInGrams / 1000).toFixed(2)} kilograms ${fruit}.`);
}

getFruitCosts('orange', 2500, 1.80)