function getObjectPairs(city) {
	for (let pair of Object.entries(city)) {
		let key = pair[0];
		let value = pair[1];
		console.log(`${key} -> ${value}`);
	}
}

getObjectPairs({
	name: "Sofia",
	area: 492,
	population: 1238438,
	country: "Bulgaria",
	postCode: "1000",
});
