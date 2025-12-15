async function retryPromise(unstableTask, retries = 3) {
  let attempts = retries;
  while (attempts > 0) {
    try {
      const result = await unstableTask();
      return result;
    } catch (error) {
      attempts--;
      console.warn(`Attempt failed. Retries left: ${attempts}`);
      if (attempts === 0) {
        throw new Error(`All ${retries} retries failed.`);
      }

      await new Promise((resolve) => setTimeout(resolve, 1000)); // wait 1 second before retrying
    }
  }
}

function unstableTask() {
  return new Promise((resolve, reject) => {
    // Simulate a task that has a 50% chance to fail
    if (Math.random() > 0.5) {
      resolve("Operation succeeded!");
    } else {
      reject(new Error());
    }
  });
}

function executeRetry() {
  retryPromise(unstableTask)
    .then((result) => console.log(result))
    .catch((error) => console.error(error.message));
}
