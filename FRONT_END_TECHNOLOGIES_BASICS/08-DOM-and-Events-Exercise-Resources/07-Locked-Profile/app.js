function lockedProfile() {
  const profiles = document.querySelectorAll(".profile");

  profiles.forEach((profile) => {
    const button = profile.querySelector("button");

    button.addEventListener("click", function () {
      const isLocked = profile.querySelector('input[value="lock"]').checked;

      if (isLocked) {
        return; // ако е заключен, нищо не правим
      }

      const hiddenFields = profile.querySelector("div");

      if (hiddenFields.style.display === "block") {
        hiddenFields.style.display = "none";
        button.textContent = "Show more";
      } else {
        hiddenFields.style.display = "block";
        button.textContent = "Hide it";
      }
    });
  });
}
