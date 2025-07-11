function sumFirstAndLastArrayElements(array) {
    let sum = 0;

    sum += array[0];
    sum += array[array.length - 1];
    console.log(sum);
}

sumFirstAndLastArrayElements([1, 2, 3, 4, 5])


