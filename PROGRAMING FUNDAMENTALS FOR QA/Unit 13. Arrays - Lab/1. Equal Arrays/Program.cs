namespace _1._Day_of_the_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());

            string[] weekdays = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            if (day >= 1 && day <= 7)
            {
                Console.WriteLine($"{weekdays[day-1]}");
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }


        }
    }
}
