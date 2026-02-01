// // SOLUTION WITH ALERTS AND PROMPTS

// function startQuiz() {

//   let result = 0;

//   const answer = prompt("What is 2 + 2?\n" +
//                         "Possible answers: 3, 4, 5");
//   if (answer.trim() === "4") {
//     alert("Correct!");
//     result++;
//   } else {
//     alert("Incorrect. The correct answer is 4.");
//   }

//   const answer2 = prompt("What is the capital of France?\n" +
//                         "Possible answers: Berlin, Madrid, Paris");
//   if (answer2.trim().toLowerCase() === "paris") {
//     alert("Correct!");
//     result++;
//   } else {
//     alert("Incorrect. The correct answer is Paris.");
//   }

//   const answer3 = prompt("What is the square root of 16?\n" +
//                         "Possible answers: 4, 5, 6");
//   if (answer3.trim() === "4") {
//     alert("Correct!");
//     result++;
//   } else {
//     alert("Incorrect. The correct answer is 4.");
//   }

//   alert("Quiz completed!");
//   alert(`Your total score is: ${result} out of 3`);
// }

// SOLUTION WITH CONSOLE AND PROMISES/ASYNC FUNCTIONS

async function startQuiz() {

  let result = 0;

  const questions = [
    {
      question: "What is 2 + 2?",
      answers: ["3", "4", "5"],
      correct: "4"
    },
    {
      question: "What is the capital of France?",
      answers: ["Berlin", "Madrid", "Paris"],
      correct: "paris"
    },
    {
      question: "What is the square root of 16?",
      answers: ["4", "5", "6"],
      correct: "4"
    }
  ];

  console.log("Your quiz is starting, good luck!");

  for (const q of questions) {
    let points = await askQuestion(q);
    if (points) {
      result++;
    }
  }

  console.log("Quiz completed!");
  console.log(`Your total score is: ${result} out of ${questions.length}`);

}

function askQuestion(q) {
  return new Promise((resolve) => {
    const answer = prompt(`${q.question}\nPossible answers: ${q.answers.join(", ")}\nYour answer: `);
    if (answer.trim().toLowerCase() === q.correct) {
      console.log("Correct!");
      resolve(1);
    } else {
      console.log(`Incorrect. The correct answer is ${q.correct}.`);
      resolve(0);
    }
  })
}
