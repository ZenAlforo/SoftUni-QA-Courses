namespace _1._Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();

            while (initialString != "end")
            {

                char[] reversedArray = initialString.Reverse().ToArray();
                string reversedString = new string(reversedArray);

                Console.WriteLine($"{initialString} = {reversedString}");

                initialString = Console.ReadLine();

            }
        }
    }
}
