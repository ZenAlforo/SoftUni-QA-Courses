function calculateOddAndEvenDigitsSum(number) {
    let numbers = number.toString().split("").map(Number);
    let evenSum = 0;
    let oddSum = 0;

    for (let num of numbers) {
        num % 2 == 0 ? evenSum += num : oddSum += num;
    }
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

calculateOddAndEvenDigitsSum(3495892137259234)
