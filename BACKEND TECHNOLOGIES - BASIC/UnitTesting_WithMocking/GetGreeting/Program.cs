namespace GetGreeting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaration of greetingsProvider variable that works with GreetingsProvider when passing to it the System Time
            GreetingProvider greetingProvider = new GreetingProvider(new SystemTimeProvider());
            // Taking the resulting message from the call of the greetingProvider
            string greeting = greetingProvider.GetGreeting();
            Console.WriteLine(greeting);
        }
    }

}