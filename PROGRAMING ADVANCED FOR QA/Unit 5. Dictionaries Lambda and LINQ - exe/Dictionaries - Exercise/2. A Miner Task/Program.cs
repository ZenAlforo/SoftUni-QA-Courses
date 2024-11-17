namespace _2._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> metals = new Dictionary<string, int>();

            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!metals.ContainsKey(input))
                {
                    metals.Add(input, quantity);
                }
                else
                {
                    metals[input] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, int> keyValuePair in metals)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
