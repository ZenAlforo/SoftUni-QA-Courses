namespace _3._Reverse_an_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int[] myArray = new int[count];
            int[] myReversedArray = new int[count];

            for (int i = 0; i < count; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
            }

            for (int i = myArray.Length - 1; i >= 0; i--)
            {
                Console.Write(myArray[i] + " ");
            }
        }
    }
}
