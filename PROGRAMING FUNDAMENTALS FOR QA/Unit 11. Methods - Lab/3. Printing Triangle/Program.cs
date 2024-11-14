namespace _3._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintTriangleUpperHalf(number);
            PrintTriangleBottom(number);

            static void PrintTriangleUpperHalf(int num)
            {
                for (int row = 1; row <= num; row++)
                {
                    for (int digit = 1; digit <= row; digit++)
                    {
                        Console.Write(digit + " ");
                    }

                    Console.WriteLine();
                }
            }

            static void PrintTriangleBottom(int num)
            {
                for (int row = num; row >= 1; row--)
                {
                    for (int digit = 1; digit < row; digit++)
                    {
                        Console.Write(digit + " ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
