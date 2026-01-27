// // SOLVE WITH CALLBACKS

// function chainedPromises() {
//   console.log("Start");

//   setTimeout(() => {
//     console.log("1");
//     setTimeout(() => {
//       console.log("2");
//       setTimeout(() => {
//         console.log("3");
//       }, 1000);
//     }, 1000);
//   }, 1000);
// }

// // SOLVE WITH PROMISES

// function delay(value, ms) {
//   return new Promise((resolve) => setTimeout(() => resolve(value), ms));
// }

// function chainedPromises() {
//   console.log("Start");
//   delay("1", 1000).then((result) => {
//     console.log(result);
//     return delay("2", 1000)
//       .then((result) => {
//         console.log(result);
//         return delay("3", 1000);
//       })
//       .then((result) => {
//         console.log(result);
//       });
//   });
// }

// SOLVE WITH ASYNC / AWAIT

function delay(value, ms) {
  return new Promise((resolve) => setTimeout(() => resolve(value), ms));
}

async function chainedPromises() {
  console.log("Start");

  console.log(await delay("1", 1000));
  console.log(await delay("2", 1000));
  console.log(await delay("3", 1000));
}
