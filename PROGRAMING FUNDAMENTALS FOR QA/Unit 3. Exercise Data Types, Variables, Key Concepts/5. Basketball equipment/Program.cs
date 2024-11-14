namespace _5._Basketball_equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int trainingFeeEarly = int.Parse(Console.ReadLine());

            double sneakersCost = trainingFeeEarly - trainingFeeEarly * 0.4;
            double uniformCost = sneakersCost - sneakersCost * 0.2;
            double ballCost = uniformCost / 4;
            double accessoriesCost = ballCost / 5;

            double totalCost = trainingFeeEarly + sneakersCost + uniformCost + ballCost + accessoriesCost;
            Console.WriteLine(totalCost);

        }
    }
}
