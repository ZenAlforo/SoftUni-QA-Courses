namespace _2._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine(FindFactorialDivision(num1, num2));

            static double FindFactorialDivision(int a, int b)
            {
                int factorialA = 1;
                int factorialB = 1;

                for (int i = 1; i <= a; i++)
                {
                    factorialA *= i;
                }

                for (int i = 1; i <= b; i++)
                {
                    factorialB*= i;
                }

                double result = factorialA / factorialB;
                return result;
            }
        }
    }
}
