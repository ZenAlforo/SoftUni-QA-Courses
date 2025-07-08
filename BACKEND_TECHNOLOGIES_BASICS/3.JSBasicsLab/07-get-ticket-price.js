function getTicketPrice(tarrif, age) {
	const WEEK_DAY_MINORS_PRICE = 12;
	const WEEK_DAY_ADULTS_PRICE = 18;
	const WEEK_DAY_ELDERS_PRICE = 12;
	const WEEKEND_MINORS_PRICE = 15;
	const WEEKEND_ADULTS_PRICE = 20;
	const WEEKEND_ELDERS_PRICE = 15;
	const HOLIDAY_MINORS_PRICE = 5;
	const HOLIDAY_ADULTS_PRICE = 12;
	const HOLIDAY_ELDERS_PRICE = 10;

	let ticketPrice;

	if (tarrif === "Weekday") {
		if (age >= 0 && age <= 18) {
			ticketPrice = WEEK_DAY_MINORS_PRICE;
		} else if (age > 18 && age <= 64) {
			ticketPrice = WEEK_DAY_ADULTS_PRICE;
		} else if (age > 64 && age <= 122) {
			ticketPrice = WEEK_DAY_ELDERS_PRICE;
		} else {
			ticketPrice = 0;
		}
	} else if (tarrif === "Weekend") {
		if (age >= 0 && age <= 18) {
			ticketPrice = WEEKEND_MINORS_PRICE;
		} else if (age > 18 && age <= 64) {
			ticketPrice = WEEKEND_ADULTS_PRICE;
		} else if (age > 64 && age <= 122) {
			ticketPrice = WEEKEND_ELDERS_PRICE;
		} else {
			ticketPrice = 0;
		}
	} else if (tarrif === "Holiday") {
		if (age >= 0 && age <= 18) {
			ticketPrice = HOLIDAY_MINORS_PRICE;
		} else if (age > 18 && age <= 64) {
			ticketPrice = HOLIDAY_ADULTS_PRICE;
		} else if (age > 64 && age <= 122) {
			ticketPrice = HOLIDAY_ELDERS_PRICE;
		} else {
			ticketPrice = 0;
		}
	} else {
		ticketPrice = 0;
	}

	if (ticketPrice > 0) {
		console.log(`${ticketPrice}$`);
	} else {
		console.log("Erorr!");
	}
}

getTicketPrice("Weekday", 42);
