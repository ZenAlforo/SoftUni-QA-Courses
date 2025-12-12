function promiseRejection() {
  let promise = new Promise((resolve, reject) => {
    setTimeout(() => {
      reject("Error: Something went wrong!");
    }, 1000);
  });

  promise.catch((error) => {
    console.log(error);
  });
}

document
  .getElementById("btn")
  .addEventListener("click", () => promiseRejection());
