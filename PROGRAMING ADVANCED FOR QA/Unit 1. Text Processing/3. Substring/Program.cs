namespace _3._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringToRemove = Console.ReadLine();
            string text = Console.ReadLine();

            string result = string.Empty;

            while (text.Contains(stringToRemove))
            {
                result = text.Replace(stringToRemove, "");
                text = result;
            }

            Console.WriteLine(result);
        }
    }
}
