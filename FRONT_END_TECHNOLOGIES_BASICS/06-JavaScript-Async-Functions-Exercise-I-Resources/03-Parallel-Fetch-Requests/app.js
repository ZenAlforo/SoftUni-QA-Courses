async function fetchParallel() {
  try {
    const responses = await Promise.all([
      fetch("https://swapi.dev/api/people/1/"),
      fetch("https://swapi.dev/api/people/2/"),
    ]);

    for (const [index, response] of responses.entries()) {
      if (!response.ok) {
        throw new Error(
          `HTTP error! status: ${response.status} for request ${index + 1}`,
        );
      }

      const data = await response.json();
      console.log(`Request ${index + 1} response: `, data);
    }
  } catch (error) {
    console.error("Error fetching data:", error);
  }
}
