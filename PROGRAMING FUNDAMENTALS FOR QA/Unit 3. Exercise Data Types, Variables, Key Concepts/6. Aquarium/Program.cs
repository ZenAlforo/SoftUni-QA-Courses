namespace _6._Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthCm = int.Parse(Console.ReadLine());
            int widthCm = int.Parse(Console.ReadLine());
            int heightCm = int.Parse(Console.ReadLine());
            double percentageOff = double.Parse(Console.ReadLine());

            double aquariumVolumeInCubSm = lengthCm * widthCm * heightCm;
            double waterNeededInLiters = (aquariumVolumeInCubSm - (aquariumVolumeInCubSm * (percentageOff / 100))) / 1000;

            Console.WriteLine(waterNeededInLiters.ToString("F2"));
        }
    }
}
