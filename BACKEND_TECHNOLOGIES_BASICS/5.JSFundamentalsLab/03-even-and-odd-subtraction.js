function getResultsEvenSumMinusOddSum(myArray) {
    
    let evenSum = 0;
    let oddSum = 0

    myArray.filter((x) => {
        if (x % 2 == 0) {
            evenSum += x;
        } else {
            oddSum += x;
        }
    });

    console.log(evenSum - oddSum);
}

getResultsEvenSumMinusOddSum([3,5,7,9])