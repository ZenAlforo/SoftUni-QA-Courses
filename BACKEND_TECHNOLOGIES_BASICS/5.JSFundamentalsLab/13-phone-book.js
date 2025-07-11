function getPhoneBookInfo(phoneData) {
    
    let phoneBook = {};

    for (let contact of phoneData) {
        let [name, number] = contact.split(" ");
        phoneBook[name] = number;
    }

    for (let contact of Object.keys(phoneBook)) {
        console.log(`${contact} -> ${phoneBook[contact]}`);
    }
}

getPhoneBookInfo([
	"Tim 0834212554",
	"Peter 0877547887",
	"Bill 0896543112",
	"Tim 0876566344",
]);
