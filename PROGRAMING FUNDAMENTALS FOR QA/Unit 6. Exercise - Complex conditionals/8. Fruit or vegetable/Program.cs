namespace _8._Fruit_or_vegetable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            if (product == "banana" || product == "apple" || product == "kiwi" || product == "cherry" ||
                product == "lemon")
            {
                Console.WriteLine("fruit");
            } else if (product == "cucumber" || product == "pepper" || product == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
