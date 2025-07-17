function findOccurrences(word, text) {
    if (text.toLowerCase().includes(word.toLowerCase())) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}

findOccurrences('python', 'JavaScript is the best programming language')