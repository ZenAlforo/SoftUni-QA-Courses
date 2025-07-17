function findOddOccurrences(data) {
    let words = data.toLowerCase().split(" ");


    let occurrences = []

    for (let word of words) {
        let count = words.filter(w => w === word).length;
        if (count % 2 !== 0 && !occurrences.includes(word)) {
            occurrences.push(word)
        }
    }
    
    console.log(occurrences.join(" "));
}


findOddOccurrences('Cake IS SWEET is Soft CAKE sweet Food')