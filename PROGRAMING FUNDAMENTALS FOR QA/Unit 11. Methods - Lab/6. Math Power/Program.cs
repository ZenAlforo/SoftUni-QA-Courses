namespace _6._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int baseNumber = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            NumberOnPower(baseNumber, power);

            static void NumberOnPower(int number, int power)
            {
                Console.WriteLine(Math.Pow(number, power));
            }
        }
    }
}
