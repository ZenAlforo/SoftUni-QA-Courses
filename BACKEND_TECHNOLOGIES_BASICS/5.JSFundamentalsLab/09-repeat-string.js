function getRepeatedString(string, times) {
    let result = "";

    for (let i = 1; i <= times; i++) {
        result = result.concat(string)
    }

    return result;
}

console.log((getRepeatedString("abc", 3)));