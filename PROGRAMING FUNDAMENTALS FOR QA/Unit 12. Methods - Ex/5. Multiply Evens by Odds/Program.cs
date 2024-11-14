namespace _5._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            Console.WriteLine(GetMultipleOfEvenAndOdds(number));

            static int GetMultipleOfEvenAndOdds(int num)
            {
                int result = GetSumOfEvenDigits(num) * GetSumOfOddDigits(num);
                return result;
            }

            static int GetSumOfEvenDigits(int num)
            {
                int CurrentNumber = 1;
                int EvenSum = 0;

                while (CurrentNumber != 0)
                {
                    CurrentNumber = num % 10;
                    num = num / 10;

                    if (CurrentNumber % 2 == 0)
                    {
                        EvenSum += CurrentNumber;
                    }
                }

                return EvenSum;
            }

            static int GetSumOfOddDigits(int num)
            {
                int CurrentNumber = 1;
                int OddSum = 0;

                while (CurrentNumber != 0)
                {
                    CurrentNumber = num % 10;
                    num = num / 10;

                    if (CurrentNumber % 2 != 0)
                    {
                        OddSum += CurrentNumber;
                    }
                }

                return OddSum;
            }
        }
    }
}
