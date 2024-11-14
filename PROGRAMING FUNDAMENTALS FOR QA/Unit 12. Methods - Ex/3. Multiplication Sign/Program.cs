namespace _3._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(FindMultiplicationSign(num1, num2, num3));

            static string FindMultiplicationSign(int num1, int num2, int num3)
            {
                string result = "";

                if (num1 < 0 && num2 < 0 && num3 < 0 
                    || num1 < 0 && num2 > 0 && num3 > 0 
                    || num1 > 0 && num2 < 0 && num3 > 0 
                    || num1 > 0 && num2 > 0 && num3 < 0)
                {
                    result = "negative";
                } 
                else if (num1 > 0 && num2 > 0 && num3 > 0
                         || num1 < 0 && num2 < 0 && num3 > 0
                         || num1 > 0 && num2 < 0 && num3 < 0
                         || num1 < 0 && num2 > 0 && num3 < 0)
                {
                    result = "positive";
                }
                else
                {
                    result = "zero";
                }

                return result;
            }
        }
    }
}
