function attachEventsListeners() {
  const daysInput = document.getElementById("days");
  const hoursInput = document.getElementById("hours");
  const minutesInput = document.getElementById("minutes");
  const secondsInput = document.getElementById("seconds");

  function convertToAll(seconds) {
    daysInput.value = seconds / 86400;
    hoursInput.value = seconds / 3600;
    minutesInput.value = seconds / 60;
    secondsInput.value = seconds;
  }

  document.getElementById("daysBtn").addEventListener("click", () => {
    convertToAll(Number(daysInput.value) * 86400);
  });

  document.getElementById("hoursBtn").addEventListener("click", () => {
    convertToAll(Number(hoursInput.value) * 3600);
  });

  document.getElementById("minutesBtn").addEventListener("click", () => {
    convertToAll(Number(minutesInput.value) * 60);
  });

  document.getElementById("secondsBtn").addEventListener("click", () => {
    convertToAll(Number(secondsInput.value));
  });
}
