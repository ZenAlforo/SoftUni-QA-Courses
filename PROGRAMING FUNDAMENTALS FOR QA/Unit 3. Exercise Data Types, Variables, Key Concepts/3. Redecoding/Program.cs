namespace _3._Redecoding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nylonSqM = int.Parse(Console.ReadLine());
            int paintLiters = int.Parse(Console.ReadLine());
            int thinnerLiters = int.Parse(Console.ReadLine());
            int hoursWork = int.Parse(Console.ReadLine());

            double nylonPrice = 1.50;
            double paintPrice = 14.50;
            double thinnerPrice = 5.00;

            double nylonCost = (nylonSqM + 2) * nylonPrice;
            double paintCost = (paintLiters * 1.1) * paintPrice;
            double thinnerCost = thinnerLiters * thinnerPrice;

            double totalMaterialCost = nylonCost + paintCost + thinnerCost + 0.4;

            double workCost = (totalMaterialCost * 0.3) * hoursWork;

            double totalCost = totalMaterialCost + workCost;

            Console.WriteLine(totalCost);
        }
    }
}
