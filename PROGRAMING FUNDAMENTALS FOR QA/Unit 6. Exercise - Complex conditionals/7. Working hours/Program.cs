namespace _7._Working_hours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            switch (day)
            {
                case "Sunday":
                    Console.WriteLine("closed");
                    break;
                default:
                    if (hour < 10 || hour > 18)
                    {
                        Console.WriteLine("closed");
                    }
                    else
                    {
                        Console.WriteLine("open");
                    }
                    break;
            }
        }
    }
}
