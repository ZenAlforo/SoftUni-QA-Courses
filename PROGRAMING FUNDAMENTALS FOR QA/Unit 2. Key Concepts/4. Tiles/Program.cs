namespace _4._Tiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bathWidth = double.Parse(Console.ReadLine());
            double bathHeight = double.Parse(Console.ReadLine());
            double tileWidth = double.Parse(Console.ReadLine());
            double tileHeight = double.Parse(Console.ReadLine());

            double surplus = 1.10;
            double bathArea = bathWidth * bathHeight;
            double tileArea = tileWidth * tileHeight;

            double result = (bathArea * surplus) / tileArea;

            Console.WriteLine(Math.Round(result));
        }
    }
}
