namespace _6._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rotations; i++)
            {

                int firstElement = myArray[0];
                for (int j = 1; j < myArray.Length; j++)
                {
                    myArray[j - 1] = myArray[j];
                }

                myArray[myArray.Length - 1] = firstElement;

            }

            foreach (var VARIABLE in myArray)
            {
                Console.Write(VARIABLE + " ");
            }
        }
    }
}
