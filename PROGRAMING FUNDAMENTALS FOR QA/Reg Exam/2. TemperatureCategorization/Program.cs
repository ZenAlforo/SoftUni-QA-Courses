namespace _2._TemperatureCategorization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] temperatures = Console.ReadLine().Split().Select(int.Parse).ToArray();

            double avgTemp = temperatures.Average();

            /*int lessThanAvgCount = temperatures.Count(temp =>  temp < avgTemp);
            int greaterOrEqualThanAvgCount = temperatures.Count(temp => temp >= avgTemp);

            int[] lessThanAvg = new int[lessThanAvgCount];
            int[] equalOrGreaterThanAvg = new int[greaterOrEqualThanAvgCount];

            int lessIndex = 0;
            int greaterIndex = 0;*/

            List<int> lessThanAvg = new();
            List<int> eqOrGreaterThanAvg = new();

            for (int i = 0; i < temperatures.Length; i++)
            {
                int currentTemp = temperatures[i];
                if (currentTemp < avgTemp)
                {
                    lessThanAvg.Add(currentTemp);
                } else
                {
                    eqOrGreaterThanAvg.Add(currentTemp);
                }
            }

            foreach (int temp1 in lessThanAvg)
            {
                Console.Write(temp1 + " ");
            }

            Console.WriteLine();

            foreach (int temp2 in eqOrGreaterThanAvg)
            {
                Console.Write(temp2 + " ");
            }

        }
    }
}
