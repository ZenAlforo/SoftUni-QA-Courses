using System.Collections.Specialized;
using System.ComponentModel.Design;

namespace _1._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(x => double.Parse(x)).ToArray();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts[number] = 1;
                }
            }

            foreach (KeyValuePair<double, int> pair in counts)
            {
                double number = pair.Key;
                int occurances = pair.Value;

                Console.WriteLine($"{number} -> {occurances}");
            }
        }
    }
}
