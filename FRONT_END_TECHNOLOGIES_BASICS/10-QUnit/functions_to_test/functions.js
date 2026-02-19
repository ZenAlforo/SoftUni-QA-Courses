// sum function
function sum(a, b) {
  return a + b;
}

// divide function
function divide(a, b) {
  if (b === 0) {
    throw new Error("Cannot divide by zero");
  }
  return a / b;
}

// function isEven
function isEven(n) {
  return n % 2 === 0;
}

// function getFactorial
function factorial(n) {
  if (n < 0) {
    throw new Error("Factorial is not defined for negative numbers");
  } else if (n === 0 || n === 1) {
    return 1;
  } else {
    return n * factorial(n - 1);
  }
}

// function is number a palindrome
function isPalindrome(str) {
  if (str === "") {
    return false;
  }

  const cleanedStr = str.toLowerCase().replace(/[\W_]/g, "");
  const reversedStr = cleanedStr.split("").reverse().join("");
  return cleanedStr === reversedStr;
}

// function find fibonacci number
function fibonacci(n) {
  if (n === 0) {
    return [];
  }

  if (n === 1) {
    return [0];
  }

  let sequence = [0, 1];
  for (let i = 2; i < n; i++) {
    sequence.push(sequence[i - 1] + sequence[i - 2]);
  }
  return sequence;
}

// function find nth prime number
function nthPrime(n) {
  let count = 0;
  let num = 2;
  while (count < n) {
    if (isPrime(num)) {
      count++;
    }
    num++;
  }
  return num - 1;
}

function isPrime(num) {
  if (num <= 1) return false;
  if (num <= 3) return true;
  if (num % 2 === 0 || num % 3 === 0) return false;
  for (let i = 5; i * i <= num; i += 6) {
    if (num % i === 0 || num % (i + 2) === 0) return false;
  }
  return true;
}

// function get pascal triangle
function pascalsTriangle(rows) {
  const triangle = [];

  for (let i = 0; i < rows; i++) {
    const row = [];

    for (let j = 0; j <= i; j++) {
      if (j === 0 || j === i) {
        row.push(1);
      } else {
        row.push(triangle[i - 1][j - 1] + triangle[i - 1][j]);
      }
    }

    triangle.push(row);
  }

  return triangle;
}

// function is square perfect
function isPerfectSquare(n) {
  return Math.sqrt(n) % 1 === 0;
}

// exporting using common js
module.exports = {
  sum,
  divide,
  isEven,
  factorial,
  isPalindrome,
  fibonacci,
  nthPrime,
  pascalsTriangle,
  isPerfectSquare,
};
