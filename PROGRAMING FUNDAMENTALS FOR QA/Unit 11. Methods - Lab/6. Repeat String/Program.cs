namespace _5._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int repeatCount = int.Parse(Console.ReadLine());
            RepeatString(text, repeatCount);

            static void RepeatString(string text, int count)
            {
                string result = "";
                for (int i = 1; i <= count; i++)
                {
                    result += text;
                }

                Console.WriteLine(result);
            }
        }
    }
}
