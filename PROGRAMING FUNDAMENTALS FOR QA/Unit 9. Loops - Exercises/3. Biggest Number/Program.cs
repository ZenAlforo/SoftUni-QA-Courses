namespace _3._Biggest_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int biggestNum = n;

            for (int x = 0; x < n; x++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number > biggestNum)
                {
                    biggestNum = number;
                }
            }

            Console.WriteLine(biggestNum);
        }
    }
}
