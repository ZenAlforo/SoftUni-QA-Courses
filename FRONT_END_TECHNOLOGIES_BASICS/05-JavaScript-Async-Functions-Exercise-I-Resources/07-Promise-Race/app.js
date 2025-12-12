// First one who resolves gets printed

function racePromise() {
  let promise1 = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("First Promise Resolved");
    }, 1000);
  });

  let promise2 = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Second Promise Resolved");
    }, 2000);
  });

  let promise3 = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Third Promise Resolved");
    }, 500);
  });

  Promise.race([promise1, promise2, promise3]).then((result) => {
    console.log(result);
  });
}
