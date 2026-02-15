function addItem() {
  let menu = document.getElementById("menu");
  let item = document.getElementById("newItemText").value;
  let price = document.getElementById("newItemValue").value;

  if (item === "" || price === "") {
    alert("Please enter both item name and price.");
    return;
  }

  let option = document.createElement("option");
  option.text = item;
  option.value = price;
  menu.appendChild(option);
  document.getElementById("newItemText").value = "";
  document.getElementById("newItemValue").value = "";
}
