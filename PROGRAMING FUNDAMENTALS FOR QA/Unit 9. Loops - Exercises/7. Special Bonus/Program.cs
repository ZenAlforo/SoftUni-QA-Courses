namespace _7._Special_Bonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stopNumber = int.Parse(Console.ReadLine());
            bool isStopNumberFound = false;
            double previousNumber = 0;

            while (isStopNumberFound == false)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber == stopNumber)
                {
                    previousNumber += previousNumber * 0.2;
                    isStopNumberFound = true;
                    break;
                }

                previousNumber = currentNumber;
            }

            Console.WriteLine(previousNumber);
        }
    }
}
