// // 1. SOLVE WITH CALBACKS

// let outputBox = document.getElementById("output");
// let button = document.getElementById("helloWorld");

// function helloWorld() {
//   outputBox.textContent = "Hello, ";
//   setTimeout(() => {
//     printToOutput(printWorld());
//   }, 2000);
// }

// function printWorld() {
//   return "World!";
// }

// function printToOutput(text) {
//   let divContent = outputBox.textContent;
//   outputBox.textContent = divContent + text;
// }

// button.addEventListener("click", helloWorld);

// // 2. SOLVE WITH PROMISES

// let button = document.querySelector("#helloWorld");
// let outputBox = document.getElementsByTagName("p")[0];

// function helloWorld() {
//   outputBox.textContent = "Hello, ";

//   new Promise((resolve, reject) => {
//     setTimeout(() => {
//       resolve("World!");
//     }, 2000);
//   }).then((result) => {
//     outputBox.textContent += result;
//   }).catch((error) => {
//     console.error("Error:", error);
//   });
// }

// button.addEventListener("click", helloWorld);

// 3. SOLVE WITH ASYNC / AWAIT

let button = document.querySelector("#helloWorld");
let outputBox = document.getElementsByTagName("p")[0];

async function helloWorld() {
  try {
    outputBox.textContent = "Hello, ";

    const result = await new Promise((resolve) => {
      setTimeout(() => {
        resolve("World!");
      }, 2000);
    });

    outputBox.textContent += result;
  } catch (error) {
    console.error("Error:", error);
  }
}

button.addEventListener("click", helloWorld);
