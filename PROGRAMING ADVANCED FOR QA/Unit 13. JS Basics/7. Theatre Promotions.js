function solve(dayType, clientsAge) {
    let ticketPrice;
    clientsAge = Number(clientsAge)
    if (clientsAge < 0 || clientsAge > 122) {
        console.log("Error!")
        return;
    }

    
    if (dayType == "Weekday") {

        ticketPrice = (clientsAge > 18 && clientsAge <=64 ) ? 18 : 12

    } else if (dayType == "Weekend") {
        ticketPrice = (clientsAge > 18 && clientsAge <=64 ) ? 20 : 15
            
    } else if (dayType == "Holiday") {
        if (clientsAge > 18 && clientsAge <= 64) {
            ticketPrice = 20;
        } else if (clientsAge >=0 && clientsAge <= 18) {
            ticketPrice = 5;
        } else {
            ticketPrice = 10
        }
        
    }

    console.log(`${ticketPrice}$`)
}

solve("Weekday", 0)