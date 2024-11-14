namespace _4._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Console.WriteLine(FindDifferenceBetweenEvenSumAndOddSum(myArray));

            static int FindDifferenceBetweenEvenSumAndOddSum(int[] myArray)
            {
                int evenSum = 0;
                int oddSum = 0;

                foreach (var number in myArray)
                {
                    if (number % 2 == 0)
                    {
                        evenSum += number;
                    }
                    else
                    {
                        oddSum += number;
                    }
                }

                return evenSum - oddSum;

            }
        }
    }
}
