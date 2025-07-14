function validatePassword(password) {
	if (
		isPassLongEnough(password) &&
		isPassOnlyDigitsAndLetters(password) &&
		hasAtLeastTwoDigits(password)
	) {
		console.log("Password is valid");
	} else {
		if (!isPassLongEnough(password)) {
			console.log("Password must be between 6 and 10 characters");
		}

		if (!isPassOnlyDigitsAndLetters(password)) {
			console.log("Password must consist only of letters and digits");
		}

		if (!hasAtLeastTwoDigits(password)) {
			console.log("Password must have at least 2 digits");
		}
	}

	function isPassLongEnough(password) {
		let result =
			password.length >= 6 && password.length <= 10 ? true : false;
		return result;
	}

	function isPassOnlyDigitsAndLetters(password) {
		let result = /^[A-Za-z0-9]+$/.test(password);
		return result;
	}

	function hasAtLeastTwoDigits(password) {
		const match = password.match(/\d/g);
		return match && match.length >= 2;
	}
}

validatePassword('Pa$s$s');
