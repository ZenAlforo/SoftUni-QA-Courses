async function fetchData(url) {
  let result = await fetch(url)
    .then((response) => {
      if (response.ok) {
        return response.json();
      }
    })
    .catch((error) => {
      return error.message;
    });

  return result;
}

async function fakeDelay() {
  return new Promise((resolve) => {
    setTimeout(resolve, 2000);
  });
}

module.exports = {
  fetchData,
  fakeDelay,
};
