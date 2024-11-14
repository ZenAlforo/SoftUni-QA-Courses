namespace _7._Number_Processor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Inc")
                {
                    num++;
                    command = Console.ReadLine();
                } else if (command == "Dec")
                {
                    num--;
                    command = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(num);
        }
    }
}
