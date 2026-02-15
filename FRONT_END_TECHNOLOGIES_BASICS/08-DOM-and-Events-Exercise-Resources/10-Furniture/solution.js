function solve() {
  let generateBtn = document.querySelector("#exercise button");
  let buyBtn = document.querySelectorAll("#exercise button")[1];
  let textToEnter = document.querySelectorAll("#exercise textarea")[0];
  let checkoutArea = document.querySelectorAll("#exercise textarea")[1];

  let newItem = document.querySelector("tbody");
  generateBtn.addEventListener("click", generate);
  buyBtn.addEventListener("click", buy);

  function generate() {
    let items = JSON.parse(textToEnter.value);

    for (const item of items) {
      let row = document.createElement("tr");
      row.innerHTML = `<td><img src="${item.img}"></td>
      <td><p>${item.name}</p></td>
      <td><p>${item.price}</p></td>
      <td><p>${item.decFactor}</p></td>
      <td><input type="checkbox"/></td>`;
      newItem.appendChild(row);
    }
  }

  function buy() {
    let boughtItems = [];
    let totalPrice = 0;
    let totalDecFactor = 0;
    let checkboxes = document.querySelectorAll("tbody tr input");
    for (const checkbox of checkboxes) {
      if (checkbox.checked) {
        let row = checkbox.closest("tr");
        let name = row.querySelector("td:nth-child(2) p").textContent;
        let price = parseFloat(
          row.querySelector("td:nth-child(3) p").textContent,
        );
        let decFactor = parseFloat(
          row.querySelector("td:nth-child(4) p").textContent,
        );
        boughtItems.push(name);
        totalPrice += price;
        totalDecFactor += decFactor;
      }
    }
    checkoutArea.value = `Bought furniture: ${boughtItems.join(", ")}\nTotal price: ${totalPrice}\nAverage decoration factor: ${totalDecFactor / boughtItems.length}`;
  }
}
