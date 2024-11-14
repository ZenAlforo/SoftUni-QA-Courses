namespace _2._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int commandIndex = 0; commandIndex < numberOfCommands; commandIndex++)
            {
                string[] commands = Console.ReadLine().Split().ToArray();
                string guestName = commands[0];
                string goingOrNot = commands[2];

                if (goingOrNot == "going!")
                {
                    if (guests.Contains(guestName))
                    {
                        Console.WriteLine($"{guestName} is already in the list!");
                    }
                    else
                    {
                        guests.Add(guestName);
                    }
                }
                else
                {
                    if (guests.Contains(guestName))
                    {
                        guests.Remove(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is not in the list!");

                    }
                }
                

            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
