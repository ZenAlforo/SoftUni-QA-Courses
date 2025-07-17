function createEmployeesList(data) {
	let employees = [];

	for (let name of data) {
		employees.push({
			name: name, 
			number: name.length
		})
	}

	employees.forEach(x => console.log(`Name: ${x.name} -- Personal Number: ${x.number}`));

}

createEmployeesList([
	"Samuel Jackson",
	"Will Smith",
	"Bruce Willis",
	"Tom Holland",
]);
