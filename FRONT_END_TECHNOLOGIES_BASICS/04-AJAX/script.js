// console.log("Hello.");
// setTimeout(function () {
//   console.log("Goodbye!");
// }, 0);
// console.log("Hello again!");

// function running() {
//   return "Running";
// }
// function category(run, type) {
//   console.log(run() + " " + type);
// }
// category(running, "sprint"); // Running sprint

// console.log("Before promise");
// new Promise(function (resolve, reject) {
//   setTimeout(function () {
//     resolve("done");
//   }, 500);
// }).then(function (res) {
//   console.log("Then returned: " + res);
// });
// console.log("After promise");

// fetch("https://api.github.com/users/testnakov/repos")
//   .then((response) => response.json())
//   .then((data) => console.log(data))
//   .catch((error) => console.error(error));

// fetch("/url", {
//   method: "post",
//   headers: { "Content-type": "application/json" },
//   body: JSON.stringify(data),
// });

// function resolveAfter2Seconds() {
//   return new Promise((resolve) => {
//     setTimeout(() => {
//       resolve("resolved");
//     }, 2000);
//   });
// }

// async function asyncCall() {
//   console.log("calling");
//   let result = await resolveAfter2Seconds();
//   console.log(result);
// }

// asyncCall();

const url = "https://api.github.com/users/testnakov/repos";

// function logFetch(url) {
//   return fetch(url)
//     .then((response) => {
//       return response.text();
//     })
//     .then((text) => {
//       console.log(text);
//     })
//     .catch((err) => {
//       console.error(err);
//     });
// }

// logFetch(url);

async function logFetch(url) {
  try {
    const response = await fetch(url);
    console.log(await response.text());
  } catch (err) {
    console.log(err);
  }
}
logFetch(url);
