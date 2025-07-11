function getTotalOrderCost(product, quantity) {
	const COFFEE_PRICE = 1.5;
	const WATER_PRICE = 1.0;
	const COKE_PRICE = 1.4;
	const SNACKS_PRICE = 2.0;

	let totalCost;

	switch (product) {
		case "coffee":
			totalCost = COFFEE_PRICE * quantity;
			break;
		case "water":
			totalCost = WATER_PRICE * quantity;
			break;
		case "coke":
			totalCost = COKE_PRICE * quantity;
			break;
		case "snacks":
			totalCost = SNACKS_PRICE * quantity;
			break;
		default:
			break;
	}

    console.log(totalCost.toFixed(2));
}

getTotalOrderCost("water", 5)
