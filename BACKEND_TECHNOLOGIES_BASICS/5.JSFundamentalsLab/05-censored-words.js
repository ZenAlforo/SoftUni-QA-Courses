function getCensoredText(text, wordToHide) {

    let censoredText = text;

    while(censoredText.includes(wordToHide)) {
        censoredText = censoredText.replace(wordToHide, "*".repeat(wordToHide.length))
    }

    console.log(censoredText);
}

getCensoredText('Find the hidden word', 'hidden')