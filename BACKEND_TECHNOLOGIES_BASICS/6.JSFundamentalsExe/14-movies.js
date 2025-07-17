function printMoviesObjects(commandInfo) {
	let movies = [];

	function Movie(name, date, director) {
		(this.name = name), (this.date = date), (this.director = director);
	}

	for (let command of commandInfo) {
		let movieName;
		let date;
		let director;

		if (command.includes("addMovie")) {
			movieName = command.replace("addMovie", "").trim();
			movies.push(new Movie(movieName, "", ""));
		} else if (command.includes("directedBy")) {
			movieName = command.split(" directedBy ")[0];
			directedBy = command.split(" directedBy ")[1];

			let result = movies.find((movie) => movie.name == movieName);
			if (result) {
				result.director = directedBy;
			}
		} else if (command.includes("onDate")) {
			movieName = command.split(" onDate ")[0];
			date = command.split(" onDate ")[1];

			let result = movies.find((movie) => movie.name == movieName);
			if (result) {
				result.date = date;
			}
		}
	}

	for (let movie of movies) {
		console.log(JSON.stringify(movie));
	}
}

printMoviesObjects([
	"addMovie Fast and Furious",
	"addMovie Godfather",
	"Inception directedBy Christopher Nolan",
	"Godfather directedBy Francis Ford Coppola",
	"Godfather onDate 29.07.2018",
	"Fast and Furious onDate 30.07.2018",
	"Batman onDate 01.08.2018",
	"Fast and Furious directedBy Rob Cohen",
]);
