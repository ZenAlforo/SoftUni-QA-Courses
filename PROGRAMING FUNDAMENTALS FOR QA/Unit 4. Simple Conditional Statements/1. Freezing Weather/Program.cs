namespace _1._Freezing_Weather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());

            if (degrees <= 0)
            {
                Console.WriteLine("Freezing weather!");
            }
        }
    }
}
