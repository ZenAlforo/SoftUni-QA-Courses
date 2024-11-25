namespace _3.StoreBoxes
{
    internal class Program
    {
        static void Main()
        {
            List<Box> boxes = new List<Box>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] itemData = input.Split().ToArray();
                string serialNumber = itemData[0];
                string itemName = itemData[1];
                int quantity = int.Parse(itemData[2]);
                double price = double.Parse(itemData[3]);

                Item currentItem = new Item(itemName, price);
                Box currentBox = new Box(serialNumber, currentItem, quantity);

                boxes.Add(currentBox);

                input = Console.ReadLine();
            }

            foreach (Box box in boxes.OrderByDescending(box => box.PriceOfBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceOfBox:F2}");
            }
        }

        class Item
        {
            public Item(string name, double price)
            {
                Name = name;
                Price = price;
            }

            public string Name {  get; set; }
            public double Price { get; set; }
        }

        class Box
        {
            public Box(string serialNumber, Item item, int quantity)
            {
                SerialNumber = serialNumber;
                Item = item;
                Quantity = quantity;
            }

            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int Quantity { get; set; }
            public double PriceOfBox => Item.Price * Quantity;
            
        }
    }
}
