let button = document.getElementsByTagName("button")[0];
button.addEventListener("click", promiseWithMultipleHandlers);

function promiseWithMultipleHandlers() {
  let promise = new Promise(function (resolve, reject) {
    setTimeout(() => resolve("Hello World!"), 1000);
  });

  // first way, just logging twice in the same handler
  promise.then((result) => {
    console.log(result);
    console.log(result);
  });

  // second way - two separate handlers
  promise.then((result) => console.log(result));
  promise.then((result) => console.log(result));

  // third way - chaining handlers

  promise
    .then((result) => {
      console.log(result);

      return result;
    })
    .then((result) => console.log(result));
}
