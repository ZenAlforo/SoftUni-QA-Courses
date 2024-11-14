namespace _6._Customers_Info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string email = Console.ReadLine();
            Console.WriteLine($"Customer: {firstName} {lastName} ({email})");
        }
    }
}
