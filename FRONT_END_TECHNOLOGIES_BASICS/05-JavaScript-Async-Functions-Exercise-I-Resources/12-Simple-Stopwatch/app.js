let time = 0;
let counter = null;
let fiveSecondTimer = null;

function startStopwatch() {
  if (counter !== null) return;
  // console.log("Stopwatch started");

  counter = setInterval(() => {
    time++;
    console.log(`Time: ${time} seconds`);
  }, 1000);

  fiveSecondTimer = setInterval(async () => {
    await logTimeEveryFiveSeconds();
  }, 5000);
}

function stopStopwatch() {
  if (counter === null) return;
  console.log("Stopwatch stopped");

  clearInterval(counter);
  clearInterval(fiveSecondTimer);

  counter = null;
  fiveSecondTimer = null;

  console.log(`Your time is ${time} seconds`);
  time = 0; // Reset time for next start
}

function logTimeEveryFiveSeconds() {
  return new Promise((resolve) => {
    resolve(console.log(`Logging at ${time} seconds`));
  });
}
