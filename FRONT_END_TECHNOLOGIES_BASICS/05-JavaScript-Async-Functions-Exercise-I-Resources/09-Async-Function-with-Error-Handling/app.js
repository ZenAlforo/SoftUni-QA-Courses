async function promiseRejectionAsync() {
  let promise = new Promise((resolve, reject) => {
    setTimeout(() => {
      reject("Something went wrong!");
      // // reject with throwing error
      // reject(new Error("Something went wrong!"));
    }, 1000);
  });

  try {
    await promise;
  } catch (error) {
    console.log(error);
  }
}
