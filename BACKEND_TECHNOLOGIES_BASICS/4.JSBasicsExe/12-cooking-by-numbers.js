function getResult(
	number,
	firstOperation,
	secondOperation,
	thirdOperation,
	fourthOperation,
	fifthOperation
) {
	let currentResult = parseInt(number, 10);

	let operations = [
		firstOperation,
		secondOperation,
		thirdOperation,
		fourthOperation,
		fifthOperation,
	];

	for (const operation of operations) {
		switch (operation) {
			case "chop":
				currentResult /= 2;
				break;
			case "dice":
				currentResult = Math.sqrt(currentResult);
				break;
			case "spice":
				currentResult += 1;
				break;
			case "bake":
				currentResult *= 3;
				break;
			case "fillet":
				currentResult -= currentResult * 0.2;
				break;
		}

		console.log(currentResult);
	}
}


getResult(
	"9",
	"dice",
	"spice",
	"chop",
	"bake",
	"fillet"
);
