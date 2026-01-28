async function chainedPromisesAsync() {
  try {
    const results = await Promise.all([
      new Promise((resolve) => setTimeout(() => resolve("First!"), 1000)),
      new Promise((resolve) => setTimeout(() => resolve("Second!"), 2000)),
      new Promise((resolve) => setTimeout(() => resolve("Third!"), 3000)),
    ]);

    console.log(`All promises resolved with: ${results.join(", ")}`);
  } catch (error) {
    console.log(error);
  }
}
