function getResult(firstNum, secondNum, operator) {
    let result = 0;

	switch (operator) {
		case "+": result = firstNum + secondNum;
			break;
		case "-": result = firstNum - secondNum;
			break;
		case "*": result = firstNum * secondNum;
			break;
		case "/": result = firstNum / secondNum;
			break;
		case "%": result = firstNum % secondNum;
			break;
		case "**": result = firstNum ** secondNum;
			break;

		default: result = "Error!"
			break;
	}

    console.log(result);
}

getResult(50, 34, "/");