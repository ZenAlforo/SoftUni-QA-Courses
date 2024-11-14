namespace _1._Convert_USD_to_EUR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double tariff = 0.88;
            double eur = usd * tariff;
            Console.WriteLine(eur.ToString("F2"));
        }
    }
}
