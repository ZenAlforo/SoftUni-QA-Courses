function getLargestNumber(a, b, c) {
    let biggesNumber;

    if (a > b && b > c) {
        biggesNumber = a;
    } else if (b > c && b > a) {
        biggesNumber = b;
    } else if (c > b && c > a) {
        biggesNumber = c;
    }

    console.log(`The largest number is ${biggesNumber}`);
}

getLargestNumber(-5, -3, -1)