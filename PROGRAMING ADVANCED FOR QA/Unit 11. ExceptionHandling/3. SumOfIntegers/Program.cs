namespace _3._SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();

            int sum = 0;

            foreach (string element in elements)
            {
                try
                {
                    int currentNumber = int.Parse(element);
                    sum += currentNumber;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
