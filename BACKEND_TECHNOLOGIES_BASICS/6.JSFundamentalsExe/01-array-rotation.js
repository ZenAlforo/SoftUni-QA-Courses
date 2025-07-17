function rotateArray(myArray, rotations) {
	let resultingArray = myArray.slice();

	for (let i = 1; i <= rotations; i++) {
		let elementToMove = resultingArray.shift();
        resultingArray.push(elementToMove)
	}

	console.log(resultingArray.join(" "));
}

rotateArray([2, 4, 15, 31], 5);
