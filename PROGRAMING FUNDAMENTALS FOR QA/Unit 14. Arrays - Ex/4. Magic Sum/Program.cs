namespace _4._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int controlNumber = int.Parse(Console.ReadLine());


            for (int i = 0; i < firstArray.Length - 1; i++)
            {
                for (int j = i + 1; j < firstArray.Length; j++)
                {
                    if (firstArray[i] + firstArray[j] == controlNumber)
                    {
                        Console.WriteLine(firstArray[i] + " " + firstArray[j]);
                    }
                }
            }
        }
    }
}
