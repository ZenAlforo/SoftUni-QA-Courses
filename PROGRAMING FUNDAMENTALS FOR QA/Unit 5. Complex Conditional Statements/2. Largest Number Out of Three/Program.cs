namespace _2._Largest_Number_Out_of_Three
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            if (firstNum > secondNum && secondNum > thirdNum)
            {
                Console.WriteLine(firstNum);
            } else if (secondNum > thirdNum && thirdNum > firstNum)
            {
                Console.WriteLine(secondNum);
            }
            else
            {
                Console.WriteLine(thirdNum);

            }
        }

    }
}
