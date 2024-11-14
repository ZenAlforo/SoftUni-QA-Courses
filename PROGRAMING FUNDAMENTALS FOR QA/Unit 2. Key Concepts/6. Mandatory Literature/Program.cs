namespace _6._Mandatory_Literature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesReadPerHour = int.Parse(Console.ReadLine());
            int daysDeadline = int.Parse(Console.ReadLine());

            int necessaryHoursPerBook = pages / pagesReadPerHour;
            int result = necessaryHoursPerBook / daysDeadline;

            Console.WriteLine(result);
        }
    }
}
