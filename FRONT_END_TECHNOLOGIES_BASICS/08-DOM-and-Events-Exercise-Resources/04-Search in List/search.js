function search() {
  const searchText = document
    .getElementById("searchText")
    .value.toLocaleLowerCase();
  const listItems = document.querySelectorAll("li");
  let resultCount = 0;

  listItems.forEach((li) => {
    if (li.textContent.toLocaleLowerCase().includes(searchText)) {
      li.style.textDecoration = "underline";
      li.style.fontWeight = "bold";
      resultCount++;
    } else {
      li.style.textDecoration = "";
      li.style.fontWeight = "";
    }
  });

  const matches = document.getElementById("result");
  if (resultCount === 1) {
    matches.textContent = `${resultCount} match found`;
  } else {
    matches.textContent = `${resultCount} matches found`;
  }
}
