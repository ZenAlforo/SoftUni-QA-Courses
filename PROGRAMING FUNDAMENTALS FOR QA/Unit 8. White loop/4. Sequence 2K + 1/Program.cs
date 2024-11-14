namespace _4._Sequence_2K___1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 1;
            int maxNum = int.Parse(Console.ReadLine());

            while (num <= maxNum)
            {
                Console.WriteLine(num);
                num = num * 2 + 1;
            }
        }
    }
}
