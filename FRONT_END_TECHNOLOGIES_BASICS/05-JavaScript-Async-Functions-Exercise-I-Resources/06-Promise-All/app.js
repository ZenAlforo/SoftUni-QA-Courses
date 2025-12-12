// Testing what happens when some promises resolve and some reject => the Promise.all returns only the rejected one,
// or if more been rejected - the fitrst one that got rejected

function allPromise() {
  let promise1 = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("First Promise Resolved");
    }, 1000);
  });

  let promise2 = new Promise((resolve, reject) => {
    setTimeout(() => {
      reject("Second Promise Rejected");
    }, 2000);
  });

  let promise3 = new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve("Third Promise Resolved");
    }, 3000);
  });

  Promise.all([promise1, promise2, promise3])
    .then((result) => {
      console.log(result);
    })
    .catch((error) => {
      console.log(error);
    });
}
