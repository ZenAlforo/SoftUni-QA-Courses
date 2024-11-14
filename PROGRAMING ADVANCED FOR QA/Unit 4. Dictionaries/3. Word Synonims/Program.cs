using System.Security.Cryptography;

namespace _3._Word_Synonims
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordSynonyms = new Dictionary<string, List<string>>();

            int countWords = int.Parse(Console.ReadLine());

            for (int i = 0; i < countWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (wordSynonyms.ContainsKey(word))
                {
                    wordSynonyms[word].Add(synonym);
                } else
                {
                    wordSynonyms[word] = new List<string>() {synonym};
                }

            }


            foreach (string key in wordSynonyms.Keys)
            {
                Console.WriteLine($"{key} - {string.Join(", ", wordSynonyms[key])}");
            }
        }
    }
}
