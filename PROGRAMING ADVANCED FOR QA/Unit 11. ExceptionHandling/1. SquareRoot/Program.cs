namespace _1._SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(number));
                }


            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("Invalid number.");
            } finally 
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
