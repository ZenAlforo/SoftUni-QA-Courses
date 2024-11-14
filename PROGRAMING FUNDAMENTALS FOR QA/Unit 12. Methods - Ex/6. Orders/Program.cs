namespace _6._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double price = 0;

            if (order == "coffee")
            {
                price = 1.5;
            } else if (order == "water")
            {
                price = 1.0;
            } else if (order == "coke")
            {
                price = 1.4;
            } else if (order == "snacks")
            {
                price = 2.0;
            }

            Console.WriteLine($"{FindOrderCost(quantity, price):f2}");

            static double FindOrderCost(int quantity, double price)
            {
                double cost = quantity * price;
                return cost;
            }
        }
    }
}
