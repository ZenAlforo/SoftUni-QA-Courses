function printTownsData(townsData) {
	let towns = [];

	function Town(name, latitude, longitude) {
		(this.name = name),
			(this.latitude = latitude),
			(this.longitude = longitude);
	}

	for (let town of townsData) {
		let [name, latitude, longitude] = town.split(" | ");
		latitude = parseFloat(latitude).toFixed(2);
		longitude = parseFloat(longitude).toFixed(2);

		let currentTown = new Town(name, latitude, longitude);
		towns.push(currentTown);
	}

	towns.forEach((x) => {
		console.log(x);
	});
}

printTownsData([
	"Sofia | 42.696552 | 23.32601",
	"Beijing | 39.913818 | 116.363625",
]);
