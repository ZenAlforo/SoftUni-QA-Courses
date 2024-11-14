namespace _5._Guess_the_password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var password = Console.ReadLine();

            if (password == "s3cr3t!")
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
