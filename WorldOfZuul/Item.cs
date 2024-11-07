<<<<<<< HEAD
namespace WasteHunters
{
    public class Inventory{
        int sum = 0; 

        private Dictionary<string, int> items;
=======
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WasteHunters{
    public class Inventory{
        int sum = 0; 

        private Dictionary<string, Dictionary<string, int>> items;
>>>>>>> 4d1d27e33b6950a3be3d215483116b03e80d9c3c
        public Inventory()
        {
             items = new Dictionary<string, Dictionary<string, int>>()
            {
                { "plastic", new Dictionary<string, int>() },
                { "paper", new Dictionary<string, int>() },
                { "glass", new Dictionary<string, int>() }
            };
        }

        public void AddItemToPlastic(string itemName, int value)
        {
            AddItemToCategory("plastic", itemName, value);
        }

<<<<<<< HEAD
        public void RemoveItem()
        {
            items.Clear();
            
        }

=======
        public void AddItemToPaper(string itemName, int value)
        {
            AddItemToCategory("paper", itemName, value);
        }

        public void AddItemToGlass(string itemName, int value)
        {
            AddItemToCategory("glass", itemName, value);
        }

        // Generic method to add items to any category
        private void AddItemToCategory(string category, string itemName, int value)
        {
            items[category][itemName] = value; // Add new item to category
        }

        // Method to display the contents of each category
>>>>>>> 4d1d27e33b6950a3be3d215483116b03e80d9c3c
        public void ShowInventory()
        {
            Console.WriteLine("Inventory:");

            foreach (var category in items.Keys)
            {
                Console.WriteLine($"\n{category.ToUpper()}:");
                if (items[category].Count == 0)
                {
                    Console.WriteLine("  (Empty)");
                }
                else
                {
                    foreach (var item in items[category])
                    {
                        Console.WriteLine($"  - {item.Key}: {item.Value} points");
                    }
                }
            }
        }
<<<<<<< HEAD

        public bool HasItem(string itemName)
        {
            return items.ContainsKey(itemName);
        }
    }
    /*private Dictionary<string, int> items;

        public Inventory()
=======
        public void CountPoints()
>>>>>>> 4d1d27e33b6950a3be3d215483116b03e80d9c3c
        {
            foreach (var category in items.Keys)
            {
                foreach (var item in items[category])
                {
                    sum += item.Value;
                }
            }
            Console.WriteLine($"Sum up of all the values together: {sum}");
        }
    }
}