async function fetchParallel() {
  const url1 = "https://swapi.dev/api/people/1";
  const url2 = "https://swapi.dev/api/people/2";
  const url3 = "https://swapi.dev/api/people/3";

  const [response1, response2, response3] = await Promise.all([
    fetch(url1),
    fetch(url2),
    fetch(url3),
  ]);

  console.log(await response1.json());
  console.log(await response2.json());
  console.log(await response3.json());
}
