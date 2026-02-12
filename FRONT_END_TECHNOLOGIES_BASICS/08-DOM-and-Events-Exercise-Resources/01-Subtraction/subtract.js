let button = document.getElementsByTagName("button");
button[0].addEventListener("click", subtract)

function subtract() {
  let firstNum = document.getElementById("firstNumber");
  let secondNum = document.getElementById("secondNumber");
  let result = document.querySelector("#result");

  let numA = Number(firstNum.value);
  let numB = Number(secondNum.value)

  result.textContent = numA - numB;

}
