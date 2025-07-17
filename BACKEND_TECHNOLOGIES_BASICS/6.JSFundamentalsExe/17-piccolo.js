function printParkedCars(data) {
	let parking = new Set();

	for (let carCommand of data) {
		let [command, plate] = carCommand.trim().split(", ");
		if (command === "IN") {
			parking.add(plate);
		} else if (command === "OUT") {
			parking.delete(plate);
		}
	}

    if (parking.size > 0) {
        let parkingArray = Array
            .from(parking)
            .sort()
            .forEach((car) => console.log(car));
    } else {
        console.log("Parking Lot is Empty");
    }
}

printParkedCars(['IN, CA2844AA',

'IN, CA1234TA',

'OUT, CA2844AA',

'OUT, CA1234TA']);
