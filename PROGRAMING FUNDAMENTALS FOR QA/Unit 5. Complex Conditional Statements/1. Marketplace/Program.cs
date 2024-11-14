namespace _1._Marketplace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();

            double bananaPrice = 2.50;
            double bananaWeekendPrice = 2.70;
            double applePrice = 1.30;
            double appleWeekendPrice = 1.60;
            double kiwiPrice = 2.20;
            double kiwiWeekendPrice = 3.00;

            if (day == "Weekday")
            {
                if (product == "Banana")
                {
                    Console.WriteLine($"{bananaPrice:F2}");
                } else if (product == "Apple")
                {
                    Console.WriteLine($"{applePrice:F2}");
                } else if (product == "Kiwi")
                {
                    Console.WriteLine($"{kiwiPrice:F2}");
                }
            }
            else if (day == "Weekend")
            {
                if (product == "Banana")
                {
                    Console.WriteLine($"{bananaWeekendPrice:F2}");
                }
                else if (product == "Apple")
                {
                    Console.WriteLine($"{appleWeekendPrice:F2}");
                }
                else if (product == "Kiwi")
                {
                    Console.WriteLine($"{kiwiWeekendPrice:F2}");
                }
            }
        }
    }
}
