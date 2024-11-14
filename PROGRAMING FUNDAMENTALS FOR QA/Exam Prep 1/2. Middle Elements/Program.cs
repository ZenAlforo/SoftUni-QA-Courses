namespace _2._Middle_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int lenght = integers.Length;
            double leftMidNumber = integers[integers.Length/2 - 1];
            double rightMidNumber = integers[integers.Length/2];

            double average = (leftMidNumber + rightMidNumber) / 2;

            Console.WriteLine($"{average:F2}");
           
        }
    }
}
