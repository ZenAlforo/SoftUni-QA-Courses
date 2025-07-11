function createPersonObject(firstName, lastName, age) {
    
    function Person(firstName, lastName, age) {
        this.firstName = firstName, 
        this.lastName = lastName, 
        this.age = age;
    }

    let person = new Person(firstName, lastName, age);
    return person;
}

console.log(createPersonObject("John", "Doe", "36"));