namespace _8._Ticket_Price
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            int sideC = int.Parse(Console.ReadLine());

            if (sideA + sideB > sideC && sideC + sideB > sideA && sideA + sideC > sideB)
            {
                Console.WriteLine("Valid Triangle");

            }
            else
            {
                Console.WriteLine("Invalid Triangle");

            }
        }
    }
}