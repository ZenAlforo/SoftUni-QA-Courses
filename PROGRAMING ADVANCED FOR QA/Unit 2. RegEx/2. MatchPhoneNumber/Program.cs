using System.Text.RegularExpressions;

namespace _2._MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textToTest = Console.ReadLine();

            string regEx = @"\+359([ | -])2\1\d{3}\1\d{4}\b";

            MatchCollection matched = Regex.Matches(textToTest, regEx);

            Console.Write(string.Join(", ", matched));

        }
    }
}
