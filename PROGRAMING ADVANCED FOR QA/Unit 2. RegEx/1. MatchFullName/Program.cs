using System.Text.RegularExpressions;

namespace _1._MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string regEx = @"\b[A-Z][a-z]+ \b[A-Z][a-z]+";

            Regex reg = new Regex(regEx);
            MatchCollection matches = reg.Matches(text);

            // alternatively do the above 2 rows in 1 line
            // MatchCollection matches = Regex.Matches(text, regEx);

            foreach (Match match in matches)
            {
                Console.Write(match + " ");
            }

        }
    }
}
