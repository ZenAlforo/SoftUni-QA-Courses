using System.Security;

namespace _1._Magic_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                int sumDigits = 0;
                int currentNumber = i;
                bool areAllDigitsPrime = true;

                while (currentNumber > 0)
                {
                    int lastDigit = currentNumber % 10;
                    sumDigits += lastDigit;

                    if (!IsPrime(lastDigit))
                    {
                        areAllDigitsPrime = false;
                        break;
                    }

                    currentNumber = currentNumber / 10;
                }

                if (areAllDigitsPrime && sumDigits % 2 == 0)
                {
                    list.Add(i);
                }
            }

            if (list.Count == 0)
            {
                Console.WriteLine("no");
            }
            else
            {

                foreach (int digit in list)
                {
                    Console.Write(digit + " ");
                }

            }

            static bool IsPrime(int number)
            {
                if (number <= 1)
                {
                    return false;
                }

                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
