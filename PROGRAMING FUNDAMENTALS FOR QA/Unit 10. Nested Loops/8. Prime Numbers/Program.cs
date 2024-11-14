namespace _8._Prime_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            bool isPrime = true;

            for (int number = start; number <= end; number++)
            {
                int count = 0;

                for (int divisor = 1; divisor <= number; divisor++)
                {
                    if (number % divisor == 0)
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}