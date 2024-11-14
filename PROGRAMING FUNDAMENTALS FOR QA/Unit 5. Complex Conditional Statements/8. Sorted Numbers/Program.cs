namespace _8._Sorted_Numbers
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
                Console.WriteLine("Descending");
            } else if (firstNum < secondNum && secondNum < thirdNum)
            {
                Console.WriteLine("Ascending");

            }
            else
            {
                Console.WriteLine("Not sorted");

            }

        }
    }
}
