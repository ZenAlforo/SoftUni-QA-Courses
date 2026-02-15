function encodeAndDecodeMessages() {
  let textToEncode = document.querySelector("#main div:nth-child(1) textarea");
  let textToDecode = document.querySelector("#main div:nth-child(2) textarea");
  let encodeBtn = document.querySelector("#main div:nth-child(1) button");
  let decodeBtn = document.querySelector("#main div:nth-child(2) button");

  encodeBtn.addEventListener("click", encodeMessage);
  decodeBtn.addEventListener("click", decodeMessage);

  function encodeMessage() {
    let initialMessage = textToEncode.value;
    let encodedText = "";

    for (let ch of initialMessage) {
      let asciiValue = ch.charCodeAt(0) + 1;
      let encodedChar = String.fromCharCode(asciiValue);
      encodedText += encodedChar;
    }

    textToDecode.value = encodedText;
    textToEncode.value = "";
  }

  function decodeMessage() {
    let codedMessage = textToDecode.value;
    let decodedText = "";

    for (let ch of codedMessage) {
      let asciiValue = ch.charCodeAt(0) - 1;
      let decodedChar = String.fromCharCode(asciiValue);
      decodedText += decodedChar;
    }

    textToDecode.value = decodedText;
  }
}
