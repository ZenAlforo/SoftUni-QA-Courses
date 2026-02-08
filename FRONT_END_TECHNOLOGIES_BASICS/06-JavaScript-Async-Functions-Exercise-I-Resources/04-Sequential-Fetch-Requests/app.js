async function fetchSequential() {
  try {
    const firstResponse = await fetch("https://swapi.dev/api/people/1/");
    if (!firstResponse.ok) {
      throw new Error(`HTTP error! status: ${firstResponse.status} for the first request`);
    }
    const firstData = await firstResponse.json();
    console.log("First request response: ", firstData);

    const secondResponse = await fetch("https://swapi.dev/api/people/2/");
    if (!secondResponse.ok) {
      throw new Error(`HTTP error! status: ${secondResponse.status} for the second request`);
    }
    const data2 = await secondResponse.json();
    console.log(`Second request response: `, data2);
  } catch (error) {
    console.error("Error fetching data:", error);
  }
}
