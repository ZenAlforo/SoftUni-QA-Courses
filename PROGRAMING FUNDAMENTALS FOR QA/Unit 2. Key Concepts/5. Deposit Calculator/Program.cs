namespace _5._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depositedAmount = double.Parse(Console.ReadLine());
            int termInMonths = int.Parse(Console.ReadLine());
            double interestAnually = double.Parse(Console.ReadLine()) / 100;

            double totalAmount = depositedAmount + termInMonths * (depositedAmount * interestAnually) / 12;
            Console.WriteLine(totalAmount);
        }
    }
}
