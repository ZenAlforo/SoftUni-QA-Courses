namespace _1._Study_Time_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;


            for (int i = 1; i <= number; i++)
            {
                int durationInMinutes = int.Parse(Console.ReadLine());
                
                sum += durationInMinutes;

                Console.WriteLine(sum);

            }

            if (number <= 0)
            {
                Console.WriteLine("0");
            }
        }
    }
}
