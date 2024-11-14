namespace _7._Vowel_or_Consonant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());
            string message;

            switch (letter)
            {
                case 'A':
                case 'a':
                case 'E':
                case 'e':
                case 'I':
                case 'i':
                case 'O':
                case 'o':
                case 'U':
                case 'u':
                    message = "Vowel";
                    break;
                default:
                    message = "Consonant"
                    ; break;
            }

            Console.WriteLine(message);
        }
    }
}
