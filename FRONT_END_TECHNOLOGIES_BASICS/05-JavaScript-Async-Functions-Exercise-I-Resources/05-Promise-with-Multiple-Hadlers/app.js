function promiseWithMultipleHandlers() {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Hello World!");
    }, 2000);
  });
}

// with individual handlers
document.getElementById("btn").addEventListener("click", () => {
  let promise = promiseWithMultipleHandlers();
  promise.then((message) => {
    console.log(message);
  });
  promise.then((message) => {
    console.log(message);
  });
});

// with chained handlers
document.getElementById("btn").addEventListener("click", () => {
  let promise = promiseWithMultipleHandlers();
  promise
    .then((message) => {
      console.log(message);
      return message;
    })
    .then((message) => {
      console.log(message);
    });
});
