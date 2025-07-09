function checkIfAllDigitsAreSameAndSume(number) {
    const numberAsString = number.toString();
    let sum = 0;
    let areAllDigitsSame = true;

    for (let i = 0; i < numberAsString.length; i++) {
        let firstChar = numberAsString[0];
        let currentChar = numberAsString[i];
        sum += parseInt(currentChar, 10);

        if (currentChar !== firstChar) {
            areAllDigitsSame = false;
        }
    }

    console.log(areAllDigitsSame);
    console.log(sum);
}

checkIfAllDigitsAreSameAndSume(1234)
