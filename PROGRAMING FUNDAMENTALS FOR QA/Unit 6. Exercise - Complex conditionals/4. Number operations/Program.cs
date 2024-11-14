using System.Linq.Expressions;

namespace _4._Number_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            double result;

            if (operation == "+")
            {
                result = num1 + num2;
            } else if (operation == "-")
            {
                result = num1 - num2;
            } else if (operation == "*")
            {
                result = num1 * num2;
            }
            else
            {
                result = num1 / num2;
            }

            switch (operation)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 + num2; break;
                case "*": result = num1 + num2; break;
                case "/": result = num1 + num2; break;
            }


            Console.WriteLine($"{num1} {operation} {num2} = {result:F2}");

        }
    }
}
