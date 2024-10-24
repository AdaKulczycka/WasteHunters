namespace WorldOfZuul{
    public class Inventory{
        private Dictionary<string, int>? items;
        public Inventory()
        {
            items = new Dictionary<string, int>();
        }

        public void AddItem(string itemName, int value)
        {
            items.Add(itemName, value);
        }
    }
    /*private Dictionary<string, int> items;

        public Inventory()
        {
            items = new Dictionary<string, int>();
        }*/

    
}