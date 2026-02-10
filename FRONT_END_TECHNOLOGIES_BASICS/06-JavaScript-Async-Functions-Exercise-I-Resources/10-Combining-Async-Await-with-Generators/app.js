function asyncGenerator(generator) {
  function handleResult(result) {
    if (result.done) {
      return Promise.resolve(result.value);
    }
    return Promise.resolve(result.value).then(
      (res) => handleResult(generator.next(res)),
      (err) => handleResult(generator.throw(err)),
    );
  }

  try {
    return handleResult(generator.next());
  } catch (error) {
    return Promise.reject(error);
  }
}

function startAsyncGenerator() {
  asyncGenerator(generatorFunction());
}

// Generator function
function* generatorFunction() {
  const data1 = yield new Promise((resolve, reject) =>
    setTimeout(() => resolve("Task 1 is done"), 1000),
  );
  console.log(data1);
  try {
    const data2 = yield new Promise((resolve, reject) =>
      setTimeout(() => reject("Task 2 is rejected"), 2000),
    );
    console.log(data2);
  } catch (error) {
    console.error("Handled", error);
  }

  const data3 = yield new Promise((resolve, reject) =>
    setTimeout(() => resolve("Task 3 is done"), 500),
  );
  console.log(data3);
  const data4 = yield new Promise((resolve, reject) =>
    setTimeout(() => resolve("Task 4 is done"), 1000),
  );
  console.log(data4);
}
