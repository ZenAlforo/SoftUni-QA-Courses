async function simplePromiseAsync() {
  try {
    const result = await new Promise(resolve => {
      setTimeout(() => resolve("Async/Await is awesome!"), 2000);
    });
    console.log(result);
  } catch (error) {
    console.error(error);
  }
}
    