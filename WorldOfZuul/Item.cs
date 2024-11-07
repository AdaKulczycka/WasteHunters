namespace WasteHunters
{
    public class Inventory{
        int sum = 0; 

        private Dictionary<string, int> items;
        public Inventory()
        {
            items = new Dictionary<string, int>();
        }

        public void AddItem(string itemName, int value)
        {
            items?.Add(itemName, value);
            sum += value;
        }

        public void RemoveItem()
        {
            items.Clear();
            
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
            Console.WriteLine($"(Total: {sum})");
            System.Console.WriteLine(sum);
        }

        public bool HasItem(string itemName)
        {
            return items.ContainsKey(itemName);
        }
    }
    /*private Dictionary<string, int> items;

        public Inventory()
        {
            items = new Dictionary<string, int>();
        }*/

    
}