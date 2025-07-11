function reverseArrayOfNumbers(elements, array) {
    let cutArray = array.slice(0, elements);

    cutArray.reverse();

    console.log(cutArray);
}


reverseArrayOfNumbers(3, [10, 20, 30, 40, 50])