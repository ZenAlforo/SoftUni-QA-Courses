namespace _1._Count_Chars_in_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char c in input)
            {
                if (c != ' ')
                {
                    if (!dict.ContainsKey(c))
                    {
                        dict.Add(c, 1);
                    }
                    else
                    {
                        dict[c]++;
                    }
                }
            }

            foreach (KeyValuePair<char, int> kvp in dict)
            {
                char currentChar = kvp.Key;
                int occurrences = kvp.Value;

                Console.WriteLine($"{currentChar} -> {occurrences}");
            }
        }
    }
}
