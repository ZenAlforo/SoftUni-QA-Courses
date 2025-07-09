function getDriversSpeedInfo(driversSpeed, areaType) {
	MOTORWAY_SPEED_LIMIT = 130;
	INTERSTATE_SPEED_LIMIT = 90;
	CITY_SPEED_LIMIT = 50;
	RESIDENTIAL_SPEED_LIMIT = 20;

	let speedLimit;
	let status;
	let speedDifference;

	if (areaType === "motorway") {
		speedLimit = MOTORWAY_SPEED_LIMIT;
		speedDifference = driversSpeed - speedLimit;
	} else if (areaType === "interstate") {
		speedLimit = INTERSTATE_SPEED_LIMIT;
		speedDifference = driversSpeed - speedLimit;
	} else if (areaType === "city") {
		speedLimit = CITY_SPEED_LIMIT;
		speedDifference = driversSpeed - speedLimit;
	} else if (areaType === "residential") {
		speedLimit = RESIDENTIAL_SPEED_LIMIT;
		speedDifference = driversSpeed - speedLimit;
	}

	if (speedDifference <= 0) {
		console.log(`Driving ${driversSpeed} km/h in a ${speedLimit} zone`);
	} else {
		if (speedDifference <= 20) {
			status = "speeding";
		} else if (speedDifference <= 40) {
			status = "excessive speeding";
		} else {
			status = "reckless driving";
		}

		console.log(
			`The speed is ${speedDifference} km/h faster than the allowed speed of ${speedLimit} - ${status}`
		);
	}
}

getDriversSpeedInfo(40, "city");
getDriversSpeedInfo(21, "residential");
getDriversSpeedInfo(120, "interstate");
getDriversSpeedInfo(200, "motorway");
