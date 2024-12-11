function solve(input) {
    if (typeof(input) == "number") {
        let radius = input;
        let area = Math.PI * radius ** 2
        console.log(area.toFixed(2))
    } else {
        console.log(`We can not calculate the circle area, because we received a ${typeof(input)}.`)
    }
}
solve(5)