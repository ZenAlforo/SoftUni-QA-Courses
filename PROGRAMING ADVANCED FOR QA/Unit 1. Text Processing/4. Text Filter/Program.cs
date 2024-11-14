namespace _4._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string bannedWords = Console.ReadLine();
            string text = Console.ReadLine();

            string[] wordsToBan = bannedWords.Split(", ").ToArray();

            foreach (string word in wordsToBan)
            {
                if (text.Contains(word)) {
                    text = text.Replace(word, new string('*', word.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
