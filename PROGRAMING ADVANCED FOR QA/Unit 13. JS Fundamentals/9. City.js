function solve(object) {
    for(let [key, value] of Object.entries(object)) {
        console.log(`${key} -> ${value}`)
    }
}

solve({

    name: "Sofia",
    
    area: 492,
    
    population: 1238438,
    
    country: "Bulgaria",
    
    postCode: "1000"})