namespace _3._Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tomatoPrice = double.Parse(Console.ReadLine());
            double tomatoQuantity = double.Parse(Console.ReadLine());
            double cucumbersPrice = double.Parse(Console.ReadLine());
            double cucumbersQuantity = double.Parse(Console.ReadLine());

            double totalProfit = tomatoPrice * tomatoQuantity + cucumbersPrice * cucumbersQuantity;
            Console.WriteLine($"{totalProfit:F2}");
        }
    }
}
