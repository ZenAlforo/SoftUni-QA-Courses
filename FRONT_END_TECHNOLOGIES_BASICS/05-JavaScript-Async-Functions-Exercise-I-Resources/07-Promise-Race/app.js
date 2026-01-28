function racePromise() {
  const firstPromise = new Promise((resolve) =>
    setTimeout(() => resolve("First!"), 1000),
  );
  const secondPromise = new Promise((resolve) =>
    setTimeout(() => resolve("Second!"), 2000),
  );
  const thirdPromise = new Promise((resolve) =>
    setTimeout(() => resolve("Third!"), 3000),
  );

  let firstResolved = Promise.race([firstPromise, secondPromise, thirdPromise]);
  firstResolved.then((value) => console.log(value));
}
