async function fetchData() {
    let response = await fetch("https://swapi.dev/api/people/1/");
    let data = await response.json();
    console.log(data);
}
