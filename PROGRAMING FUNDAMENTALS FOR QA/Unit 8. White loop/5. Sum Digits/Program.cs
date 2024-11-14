namespace _5._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int result = 0;

            while (num > 0)
            {
                result += num % 10;
                num = num / 10;
            }

            Console.WriteLine(result);
        }
    }
}
