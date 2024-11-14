namespace _3._Biggest_of_5_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());
            int fifthNum = int.Parse(Console.ReadLine());

            int biggestNum;

            if (firstNum >= secondNum && firstNum >= thirdNum && firstNum >= fourthNum && firstNum >= fifthNum)
            {
                biggestNum = firstNum;
            } else if (firstNum <= secondNum && secondNum >= thirdNum && secondNum >= fourthNum && secondNum >= fifthNum)
            {
                biggestNum = secondNum;
            }
            else if (firstNum <= thirdNum && secondNum <= thirdNum && thirdNum >= fourthNum && thirdNum >= fifthNum)
            {
                biggestNum = thirdNum;
            } else if (firstNum <= fourthNum && secondNum <= fourthNum && fourthNum >= thirdNum &&
                       fourthNum >= fifthNum)
            {
                biggestNum = fourthNum;
            }
            else
            {
                biggestNum = fifthNum;
            }

            Console.WriteLine(biggestNum);
        }
    }
}
