namespace GetGreeting
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetingProvider greetingProvider = new GreetingProvider(new FakeTimeProvider(new DateTime(2000, 02, 02, 23, 00, 00)));
            string greeting = greetingProvider.GetGreeting();
            Console.WriteLine(greeting);
        }
    }

}