function create(words) {
  const divToFill = document.getElementById("content");

  words.forEach((word) => {
    let currentParagraph = document.createElement("p");
    currentParagraph.textContent = word;
    currentParagraph.style.display = "none";

    let currentDiv = document.createElement("div");
    currentDiv.appendChild(currentParagraph);

    currentDiv.addEventListener("click", () => {
      currentParagraph.style.display = "grid";
    });

    divToFill.appendChild(currentDiv);
  });
}
