function solve([groupSize, groupProfile, dayOfTheWeek]) {

    groupSize = Number(groupSize)
    const studFriPrice = 8.45;
    const studSatPrice = 9.80;
    const studSunPrice = 10.46;

    const busFriPrice = 10.9;
    const busSatPrice = 15.6;
    const busSunPrice = 16;

    const regFriPrice = 15;
    const regSatPrice = 20;
    const regSunPrice = 22.5;

    const studentsThirtyAndPlusDiscount = 0.15;
    const businessHundredOrMorePeopleToDeduct = 10;
    const regularTenTillTwentyDiscount = 0.05;

    let totalCost = 0;

    switch (groupProfile) {
        case "Students": {
            switch (dayOfTheWeek) {
                case "Friday": {
                    totalCost = groupSize * studFriPrice;
                }; break;
                case "Saturday": {
                    totalCost = groupSize * studSatPrice;
                }; break;
                case "Sunday": {
                    totalCost = groupSize * studSunPrice;
                }; break;
            } 

            if (groupSize >= 30) {
                totalCost = totalCost - totalCost * studentsThirtyAndPlusDiscount
            }

        } break;
        case "Business": {
            let payingBusinessClients = groupSize;

            if (groupSize >= 100) {
                payingBusinessClients -= businessHundredOrMorePeopleToDeduct;
            }

            switch (dayOfTheWeek) {
                case "Friday": {
                    totalCost = payingBusinessClients * busFriPrice;
                }; break;
                case "Saturday": {
                    totalCost = payingBusinessClients * busSatPrice;
                }; break;
                case "Sunday": {
                    totalCost = payingBusinessClients * busSunPrice;
                }; break;
            }

        } break;
        case "Regular": {

            switch (dayOfTheWeek) {
                case "Friday": {
                    totalCost = groupSize * regFriPrice;
                }; break;
                case "Saturday": {
                    totalCost = groupSize * regSatPrice;
                }; break;
                case "Sunday": {
                    totalCost = groupSize * regSunPrice;
                }; break;
            }

            if (groupSize >= 10 && groupSize <= 20) {
                totalCost = totalCost - totalCost * regularTenTillTwentyDiscount
            }

        } break
    }

    console.log(`Total price: ${totalCost.toFixed(2)}`)
}

solve(['12', 'Students', 'Sunday'])