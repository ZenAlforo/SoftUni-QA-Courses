
namespace _3._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string[] commandLine = Console.ReadLine().Split(" ");

            while (commandLine[0] != "End")
            {
                string operation = commandLine[0];

                if (operation == "Add")
                {
                    int number = int.Parse(commandLine[1]);
                    numbers.Add(number);
                } else if (operation == "Insert")
                {
                    int number = int.Parse(commandLine[1]);
                    int index = int.Parse(commandLine[2]);

                    if (index > numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }

                }
                else if (operation == "Remove")
                {
                    int index = int.Parse(commandLine[1]);
                    if (index > numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                    
                } 
                else if (operation == "Shift")
                {
                    string direction = commandLine[1];
                    int countOfRotation = int.Parse(commandLine[2]);

                    if (direction == "left")
                    {
                        for (int i = 0; i < countOfRotation; i++)
                        {
                            int firstNum = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(firstNum);
                        }
                    } 
                    else if (direction == "right")
                    {
                        for (int i = 0; i < countOfRotation; i++)
                        {
                            int lastNum = numbers[numbers.Count-1];
                            numbers.RemoveAt(numbers.Count-1);
                            numbers.Insert(0, lastNum);
                        }
                    }
                }

                commandLine = Console.ReadLine().Split(" ");
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
