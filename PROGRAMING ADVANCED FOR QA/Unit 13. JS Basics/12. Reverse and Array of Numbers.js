function solve(member, myArray) {
    let reversedArray = [];

    reversedArray = myArray.slice(0, member).reverse();
    
    console.log(reversedArray.join(" "))
}

solve(2, [66, 43, 75, 89, 47])