function solve(stringArray) {

    let phoneBook = {}

    for (let personInfo of stringArray) {
        let [name, phone] = personInfo.split(" ");
        phoneBook[name] = phone;
    }

    for(let [name, phone] of Object.entries(phoneBook)) {
        console.log(`${name} -> ${phone}`)
    }
}

solve(['Tim 0834212554',

    'Peter 0877547887',
    
    'Bill 0896543112',
    
    'Tim 0876566344']) 
