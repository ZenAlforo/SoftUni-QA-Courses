async function fetchSequential() {
  const urls = [
    "https://swapi.dev/api/people/1",
    "https://swapi.dev/api/people/2",
    "https://swapi.dev/api/people/3"
  ];

  // with .then()
  for (const url of urls) {
      const response = await fetch(url).then(res => res.json());
      console.log(response);
  }

  // with async/await
  for (const url of urls) {
      const response = await fetch(url);
      const data = await response.json();
      console.log(data);
  }
}
