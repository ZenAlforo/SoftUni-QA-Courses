function getVacationCost(paxCount, groupType, weekDay) {
	let totalCost = 0;

	switch (weekDay) {
		case "Friday":
			{
				switch (groupType) {
					case "Students":
						{
							totalCost = paxCount * 8.45;

							if (paxCount >= 30) {
								totalCost -= totalCost * 0.15;
							}
						}
						break;
					case "Business":
						{
							if (paxCount >= 100) {
								totalCost = (paxCount - 10) * 10.9;
							} else {
								totalCost = paxCount * 10.9;
							}
						}
						break;
					case "Regular":
						{
							totalCost = paxCount * 15;

							if (paxCount >= 10 && paxCount <= 20) {
								totalCost -= totalCost * 0.1;
							}
						}
						break;
					default:
						{
							console.log("Error!");
						}
						break;
				}
			}
			break;
		case "Saturday":
			{
				switch (groupType) {
					case "Students":
						{
							totalCost = paxCount * 9.8;

							if (paxCount >= 30) {
								totalCost -= totalCost * 0.15;
							}
						}
						break;
					case "Business":
						{
							if (paxCount >= 100) {
								totalCost = (paxCount - 10) * 15.6;
							} else {
								totalCost = paxCount * 15.6;
							}
						}
						break;
					case "Regular":
						{
							totalCost = paxCount * 20;

							if (paxCount >= 10 && paxCount <= 20) {
								totalCost -= totalCost * 0.1;
							}
						}
						break;
					default:
						{
							console.log("Error!");
						}
						break;
				}
			}
			break;
		case "Sunday":
			{
				switch (groupType) {
					case "Students":
						{
							totalCost = paxCount * 10.46;

							if (paxCount >= 30) {
								totalCost -= totalCost * 0.15;
							}
						}
						break;
					case "Business":
						{
							if (paxCount >= 100) {
								totalCost = (paxCount - 10) * 16;
							} else {
								totalCost = paxCount * 16;
							}
						}
						break;
					case "Regular":
						{
							totalCost = paxCount * 22.5;

							if (paxCount >= 10 && paxCount <= 20) {
								totalCost -= totalCost * 0.1;
							}
						}
						break;
					default:
						{
							console.log("Error!");
						}
						break;
				}
			}
			break;
		default:
			{
			}
			break;
	}

	console.log(`"Total price: ${totalCost.toFixed(2)}`);
}

getVacationCost(40, "Students", "Sunday")
