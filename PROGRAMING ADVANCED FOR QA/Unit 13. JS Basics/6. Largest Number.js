function solve(a, b, c) {
    let result;

    if (a > b && a > c) {
        result = a;
    } else if (b > c && b > a) {
        result = b;
    } else if (c > a && c > b) {
        result = c;
    } 

    console.log(`The largest number is ${result}.`)
}