function countStringOccurences(text, str) {
    let stringCount = 0;

    let textToCheck = text.split(" ");

    for (const element of textToCheck) {
        if (element === str) {
            stringCount++;
        }
    }

    console.log(stringCount);
}

countStringOccurences('This is a word and it also is a sentence',

'is')