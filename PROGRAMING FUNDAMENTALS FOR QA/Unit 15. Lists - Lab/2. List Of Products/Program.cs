namespace _2._List_Of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int productCount = int.Parse(Console.ReadLine());

            List<string> goods = new List<string>();

            for (int i = 0; i < productCount; i++)
            {
                string product = Console.ReadLine();
                goods.Add(product);
            }

            goods.Sort();
            
            for (int i = 0; i < goods.Count; i++)
            {
                Console.WriteLine($"{i+1}.{goods[i]}");
            }
        }
    }
}
