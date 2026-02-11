// let myParagraph = document.getElementById("none");

// function fillParagraph() {
//   myParagraph.textContent = "This is my new paragraph content.";
// }

// myParagraph.id = "myParagraph";

// let myModifiedParagraph = document.getElementById("myParagraph");
// function fillParagraph() {
//   myModifiedParagraph.textContent =   "<script src='app.js'></script>";
// }

// let checkOldId = document.getElementById("none");
// console.log(checkOldId); // This will log null because the element with id "none" has been changed to "myParagraph"

let myBtn = document.querySelector("button");
myBtn.addEventListener("click", function () {
  let newList = document.createElement("ul");
  for (let i = 1; i <= 5; i++) {
    let listItem = document.createElement("li");
    listItem.textContent = "Item " + i;
    newList.appendChild(listItem);
  }
  document.body.appendChild(newList);
});

let insertBtn = document.querySelector("#insertBtn");
insertBtn.addEventListener("click", function () {
  let newItem = document.createElement("li");
  newItem.textContent = "New Item Set in the Middle";
  let existingList = document.querySelector("ul");
  let refChild = existingList.querySelector("li:nth-child(3)") // This will select the third item (index starts at 0)
  existingList.insertBefore(newItem, refChild);
  insertBtn.disabled = true; // Disable the button after inserting the item
});
