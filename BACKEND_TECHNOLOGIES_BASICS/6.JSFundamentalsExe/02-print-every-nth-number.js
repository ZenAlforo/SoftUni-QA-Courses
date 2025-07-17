function printEveryNthNumber(myArray, step) {
	let result = [];

	for (let i = 0; i < myArray.length; i += step) {
		result.push(myArray[i]);
	}

	return result;
}

console.log(printEveryNthNumber(
	['dsa', 'asd', 'test', 'tset'], 2
));
