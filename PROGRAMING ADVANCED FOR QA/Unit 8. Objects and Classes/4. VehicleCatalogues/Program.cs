namespace _4._VehicleCatalogues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Catalog myCatalogue = new Catalog();

            while (input != "end")
            {
                string[] vehicleDetails = input.Split("/");
                string vehicle = vehicleDetails[0];
                string brand = vehicleDetails[1];
                string model = vehicleDetails[2];
                
                if (vehicle == "Car")
                {
                    int power = int.Parse(vehicleDetails[3]);
                    Car currentCar = new Car(brand, model, power);
                    myCatalogue.Cars.Add(currentCar);
                } else
                {
                    int weight = int.Parse(vehicleDetails[3]);
                    Truck currentTruck = new Truck(brand, model, weight);
                    myCatalogue.Trucks.Add(currentTruck);
                }

                input = Console.ReadLine();
            }

            if (myCatalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach ( Car car in myCatalogue.Cars.OrderBy(car => car.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (myCatalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in myCatalogue.Trucks.OrderBy(truck => truck.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }

        class Truck
        {
            public Truck(string brand, string model, int weight)
            {
                Brand = brand;
                Model = model;
                Weight = weight;
                
            }
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }

        class Car
        {
            public Car(string brand, string model, int power)
            {
                Brand= brand;
                Model = model;
                HorsePower = power;
            }
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }

        class Catalog
        {
            public Catalog()
            {
                Cars = new List<Car>();
                Trucks = new List<Truck>();
            }
            public List<Car> Cars { get; set; }
            public List<Truck> Trucks { get; set; }

        }
    }
}
