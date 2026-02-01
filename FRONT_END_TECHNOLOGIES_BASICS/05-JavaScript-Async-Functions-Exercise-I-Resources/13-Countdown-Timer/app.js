let timeLeft;

async function getCountdownInterval() {
  timeLeft = Number(prompt("Enter countdown time in seconds:"));
  let setTime = timeLeft;
  await startCountdown();
  console.log(`The ${setTime} seconds passed`);
}

function startCountdown() {
  return new Promise((resolve) => {
    const secondsLeft = setInterval(() => {
      if (timeLeft <= 0) {
        clearInterval(secondsLeft);
        resolve();
      } else {
        console.log(`Time left: ${timeLeft} seconds`);
        timeLeft--;
      }
    }, 1000);
  });
}
