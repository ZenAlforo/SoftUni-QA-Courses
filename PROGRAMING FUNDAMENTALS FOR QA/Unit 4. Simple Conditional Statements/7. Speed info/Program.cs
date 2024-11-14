namespace _6._Boiling_water
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());
            if (speed > 30)
            {
                Console.WriteLine("Fast");
            }
            else
            {
                Console.WriteLine("Slow");

            }
        }
    }
}