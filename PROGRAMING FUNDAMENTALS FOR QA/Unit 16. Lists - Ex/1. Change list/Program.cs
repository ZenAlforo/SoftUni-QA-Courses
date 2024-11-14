namespace _1._Change_list
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            string[] commandLine = Console.ReadLine().Split();

            while (commandLine[0] != "end")
            {
                string command = commandLine[0];
                if (command == "Delete")
                {
                    int numToDelete = int.Parse(commandLine[1]);
                    myList.RemoveAll(x => x == numToDelete);
                }
                else if (command == "Insert")
                {
                    int numToInsert = int.Parse(commandLine[1]);
                    int index = int.Parse(commandLine[2]);
                    myList.Insert(index, numToInsert);
                }

                commandLine = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", myList));
        }
    }
}