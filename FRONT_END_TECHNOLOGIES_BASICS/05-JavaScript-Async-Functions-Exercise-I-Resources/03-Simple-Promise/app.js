// // Without promise

// function noPromise() {
//   setTimeout(() => {
//     console.log("Success!");
//   }, 2000);
// }

// document
//   .getElementsByTagName("button")[0]
//   .addEventListener("click", () => noPromise());

// With Promise

function solveWithPromise() {
  let promise = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Success!");
    }, 2000);
  });

  promise.then((result) => {
    console.log(result);
  });
}

document
  .getElementById("btn")
  .addEventListener("click", () => solveWithPromise());
