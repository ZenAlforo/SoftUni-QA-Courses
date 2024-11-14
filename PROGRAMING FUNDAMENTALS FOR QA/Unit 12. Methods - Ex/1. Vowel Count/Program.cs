namespace _1._Vowel_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(FindVowelCount(text));
            static int FindVowelCount(string text)
            {
                int count = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == 'a' 
                        || text[i] == 'e' 
                        || text[i] == 'i' 
                        || text[i] == 'o' 
                        || text[i] == 'u' 
                        || text[i] == 'y'
                        || text[i] == 'A'
                        || text[i] == 'E'
                        || text[i] == 'I'
                        || text[i] == 'O'
                        || text[i] == 'U'
                        || text[i] == 'Y')
                    {
                        count++;
                    }
                }

                return count;
            }
        }
    }
}
