namespace _1._Sum_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int factorialSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int number = int.Parse(input[i].ToString());
                
                if (number % 2 == 0)
                {
                    int factorial = 1;

                    if (number % 2 == 0)
                    {
                        int currentNum = number;
                        while (currentNum > 1)
                        {
                            factorial *= currentNum;
                            currentNum--;
                        }
                    }
                    
                    factorialSum += factorial;
                }
            }

            Console.WriteLine(factorialSum);
        }
    }
}
