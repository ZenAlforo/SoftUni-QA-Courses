namespace _5._Diggits__Letters_and_Others
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string letters = "";
            string digits = "";
            string others = "";
            foreach (char i in input)
            {
                if (char.IsLetter(i))
                {
                    letters += i;
                }
                else if (char.IsDigit(i))
                {
                    digits += i;
                }
                else
                {
                    others += i;
                }

            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
