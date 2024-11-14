namespace _2._FourOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double sum = firstNumber + secondNumber;
            double diff = firstNumber - secondNumber;
            double product = firstNumber * secondNumber;
            double quotient = firstNumber / secondNumber;

            Console.WriteLine($"{firstNumber.ToString("F2")} + {secondNumber.ToString("F2")} = {sum.ToString("F2")}");
            Console.WriteLine($"{firstNumber.ToString("F2")} - {secondNumber.ToString("F2")} = {diff.ToString("F2")}");
            Console.WriteLine($"{firstNumber.ToString("F2")} * {secondNumber.ToString("F2")} = {product.ToString("F2")}");
            Console.WriteLine($"{firstNumber.ToString("F2")} / {secondNumber.ToString("F2")} = {quotient.ToString("F2")}");
        }
    }
}
