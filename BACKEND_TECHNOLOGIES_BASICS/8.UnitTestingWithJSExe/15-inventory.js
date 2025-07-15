function registerHeroes(data) {
	let heroRegister = [];

	for (let heroData of data) {
		let [heroName, heroLevel, heroInventory] = heroData.split(" / ");
		let items = heroInventory.split(", ");

		heroRegister.push({
			name: heroName,
			level: heroLevel,
			items: items,
		});
	}

    heroRegister.sort((a, b) => (a.level) - (b.level))
	heroRegister.forEach((hero) => {
		console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(", ")}`);
	});
}

registerHeroes([

'Batman / 2 / Banana, Gun',

'Superman / 18 / Sword',

'Poppy / 28 / Sentinel, Antara'

]);
