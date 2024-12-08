function solve(item, quantity) {
    const coffeePrice = 1.5;
    const waterPrice = 1;
    const cokePrice = 1.4;
    const snacksPrice = 2;

    let totalPrice = 0;

    switch (item) {
        case "coffee": totalPrice = coffeePrice * quantity; break;
        case "coke": totalPrice = cokePrice * quantity; break;
        case "water": totalPrice = waterPrice * quantity; break;
        case "snacks": totalPrice = snacksPrice * quantity; break;
        
    }

    console.log(totalPrice.toFixed(2))
}