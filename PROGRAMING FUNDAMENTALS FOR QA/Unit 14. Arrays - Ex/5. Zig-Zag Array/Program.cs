namespace _5._Zig_Zag_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string firstArray = "";
            string secondArray = "";

            for (int i = 0; i < rows; i++)
            {
                int[] coupleNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstArray += coupleNumbers[0] + " "; 
                    secondArray += coupleNumbers[1] + " ";
                }
                else
                {
                    firstArray += coupleNumbers[1] + " ";
                    secondArray += coupleNumbers[0] + " ";
                }
                
            }

            Console.WriteLine(firstArray);
            Console.WriteLine(secondArray);
        }
    }
}
