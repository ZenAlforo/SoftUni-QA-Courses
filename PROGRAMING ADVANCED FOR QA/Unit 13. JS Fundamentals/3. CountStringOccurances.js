function solve(text, word) {

    let count = 0;

    let wordsArray = text.split(" ");

    for(let w of wordsArray) {
        if (w == word) {
            count++;
        }
    }

    console.log(count)
    
}

solve('This is a word and it also is a sentence', 'is')