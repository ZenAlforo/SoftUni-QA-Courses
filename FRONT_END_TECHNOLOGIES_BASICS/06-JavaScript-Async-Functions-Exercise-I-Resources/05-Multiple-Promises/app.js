function multiplePromises() {
  const firstResult = new Promise((resolve) =>
    setTimeout(() => resolve("First promise resolved"), 1000),
  );
  const secondResult = new Promise((_, reject) =>
    setTimeout(() => reject("Second promise rejected"), 2000),
  );
  const thirdResult = new Promise((resolve) =>
    setTimeout(() => resolve("Third promise resolved"), 1000),
  );

  Promise.allSettled([firstResult, secondResult, thirdResult]).then(
    (results) => {
      results.forEach((result, index) => {
        console.log(
          `Promise ${index + 1} status is ${result.status} with message: ${result.value || result.reason}`,
        );
      });
    },
  );
}
