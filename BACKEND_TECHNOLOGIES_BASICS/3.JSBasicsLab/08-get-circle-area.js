function getCircleArea(input) {
    if (typeof input === "number") {
        let area = Math.PI * Math.pow(input, 2);
        console.log(area.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we received a ${typeof input}.`);
    }
}

getCircleArea(true)