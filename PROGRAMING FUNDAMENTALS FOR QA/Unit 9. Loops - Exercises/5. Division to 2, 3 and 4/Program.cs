using System.Security.Cryptography.X509Certificates;

namespace _5._Division_to_2__3_and_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int divisibleByTwo = 0;
            int divisibleByThree = 0;
            int divisibleByFour = 0;

            for (int x = 0; x < n; x++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    divisibleByTwo++;
                } 
                if (number % 3 == 0)
                {
                    divisibleByThree++;
                } 
                if (number % 4 == 0)
                {
                    divisibleByFour++;
                }
            }

            double divByTwoShare = (double)divisibleByTwo / n * 100;
            double divByThreeShare = 1.0 * divisibleByThree / n * 100;
            double divByFourShare = (double)divisibleByFour / n * 100;

            Console.WriteLine($"{divByTwoShare:f2}%");
            Console.WriteLine($"{divByThreeShare:f2}%");
            Console.WriteLine($"{divByFourShare:f2}%");
        }
    }
}
