namespace _9._Sum_seconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstAthleteTime = int.Parse(Console.ReadLine());
            int secondAthleteTime = int.Parse(Console.ReadLine());
            int thirdAthleteTime = int.Parse(Console.ReadLine());

            int totalTimeSeconds = firstAthleteTime + secondAthleteTime + thirdAthleteTime;

            int minutes = totalTimeSeconds / 60;
            int seconds = totalTimeSeconds % 60;

            Console.WriteLine($"{minutes}:{seconds:D2}");
            
        }
    }
}
