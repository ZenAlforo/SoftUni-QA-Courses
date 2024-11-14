namespace _7._Some_of_Digits_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                int currentNumber = int.Parse(input);
                int sum = 0;

                while (currentNumber > 0)
                {
                    int currentDigit = currentNumber % 10;
                    sum += currentDigit;
                    currentNumber = currentNumber / 10;
                }

                Console.WriteLine($"Sum of digits = {sum}");
                input = Console.ReadLine();

                if (input == "End")
                {
                    Console.WriteLine("Goodbye");
                }
            }
        }
    }
}
