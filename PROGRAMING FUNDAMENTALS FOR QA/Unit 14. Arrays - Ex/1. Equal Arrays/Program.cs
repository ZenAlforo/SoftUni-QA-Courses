namespace _1._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            bool areEqual = firstArray.SequenceEqual(secondArray);

            if (areEqual)
            {
                Console.WriteLine("Arrays are identical.");
            }
            else
            {
                Console.WriteLine("Arrays are not identical.");

            }
        }
    }
}
