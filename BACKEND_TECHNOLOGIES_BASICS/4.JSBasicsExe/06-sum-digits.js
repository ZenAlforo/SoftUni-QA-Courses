

function  getSumOfDigits(number) {
    'use strict';

    const numbersAsString = number.toString();
    let sumOfDigits = 0;

    for (let char of numbersAsString) {
        sumOfDigits += parseInt(char, 10)
    }

    console.log(sumOfDigits);
}

getSumOfDigits(12345)