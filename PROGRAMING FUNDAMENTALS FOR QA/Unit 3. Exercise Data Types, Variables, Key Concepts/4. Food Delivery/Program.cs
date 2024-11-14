namespace _4._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenuCount = int.Parse(Console.ReadLine());
            int fishMenuCount = int.Parse(Console.ReadLine());
            int vegeMenuCount = int.Parse(Console.ReadLine());

            double chickenMenuPrice = 10.35;
            double fishMenuPrice = 12.40;
            double vegeMenuPrice = 8.15;

            double totalChickenMenuCost = chickenMenuPrice * chickenMenuCount;
            double totalFishMenuCost = fishMenuPrice * fishMenuCount;
            double totalVegeMenuCost = vegeMenuPrice * vegeMenuCount;

            double mainDishesCost = totalChickenMenuCost + totalFishMenuCost + totalVegeMenuCost;
            double desertCosts = mainDishesCost * 0.2;
            double deliveryCost = 2.5;

            double totalOrderCost = mainDishesCost + desertCosts + deliveryCost;

            Console.WriteLine(totalOrderCost);
        }
    }
}
