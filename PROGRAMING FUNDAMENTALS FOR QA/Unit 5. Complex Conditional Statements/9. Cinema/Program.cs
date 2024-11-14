namespace _9._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int seatsPerRow = int.Parse(Console.ReadLine());

            double totalPrice;

            if (movie == "Premiere")
            {
                totalPrice = rows * seatsPerRow * 12.00;
            } 
            else if (movie == "Normal")
            {
                totalPrice = rows * seatsPerRow * 7.50;
            }
            else
            {
                totalPrice = rows * seatsPerRow * 5.00;

            }

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
