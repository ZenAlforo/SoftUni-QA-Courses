namespace _5._Number_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = int.Parse(Console.ReadLine());

            int number = 1;

            for (int row = 1; row <= maxNumber; row++)
            {
                for (int count = 1; count <= row; count++)
                {
                    if (maxNumber >= number)
                    {
                        Console.Write(number + " ");
                        number++;
                    }
                    else
                    {
                        break;
                    }
                    
                }

                Console.WriteLine();
            }
        }
    }
}
