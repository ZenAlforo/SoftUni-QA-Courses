async function fetchData(url) {
  let result = await fetch(url)
    .then((response) => {
      if (response.ok) {
        return response.json();
      }
    })
    .catch((error) => {
      console.error("Error fetching data:", error);
    });

  return result;
}


fetchData("https://www.zippopotam.us/bg/8000")
