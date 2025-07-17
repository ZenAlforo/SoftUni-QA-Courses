function addAndSubtract(a, b, c) {

    console.log(subtract(a, b, c));

    function sum(a, b) {
        return a + b;
    }

    function subtract(a, b, c) {
        return sum(a, b) - c;
    }
}

addAndSubtract(23, 6, 10)