async function fetchDataWithErrorHandling() {
  try {
    const response = await fetch("https://swapi.dev/api/people/1");
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    const data = await response.json();
    console.log("Data fetched successfully:", data);
  } catch (error) {
    console.error("Error fetching data:", error);
  }
}
