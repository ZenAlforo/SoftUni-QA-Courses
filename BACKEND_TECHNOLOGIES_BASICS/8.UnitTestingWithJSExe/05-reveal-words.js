function revealWords(words, text) {
    let wordsArray = words.split(", ");
    let result;

    for (let word of wordsArray) {
        let phrases = text.split(" ");
        for (let phrase of phrases) {
            if (phrase.includes("*")) {
                if (word.length == phrase.length) {
                    result = text.replace("*".repeat(word.length), word);
                    text = result;
                }
            }
        }
    }
    console.log(result);
}

revealWords('great, learning', 'softuni is ***** place for ******** new programming languages')