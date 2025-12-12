// function chainedPromises() {
//   // with normal callbacks
//   setTimeout(() => {
//     console.log("2");
//   }, 2000);
//   setTimeout(() => {
//     console.log("3");
//   }, 3000);
//   console.log("Start");
//   setTimeout(() => {
//     console.log("1");
//   }, 1000);
// }

// // with nested callbacks
// function chainedPromises() {
//   setTimeout(() => {
//     console.log("1");
//     setTimeout(() => {
//       console.log("2");
//       setTimeout(() => {
//         console.log("3");
//       }, 1000);
//     }, 1000);
//   }, 1000);
//   console.log("Start");
// }

// with chained promises

// function wait(ms) {
//   let promise = new Promise((resolve, reject) => {
//     setTimeout(() => {
//       resolve();
//     }, ms);
//   });

//   return promise;
// }

// function chainedPromises() {
//   console.log("Start");
//   wait(1000)
//     .then(() => {
//       console.log("1");
//     })
//     .then(() => {
//       return wait(1000);
//     })
//     .then(() => {
//       console.log("2");
//     })
//     .then(() => {
//       return wait(1000);
//     })
//     .then(() => {
//       console.log("3");
//     });
// }

// with nested promises

function wait(ms) {
  let promise = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve();
    }, ms);
  });
  return promise;
}

function chainedPromises() {
  console.log("Start");
  wait(1000)
    .then(() => {
      console.log("1");
      return wait(1000);
    })
    .then(() => {
      console.log("2");
      return wait(1000);
    })
    .then(() => {
      console.log("3");
    });
}
let btn = document.querySelector("#btn");
btn.addEventListener("click", chainedPromises);
