function startQuiz() {
  console.log("What is 2 + 2?");
  console.log("Possible asnwers: 3, 4, 5");
  let result = 0;

  const answer = prompt();
  if (answer.trim() === "4") {
    console.log("Correct!");
    result++;
  } else {
    console.log("Incorrect. The correct answer is 4.");
  }

  console.log("What is the capital of France?");
  console.log("Possible answers: Berlin, Madrid, Paris");
  const answer2 = prompt();
  if (answer2.trim().toLowerCase() === "paris") {
    console.log("Correct!");
    result++;
  } else {
    console.log("Incorrect. The correct answer is Paris.");
  }

  console.log("What is the square root of 16?");
  console.log("Possible answers: 4, 5, 6");
  const answer3 = prompt();
  if (answer3.trim() === "4") {
    console.log("Correct!");
    result++;
  } else {
    console.log("Incorrect. The correct answer is 4.");
  }

  console.log("Quiz completed!");
  console.log(`Your total score is: ${result} out of 3`);
}
