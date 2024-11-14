
namespace _4._Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floorCount = int.Parse(Console.ReadLine());
            int estatesCount = int.Parse(Console.ReadLine());
            string type = "";

            for (int floor = floorCount; floor >= 1; floor--)
            {
                for (int estate = 0; estate < estatesCount; estate++)
                {
                    if (floor == floorCount)
                    {
                        type = "L";
                    }
                    else if (floor % 2 != 0)
                    {
                        type = "A";
                    }
                    else
                    {
                        type = "O";
                    }
                    Console.Write($"{type}{floor}{estate} ");
                }
                Console.WriteLine();
            }
        }
    }
}
