namespace _2._MinMax_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int number = int.Parse(Console.ReadLine());

            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;

            for (int i = 0; i < number; i++)
            {
                int curNumber = myArray[i];
                
                if (curNumber < minNumber)
                {
                    minNumber = curNumber;
                }

                if (curNumber > maxNumber)
                {
                    maxNumber = curNumber;
                }

            }

            Console.WriteLine(maxNumber);
            Console.WriteLine(minNumber);
        }
    }
}
