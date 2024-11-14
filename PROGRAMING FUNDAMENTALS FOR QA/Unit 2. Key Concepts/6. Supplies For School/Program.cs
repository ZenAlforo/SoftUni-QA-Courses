namespace _6._Supplies_For_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int penPackages = int.Parse(Console.ReadLine());
            int markerPackages = int.Parse(Console.ReadLine());
            int boardCleanerLitres = int.Parse(Console.ReadLine());
            int discountPercentage = int.Parse(Console.ReadLine());

            double penPrice = 5.8;
            double markerPrice = 7.2;
            double cleanerPrice = 1.2;

            double penTotalCost = penPackages * penPrice;
            double markerTotalCost = markerPackages * markerPrice;
            double cleanerTotalCost = boardCleanerLitres * cleanerPrice;

            double discountParsed = (double) discountPercentage / 100;

            double totalCost = penTotalCost + markerTotalCost + cleanerTotalCost;
            double finalAmountToPay = totalCost - totalCost * discountParsed;

            Console.WriteLine(finalAmountToPay);
        }
    }
}
