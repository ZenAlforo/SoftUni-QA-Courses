namespace _10._Summer_Outfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());
            string dayTime = Console.ReadLine();

            string clothing = "";
            string shoes = "";

            switch (dayTime)
            {
                case "Morning":
                    switch (temperature)
                    {
                        case >= 10 and <= 18:
                            clothing = "Sweatshirt";
                            shoes = "Sneakers";
                            break;
                        case > 18 and <= 24:
                            clothing = "Shirt";
                            shoes = "Moccasins";
                            break;
                        case >= 25:
                            clothing = "T-Shirt";
                            shoes = "Sandals";
                            break;
                    }
                    break;

                case "Afternoon":
                    switch (temperature)
                    {

                        case >= 10 and <= 18:
                            clothing = "Shirt";
                            shoes = "Moccasins";
                            break;
                        case > 18 and <= 24:
                            clothing = "T-Shirt";
                            shoes = "Sandals";
                            break;
                        case >= 25:
                            clothing = "Swim Suit";
                            shoes = "Barefoot";
                            break;
                    }
                    break;

                case "Evening":
                    clothing = "Shirt";
                    shoes = "Moccasins";
                    
                    break;
            }

            Console.WriteLine($"It's {temperature} degrees, get your {clothing} and {shoes}.");
        }
    }
}
