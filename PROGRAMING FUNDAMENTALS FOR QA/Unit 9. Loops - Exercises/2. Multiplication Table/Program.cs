namespace _2._Multiplication_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse((Console.ReadLine()));

            for (int x = 1; x <= 10; x++)
            {
                Console.WriteLine($"{n} x {x} = {n * x}");
            }
        }
    }
}
