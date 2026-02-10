async function fetchWithTimeout(
  url = "https://swapi.dev/api/people/1",
  timeout = 55,
) {
  try {
    const data = await Promise.race([
      // first promise
      fetch(url).then((response) => response.json()),
      // second promise
      new Promise((_, reject) => {
        setTimeout(() => {
          reject(new Error("Request timed out"));
        }, timeout);
      }),
    ]);

    console.log("Request completed successfully", data);
  } catch (error) {
    console.log(`Error received: ${error}`);
  }
}

