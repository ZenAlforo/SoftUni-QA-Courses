// // 1. SOLVE WITH AJAX (XMLHTTPREQUEST)

// let button = document.getElementById("load");
// let httpRequest;
// button.addEventListener("click", loadRepos);

// function loadRepos() {
//   let url = "https://api.github.com/users/testnakov/repos";
//   httpRequest = new XMLHttpRequest();
//   httpRequest.addEventListener("readystatechange", showRepos);
//   httpRequest.open("GET", url);
//   httpRequest.send();
// }

// function showRepos() {
//   if (httpRequest.readyState == 4 && httpRequest.status == 200) {
//     document.getElementById("res").textContent = httpRequest.responseText;
//   }
// }

// // 2. USING SETTIMEOUT TO SIMULATE ASYNCHRONOUS OPERATION

// function synchronousFunction() {
//   console.log("hello");
//   setTimeout(function () {
//     console.log("goodbye");
//   }, 2000);
//   console.log("hi again");
// }

// synchronousFunction();

// // 3. PROMISE WITH SIMULATED ASYNC OPERATION

// let promise = new Promise(function (resolve, reject) {
//   setTimeout(() => {
//     let success = true; // change to false to test rejection
//     if (success) {
//       resolve("The operation was completed!");
//     } else {
//       reject("The operation failed.");
//     }
//   }, 1000);
// });

// promise
//   .then(function (message) {
//     console.log("Success: " + message);
//   })
//   .catch(function (message) {
//     console.log("Error: " + message);
//   })
//   .finally(() => {
//     console.log("The promise has been settled.");
//   });

// // 4. USING PROMISE.METHODS DIRECTLY (WITHOUT NEW PROMISE)

// function validateInput (input) {
//   if (input !== "expectedValue") {
//     return Promise.reject("Invalid input provided.");
//   } else {
//     return Promise.resolve("Input is valid.");
//   }
// }

// validateInput("expectedValue")
// .then(function (message) {
//   console.log(message);
// })
// .catch(function (message) {
//   console.log(message);
// });

// // 5.USING PROMISE.ALL VS PROMISE.ALLSETTLED
// // ALL PROMISES MUST BE RESOLVED, OTHERWISE THE CATCH BLOCK IS TRIGGERED

// function firstFetch() {
//   return new Promise((resolve, reject) => {
//     setTimeout(() => {
//       reject("First fetch failed.");
//     }, 5000);
//   });
// }

// function secondFetch() {
//   return new Promise((resolve) => {
//     setTimeout(() => {
//       resolve("Second fetch completed.");
//     }, 5000);
//   });
// }

// function thirdFetch() {
//   return new Promise((resolve) => {
//     setTimeout(() => {
//       resolve("Third fetch completed.");
//     }, 4000);
//   });
// }

// Promise.all([firstFetch(), secondFetch(), thirdFetch()])
//   .then((messages) => {
//     console.log(messages);
//   })

// Promise.allSettled([firstFetch(), secondFetch(), thirdFetch()])
//   .then((results) => {
//     results.forEach((result) => {
//       if (result.status === "fulfilled") {
//         console.log("Success: " + result.value);
//       } else {
//         console.log("Failure: " + result.reason);
//       }
//     });
//   });

// // 6. PROMISE WITH FETCH API

// let button = document.getElementById("load");
// button.addEventListener("click", loadRepos);

// function loadRepos() {
//   let url = "https://api.github.com/users/testnakov/repos";
//   fetch(url)
//     .then((response) => response.json())
//     .then((data) => {
//       document.getElementById("res").textContent = JSON.stringify(data, null, 2);
//     })
//     .catch((error) => {
//       console.error("Error fetching repos:", error);
//     });
// }

// // 7. ASYNC AWAIT WITH FETCH API

// function resolveAfter2Seconds() {
//   console.log("calling");
//   return new Promise(resolve => {
//     setTimeout(() => {
//       resolve("resolved");
//     }, 2000);
//   });
// }

// async function asyncCall() {
//   let result = await resolveAfter2Seconds();
//   console.log(result);
// }

// asyncCall();

// 8. GET REPOS WITH ASYNC AWAIT WITH FETCH API AND TRY CATCH BLOCK

let button = document.getElementById("load");
button.addEventListener("click", loadRepos);

async function loadRepos() {
  let url = "https://api.github.com/users/testnakov/repos";
  try {
    let response = await fetch(url);
    if (!response.ok) {
      throw new Error(`Error: ${response.status} (${response.statusText})`);
    }
    let data = await response.json();
    document.getElementById("res").textContent = JSON.stringify(data, null, 2);
  } catch (error) {
    document.getElementById("res").textContent = "Failed to load repos.";
    console.error(error);
  }
}
