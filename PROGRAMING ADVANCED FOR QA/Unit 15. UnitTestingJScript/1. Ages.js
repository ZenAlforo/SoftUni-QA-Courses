function solve(ages) {
    let result = "";

    let age = Number(ages[0])

    if (age >= 0 && age <=2) {
        result = "baby"
    } else if(age >= 3 && age <=13) {
        result = "child"
    }else if(age >= 14 && age <=19) {
        result = "teenager"
    }else if(age >= 20 && age <=65) {
        result = "adult"
    } else if (age >= 66) {
        result = "elder"
    } else {
        result = "out of bounds"
    }

    return result
}

solve("1")