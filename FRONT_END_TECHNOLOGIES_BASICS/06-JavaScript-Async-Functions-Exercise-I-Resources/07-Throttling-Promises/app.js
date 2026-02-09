async function throttlePromises() {
  const asyncTasks = [
    () =>
      new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 1 is ready", Date.now());
          resolve("Task 1 solved");
        }, 6000),
      ),
    () =>
      new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 2 is ready", Date.now());
          resolve("Task 2 solved");
        }, 3500),
      ),
    () =>
      new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 3 is ready", Date.now());
          resolve("Task 3 solved");
        }, 2000),
      ),
    () =>
      new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 4 is ready", Date.now());
          resolve("Task 4 solved");
        }, 1500),
      ),
    () =>
      new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 5 is ready", Date.now());
          resolve("Task 5 solved");
        }, 500),
      ),
  ];

  async function throttle(tasks, limit) {
    const results = [];
    const executing = [];

    for (const task of tasks) {
      const p = task().then((result) => {
        executing.splice(executing.indexOf(p), 1);
        return result;
      });
      results.push(p);
      executing.push(p);

      if (executing.length >= limit) {
        await Promise.race(executing);
      }
    }

    return Promise.all(results);
  }

  const results = await throttle(asyncTasks, 2);
  console.log(`All tasks are done ${results}`);
}
