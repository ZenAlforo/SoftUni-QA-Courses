function solve() {
  let textToTransform = document.getElementById("text").value.toLowerCase();
  let type = document.getElementById("naming-convention").value.toLowerCase();

  let result = document.getElementById("result");

  let input = textToTransform.trim().split(/\s+/);

  if (type === "camel case") {
    result.textContent = toCamelCase(input);
  } else if (type === "pascal case") {
    result.textContent = toPascalCase(input);
  } else {
    result.textContent = "Error!";
  }
}

function toCamelCase(input) {
  let output = [];
  for (let [index, word] of input.entries()) {
    if (index === 0) {
      output.push(word);
    } else {
      output.push(word[0].toUpperCase() + word.slice(1));
    }
  }

  return output.join("");
}

function toPascalCase(input) {
  let output = [];
  for (let word of input) {
    output.push(word[0].toUpperCase() + word.slice(1));
  }

  return output.join("");
}
