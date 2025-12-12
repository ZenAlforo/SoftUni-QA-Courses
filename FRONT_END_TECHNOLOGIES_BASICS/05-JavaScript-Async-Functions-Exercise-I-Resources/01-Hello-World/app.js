// // Solve with callback

// function helloWorld() {
//     setTimeout(() => {
//         console.log("World!");
//     }, 2000);
//     console.log("Hello");
// }

// let btn = document.getElementById("btn");
// btn.addEventListener("click", helloWorld);

// // Solve with Promise

// function helloWorldWithPromise() {
//     console.log("Hello");

//     return new Promise((resolve) => {
//         setTimeout(() => {
//             resolve("World!");
//         }, 2000);
//     }).then((result) => console.log(result));
// }

// let btn = document.getElementById("btn");
// btn.addEventListener("click", helloWorldWithPromise);

// Async/Await solution

function helloWorldAsync() {
  console.log("Hello");

  let promise = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("World!");
    }, 2000);
  });

  return promise;
}

let btn = document.getElementById("btn");
btn.addEventListener("click", async () => {
  console.log(await helloWorldAsync());
});
