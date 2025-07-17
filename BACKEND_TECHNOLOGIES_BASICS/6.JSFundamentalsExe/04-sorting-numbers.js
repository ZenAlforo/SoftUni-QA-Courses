function reorderArray(array) {
    let result = [];
    let currentArray = array.slice().sort((a, b) => a - b);

    while (currentArray.length > 0) {
       
        result.push(currentArray.shift());
        if (currentArray.length > 0) {
            result.push(currentArray.pop());
        }
    }

    return result;
}

console.log(reorderArray([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));