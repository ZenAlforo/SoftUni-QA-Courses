namespace _8._Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string currentCommand = Console.ReadLine();

            double balance = 0;

            while (currentCommand != "End")
            {
                double currentAmountOperation = double.Parse(currentCommand);
                if (currentAmountOperation > 0)
                {
                    Console.WriteLine($"Increase: {currentAmountOperation:f2}");
                }
                else
                {
                    Console.WriteLine($"Decrease: {Math.Abs(currentAmountOperation):f2}");
                }

                currentCommand = Console.ReadLine();
                balance += currentAmountOperation;
            }

            Console.WriteLine($"Balance: {balance:f2}");
        }
    }
}
