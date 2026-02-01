async function startAdventure() {
  console.log("Welcome to the Adventure Game!");

  let input = await getClientInput("Type 'start' to begin or 'exit' to quit.");

  while (true) {
    if (input === "exit") {
      console.log("Thank you for playing! Goodbye!");
      return;
    }

    if (input !== "start") {
      input = await getClientInput(
        "Invalid choice. Please type 'start' or 'exit'.",
      );
      continue;
    }

    // === GAME START ===
    input = await getClientInput(
      "You find yourself in a dark forest. Go 'left' or 'right'.",
    );

    if (input === "left") {
      input = await getClientInput(
        "You encounter a wild beast! 'fight' or 'run'?",
      );

      if (input === "fight") {
        console.log("You bravely fight the beast and win!");
      } else if (input === "run") {
        console.log("You ran away safely.");
      } else {
        console.log("The beast got tired of waiting and left.");
      }
    } else if (input === "right") {
      input = await getClientInput(
        "You find a treasure chest! 'open' or 'leave'?",
      );

      if (input === "open") {
        console.log("You found treasure! You win!");
      } else if (input === "leave") {
        console.log("You leave the chest and walk away.");
      } else {
        console.log("The chest disappears...");
      }
    } else {
      console.log("You got lost in the forest.");
    }

    // Restart?
    input = await getClientInput("Would you like to 'start' again or 'exit'?");
  }
}

function getClientInput(message) {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve(prompt(message).toLowerCase());
    }, 2000);
  });
}
