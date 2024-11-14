namespace _4._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string[] commandLine = Console.ReadLine().Split(" ");

            while (commandLine[0] != "end")
            {
                string operation = commandLine[0];

                int number = int.Parse(commandLine[1]);

                switch (operation)
                {
                    case "Add":
                        numbers.Add(number);
                        break;
                    case "Remove":
                        numbers.Remove(number);
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(number);
                        break;
                    case "Insert":
                        int index = int.Parse(commandLine[2]);
                        numbers.Insert(index, number);
                        break;

                }

                commandLine = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
