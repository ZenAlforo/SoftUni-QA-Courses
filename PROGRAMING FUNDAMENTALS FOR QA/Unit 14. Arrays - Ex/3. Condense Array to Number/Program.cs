namespace _3._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            while (firstArray.Length > 1)
            {
                int[] condensedNumber = new int[firstArray.Length - 1];

                for (int i = 0; i < firstArray.Length - 1; i++)
                {

                    condensedNumber[i] = firstArray[i] + firstArray[i + 1];
                }

                firstArray = condensedNumber;
            }

            Console.WriteLine(firstArray[0]);
        }
    }
}
