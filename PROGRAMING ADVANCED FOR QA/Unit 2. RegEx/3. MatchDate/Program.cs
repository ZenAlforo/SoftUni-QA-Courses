using System.Text.RegularExpressions;

namespace _3._MatchDate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textToTest = Console.ReadLine();

            // named capturing groups and back reference for the separator
            string regEx = @"(?<day>\d{2})(?<separator>[.|\-|\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4})";

            MatchCollection matched = Regex.Matches(textToTest, regEx);

            foreach (Match match in matched)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
