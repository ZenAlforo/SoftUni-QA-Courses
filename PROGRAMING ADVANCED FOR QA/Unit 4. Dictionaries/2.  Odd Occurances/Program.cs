namespace _2.__Odd_Occurances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();
            Dictionary<string, int> wordsData = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordsData.ContainsKey(word))
                {
                    wordsData[word]++;
                }
                else
                {
                    wordsData.Add(word, 1);
                }
            }

            foreach (KeyValuePair<string, int> pair in wordsData)
            {
                if (pair.Value % 2 != 0) {
                    Console.Write(pair.Key + " ");
                }
            }
        }
    }
}
