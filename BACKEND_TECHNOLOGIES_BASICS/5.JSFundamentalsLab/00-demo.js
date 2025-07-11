let myArray = [1, 2, 3, 4, 5]

console.log(myArray.pop());
console.log(myArray.join());
console.log(myArray.push(10, 20, 30));
console.log(myArray.join());

console.log(myArray.shift());
console.log(myArray.join());

console.log(myArray.unshift(20, 20));
console.log(myArray.join());

console.log(myArray.splice(1, 3, 1));
console.log(myArray.join());

console.log(myArray.splice(2, 0, 1));
console.log(myArray.join());

console.log(myArray.splice(1, 3));
console.log(myArray.join());

console.log(myArray.slice(1, 3));
console.log(myArray.join());

console.log(myArray.includes(3));
console.log(myArray.join());

myArray.forEach((x) => console.log(x * 2));
console.log(myArray.join());

console.log(myArray.map((x) => x * 2));
console.log(myArray.join());

console.log(myArray.find(x => x < 40 && x > 20));

console.log(myArray.filter(x => x % 3 == 0));
