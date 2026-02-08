async function retryPromise(randomPromiseResult, retries = 3) {
  for (let attempt = 1; attempt <= retries; attempt++) {
    try {
      const result = await randomPromiseResult();
      console.log(`Attempt ${attempt}: ${result}`);
      return result; // Exit if the promise is resolved
    } catch (error) {
      console.log(`Attempt ${attempt} failed: ${error}`);
      if (attempt === retries) {
        console.log("All attempts failed. No more retries.");
        throw new Error("GG, You are cooked!"); // Rethrow the error after exhausting all retries
      }
    }
  }
}

const unstablePromise = () => {
  return new Promise((resolve, reject) => {
    const randomOutcome = Math.random() > 0.5;
    if (randomOutcome) {
      resolve("Promise resolved");
    } else {
      reject("Promise rejected");
    }
  });
};

function startRetrying() {
  retryPromise(unstablePromise)
    .then((result) => console.log(`Final Result: ${result}`))
    .catch((error) => console.error(`${error}`));
}
