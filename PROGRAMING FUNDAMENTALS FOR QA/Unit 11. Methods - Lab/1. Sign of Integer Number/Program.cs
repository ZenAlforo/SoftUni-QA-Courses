namespace _1._Sign_of_Integer_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintSign(number);

            static void PrintSign(int num)
            {
                if (num == 0)
                {
                    Console.WriteLine($"The number {num} is zero.");
                } 
                else if (num < 0)
                {
                    Console.WriteLine($"The number {num} is negative.");
                }
                else
                {
                    Console.WriteLine($"The number {num} is positive.");
                }
            }
        }
    }
}
