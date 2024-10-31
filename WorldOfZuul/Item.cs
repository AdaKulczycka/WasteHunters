namespace WasteHunters{
    public class Inventory{
        int sum = 0; 

        private Dictionary<string, int>? items;
        public Inventory()
        {
            items = new Dictionary<string, int>();
        }

        public void AddItem(string itemName, int value)
        {
            items?.Add(itemName, value);
            sum += value;
        }

        public void ShowInventory()
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
                return;
            }

            Console.WriteLine("Items in your inventory:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.Key}: {item.Value} points");
            }
            System.Console.WriteLine(sum);
        }

    }
    /*private Dictionary<string, int> items;

        public Inventory()
        {
            items = new Dictionary<string, int>();
        }*/

    
}