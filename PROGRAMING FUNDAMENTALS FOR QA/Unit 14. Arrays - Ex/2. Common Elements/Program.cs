namespace _2._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string commonElements = "";

            for (int i = 0; i < firstArray.Length; i++)
            {
                for (int j = 0; j < secondArray.Length; j++)
                {
                    if (firstArray[i] == secondArray[j])
                    {
                        commonElements += firstArray[i] + " ";
                    }
                }
            }

            Console.WriteLine(commonElements);

        }
    }
}
