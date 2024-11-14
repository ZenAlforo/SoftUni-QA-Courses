namespace _6._Special_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isSpecial = true;
            int temp = number;

            while (temp > 0)
            {
                int lastDigit = temp % 10;
                temp = temp / 10;

                if (number % lastDigit != 0)
                {
                    isSpecial = false;
                    break;
                }
            }

            if (isSpecial)
            {
                Console.WriteLine($"{number} is special");
            }
            else
            {
                Console.WriteLine($"{number} is not special");

            }
        }
    }
}
