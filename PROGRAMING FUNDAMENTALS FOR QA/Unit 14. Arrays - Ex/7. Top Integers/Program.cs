namespace _7._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            

            for (int i = 0; i < myArray.Length - 1; i++)
            {
                bool isGreater = true;

                for (int j = i + 1; j < myArray.Length; j++)
                {
                    if (myArray[i] <= myArray[j])
                    {
                        isGreater = false;
                        break;
                    }
                }

                if (isGreater)
                {
                    Console.Write(myArray[i] + " ");
                }
            }

            Console.Write(myArray[myArray.Length - 1]);
        }
    }
}
