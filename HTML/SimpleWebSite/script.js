function createCalculator() {

    let value = 0;
    
    return {   
        add: function(num) { value += Number(num); return this},
        subtract: function(num) { value -= Number(num); return this},
        get: function() { return value; }
    } 
}

const result = createCalculator().get();
console.log(result); 