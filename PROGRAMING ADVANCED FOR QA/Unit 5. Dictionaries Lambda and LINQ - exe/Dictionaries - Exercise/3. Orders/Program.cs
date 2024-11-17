namespace _3._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, double[]> shoppingList = new Dictionary<string, double[]>();

            while (input != "buy")
            {
                string[] productData = input.Split().ToArray();
                string product = productData[0];
                double price = double.Parse(productData[1]);
                int quantity = int.Parse(productData[2]);

                double[] quantityAndPrice = { price, quantity };

                if (!shoppingList.ContainsKey(product))
                {
                    shoppingList.Add(product, quantityAndPrice);
                }
                else
                {
                    shoppingList[product][0] = price;
                    shoppingList[product][1] += quantity;
                }

                input = Console.ReadLine();

            }

            foreach (KeyValuePair<string, double[]> kvp in shoppingList)
            {
                string product = kvp.Key;
                double price = kvp.Value[0];
                double quantity = kvp.Value[1];

                Console.WriteLine($"{product} -> {price * quantity:F2}");
            }
        }
    }
}
