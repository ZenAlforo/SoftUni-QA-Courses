namespace _4._Vowel_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int result = 0;

            for (int x = 0; x < n; x++)
            {
                char vowel = char.Parse(Console.ReadLine());

                switch (vowel)
                {
                    case 'a': result += 1; break;
                    case 'e': result += 2; break;
                    case 'i': result += 3; break;
                    case 'o': result += 4; break;
                    case 'u': result += 5; break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
