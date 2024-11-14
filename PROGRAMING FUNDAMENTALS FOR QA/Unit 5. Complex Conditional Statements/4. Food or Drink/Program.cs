namespace _4._Food_or_Drink
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            if (product == "curry" || product == "noodles" || product == "spaghetti" || product == "bread" || product == "sushi")
            {
                Console.WriteLine("food");
            } else if (product == "tea" || product == "water" || product == "coffee" || product == "juice")
            {
                Console.WriteLine("drink");

            }
            else
            {
                Console.WriteLine("unknown");

            }
        }
    }
}
