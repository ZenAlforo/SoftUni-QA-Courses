namespace _4._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            CalculateRectangleArea(width, length);
            static void CalculateRectangleArea(int a, int b)
            {
                Console.WriteLine(a * b);
            }
        }
    }
}
