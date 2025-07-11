function getGrade(grade) {
	let gradeText;

	if (grade < 3.0) {
		gradeText = "Fail";
	} else if (grade >= 3.0 && grade < 3.5) {
		gradeText = "Poor";
	} else if (grade >= 3.5 && grade < 4.5) {
		gradeText = "Good";
	} else if (grade >= 4.5 && grade < 5.5) {
		gradeText = "Very good";
	} else if (grade >= 5.5) {
		gradeText = "Excellent";
	}

    console.log(`${gradeText} (${grade})`);
}

getGrade(3.33)