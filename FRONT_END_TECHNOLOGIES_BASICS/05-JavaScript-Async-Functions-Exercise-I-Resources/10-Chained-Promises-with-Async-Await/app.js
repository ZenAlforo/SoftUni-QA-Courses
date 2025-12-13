async function chainedPromisesAsync() {
  let promise1 = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("First Promise Resolved");
    }, 1000);
  });

  let result1 = await promise1;
  console.log(result1);

  let promise2 = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Second Promise Resolved");
    }, 1000);
  });

  let result2 = await promise2;
  console.log(result2);

  let promise3 = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Third Promise Resolved");
    }, 1000);
  });

  let result3 = await promise3;
  console.log(result3);
}
