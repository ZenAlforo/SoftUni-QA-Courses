function printInventoryList(inStock, ordered) {
	let inventory = {};

	for (let index = 0; index < inStock.length; index += 2) {
		if (index % 2 == 0) {
			let product = inStock[index];
			let quantity = parseInt(inStock[index + 1]);
			inventory[product] = quantity;
		}
	}

	for (let index = 0; index < ordered.length; index += 2) {
		if (index % 2 == 0) {
			let product = ordered[index];
			let quantity = parseInt(ordered[index + 1]);
			
            if(!inventory[product]) {
                inventory[product] = quantity;
            } else {
                inventory[product] += +quantity;
            }
		}
	}

	for (let product of Object.keys(inventory)) {
		console.log(`${product} -> ${inventory[product]}`);
	}
}

printInventoryList(
	["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
	[
		"Flour",
		"44",
		"Oil",
		"12",
		"Pasta",
		"7",
		"Tomatoes",
		"70",
		"Bananas",
		"30",
	]
);
