async function fetchDataWithErrorHandling() {
  try {
    let response = await fetch("https://swapi.dev/api/people/555");
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const data = await response.json();
    console.log(data);
  } catch (error) {
    console.log("Error happend", error);
  }
}
