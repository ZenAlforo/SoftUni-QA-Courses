

async function startQuiz() {
  let totalScore = 0;
  const questions = [
    {
      question: "What is 2 + 2?",
      answers: ["3", "4", "5"],
      correct: 1,
    },
    {
      question: "What is the capital of France?",
      answers: ["Berlin", "Madrid", "Paris"],
      correct: 2,
    },
    {
      question: "What is the square root of 16?",
      answers: ["4", "5", "6"],
      correct: 0,
    },
  ];

  for (const q of questions) {
    const isCorrect = await askQuestion(q.question, q.answers, q.correct);

    if (isCorrect) {
      totalScore++;
    }
  }

  console.log(`Your total score is: ${totalScore}`);
}

function askQuestion(question, answers, correct) {
  return new Promise((resolve) => {
    let promptText = question + "\n\nPossible answers:\n";

    answers.forEach((ans, index) => {
      promptText += `${index}: ${ans}\n`;
    });

    promptText += "\nEnter the number of your answer:";

    const userAnswer = prompt(promptText);

    if (Number(userAnswer) === correct) {
      alert("Correct!");
      resolve(true); // ✅ resolve Promise
    } else {
      alert("Wrong answer.");
      resolve(false); // ✅ still resolve, not reject
    }
  });
}
