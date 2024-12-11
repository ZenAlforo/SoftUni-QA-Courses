function solve(text, word) {

    // let censorredText = text;
    // while(censorredText.includes(word)) {
    //     censorredText = censorredText.replace(word, "*".repeat(word.length))
        
    // }
    // console.log(censorredText)

    let censored = text.replace(word, repeat(word))
    while (censored.includes(word)) {
        censored = censored.replace(word, repeat(word))
    }

    console.log(censored)

    function repeat(word) {
        let count = word.length;
        let cover = "";
        for(let i = 0; i < count; i++) {
            cover += "*"
        }
    
        return cover;
    }
}




solve('A small sentence with some words', 'small')
