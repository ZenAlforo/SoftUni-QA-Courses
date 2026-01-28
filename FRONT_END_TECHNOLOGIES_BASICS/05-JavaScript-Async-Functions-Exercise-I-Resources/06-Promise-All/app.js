let button = document.getElementById("myButton");
button.addEventListener("click", () => {
    solveWithThen();
    solveWithAsync();
});

function allPromise() {
  const firstPromise = new Promise((resolve) =>
    setTimeout(() => resolve("First!"), 1000),
  );
  const secondPromise = new Promise((resolve) =>
    setTimeout(() => resolve("Second!"), 2000),
  );
  const thirdPromise = new Promise((resolve) =>
    setTimeout(() => resolve("Third!"), 3000),
  );

//   // first way to use Promise.all
//   Promise.all([firstPromise, secondPromise, thirdPromise]).then((values) => console.log(values));

  // second way to use Promise.all with return

  return Promise.all([firstPromise, secondPromise, thirdPromise]);
}

// solve function to call allPromise and log the results
function solveWithThen() {
    allPromise().then((values) => {
        for (const value of values) {
            console.log(value);
        }
    });
}

// solve function with async/await

async function solveWithAsync() {
    const values = await allPromise();
    for (const value of values) {
        console.log(value);
    }
}
