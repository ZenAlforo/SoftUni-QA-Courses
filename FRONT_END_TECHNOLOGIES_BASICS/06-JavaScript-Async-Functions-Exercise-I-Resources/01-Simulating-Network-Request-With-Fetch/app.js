async function fetchData() {
  let response = await fetch("https://swapi.dev/api/people/1");
  // .json() returns a promise
  response.json().then((data) => {
    console.log(data);
  });
}
