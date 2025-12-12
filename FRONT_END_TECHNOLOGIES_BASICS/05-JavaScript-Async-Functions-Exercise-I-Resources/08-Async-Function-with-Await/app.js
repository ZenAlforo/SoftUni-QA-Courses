async function simplePromiseAsync() {
  let promise = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Async/Await is awesome!");
    }, 2000);
  });

  let result = await promise;
  console.log(result);
}
