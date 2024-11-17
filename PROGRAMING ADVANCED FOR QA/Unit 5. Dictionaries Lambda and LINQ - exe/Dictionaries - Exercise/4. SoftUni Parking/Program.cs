namespace _4._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int movements = int.Parse(Console.ReadLine());

            Dictionary<string, string> cars = new Dictionary<string, string>();

            for (int i = 1; i <= movements; i++)
            {
                string[] commands = Console.ReadLine().Split().ToArray();
                string userName = commands[1];
                

                if (commands.Length < 3)
                {
                    if (cars.ContainsKey(userName))
                    {
                        cars.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    } else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                } else
                {
                    if (cars.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {cars[userName]}");
                    }
                    else
                    {
                        string plateNumber = commands[2];
                        cars.Add(userName, plateNumber);
                        Console.WriteLine($"{userName} registered {plateNumber} successfully");
                    }
                }

            }

            foreach (KeyValuePair<string, string> pair in cars)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}"); 
            }
        }
    }
}
