namespace _2._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split().ToArray();

            string result = "";

            foreach (string s in strings)
            {

                int timesToRepeat = s.Length;
                result += string.Concat(Enumerable.Repeat(s, timesToRepeat));

            }

            Console.WriteLine(result);
        }
    }
}
