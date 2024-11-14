namespace _1._Foor_Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse((Console.ReadLine()));
            int p = int.Parse((Console.ReadLine()));

            int result = n;

            for (int x = 1; x < p; x++)
            {
                result *= n;
            }

            Console.WriteLine(result);
        }
    }
}
