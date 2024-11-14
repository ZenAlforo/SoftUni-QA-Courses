namespace _6._Travel_Savings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
           

            double savings = 0;

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());

                while (savings < budget)
                {
                    double amount = double.Parse(Console.ReadLine());
                    savings += amount;
                    Console.WriteLine($"Collected: {savings:f2}");
                }

                Console.WriteLine($"Going to {destination}!");
                savings = 0;
                destination = Console.ReadLine();
            }
        }
    }
}
