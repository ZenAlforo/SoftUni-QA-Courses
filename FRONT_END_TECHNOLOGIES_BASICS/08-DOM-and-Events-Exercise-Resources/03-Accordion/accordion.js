function toggle() {
  let btn = document.getElementsByClassName("button")[0];
  let textToShowOrHide = document.getElementById("extra");

  if (btn.textContent === "More") {
    textToShowOrHide.style.display = "block";
    btn.textContent = "Less";
  } else {
    textToShowOrHide.style.display = "none";
    btn.textContent = "More";
  }
}
