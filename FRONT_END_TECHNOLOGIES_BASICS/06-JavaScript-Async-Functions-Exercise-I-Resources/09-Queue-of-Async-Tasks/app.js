class AsyncQueue {
  constructor() {
    this.queue = [];
    this.isProcessing = false;
  }

  enqueue(task) {
    this.queue.push(task);
    if (!this.isProcessing) {
      this.isProcessing = true;
      this.processQueue();
    }
  }

  async processQueue() {
    while (this.queue.length > 0) {
      const task = this.queue.shift();
      await task();
    }
    this.isProcessing = false;
  }
}

function startQueue() {
  // Create an instance of AsyncQueue
  const asyncQueue = new AsyncQueue();

  asyncQueue.enqueue(
    async () =>
      await new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 1 is done");
          resolve();
        }, 1000),
      ),
  );
  asyncQueue.enqueue(
    async () =>
      await new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 2 is done");
          resolve();
        }, 3000),
      ),
  );
  asyncQueue.enqueue(
    async () =>
      await new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 3 is done");
          resolve();
        }, 500),
      ),
  );
  asyncQueue.enqueue(
    async () =>
      await new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 4 is done");
          resolve();
        }, 1000),
      ),
  );
  asyncQueue.enqueue(
    async () =>
      await new Promise((resolve) =>
        setTimeout(() => {
          console.log("Task 5 is done");
          resolve();
        }, 2000),
      ),
  );
}
