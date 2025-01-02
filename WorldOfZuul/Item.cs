namespace WasteHunters{
    public class Inventory{
        int sum = 0;
        int points = 0; 

        private Dictionary<string, Dictionary<string, int>> items;
        public Inventory()
        {
             items = new Dictionary<string, Dictionary<string, int>>()
            {
                { "plastic", new Dictionary<string, int>() },
                { "paper", new Dictionary<string, int>() },
                { "glass", new Dictionary<string, int>() },
                { "general waste", new Dictionary<string, int>()},
                { "electronic waste", new Dictionary<string, int>()},
                { "bio waste", new Dictionary<string, int>() },
                { "other", new Dictionary<string, int>() }
            };
        }

        public void AddItemToPlastic(string itemName, int value)
        {
            AddItemToCategory("plastic", itemName, value);
        }

        public void AddItemToPaper(string itemName, int value)
        {
            AddItemToCategory("paper", itemName, value);
        }

        public void AddItemToGlass(string itemName, int value)
        {
            AddItemToCategory("glass", itemName, value);
        }
        public void AddItemToGeneral(string itemName, int value)
        {
            AddItemToCategory("general waste", itemName, value);
        }
        public void AddItemToElectronic(string itemName, int value)
        {
            AddItemToCategory("electronic waste", itemName, value);
        }
        public void AddItemToBioWaste(string itemName, int value)
        {
            AddItemToCategory("bio waste", itemName, value);
        }
        public void AddItemToOther(string itemName, int value)
        {
            AddItemToCategory("other", itemName, value);
        }
        // Generic method to add items to any category
        private void AddItemToCategory(string category, string itemName, int value)
        {
            items[category][itemName] = value; // Add new item to category
        }
        

        // Method to display the contents of each category
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
            DisplayPoints();   
        }
        public void DisplayPoints()
        {
            Console.WriteLine($"Points: {points}");
        }
        public void ExtraPoints()
        {
            points += 50; 
        }

        
        public void Recycle()
        {
            foreach (var category in items.Keys)
            {
                items[category].Clear(); 
            }
            points += sum;
            sum = 0;
            Console.WriteLine($"You have recycled the trash.");
            if (points < 0)
            {
                Console.WriteLine($"You now have {points} points.");
                Console.WriteLine("You need to improve your recycling skills. It seems like there is a lot to learn. Keep trying!");
            }
            if (points > 0 && points < 100)
            {
                Console.WriteLine($"You now have {points} points.");
                Console.WriteLine("Good job, but there is room for improvement. Some items were sorted correctly, but others need a closer look.");            
            }
            if (points > 100)
            {
                Console.WriteLine($"You now have {points} points.");
                Console.WriteLine("Amazing job! You recycled the majority or everything correctly. Keep up the great work and stay green!");
            }
        }
        public void RemoveItem(string category, string itemName)
        {
            if (items[category].ContainsKey(itemName))
            {
                items[category].Remove(itemName);
            }
        }
        public bool CorrectlySorted(string category, string itemName)
        {
            if (category == "plastic" && (itemName == "Plastic bottles" || itemName == "Plastic wraps and boxes" || itemName == "Bottle caps" || itemName == "Empty tube of toothpaste" || itemName == "Plastic bags" || itemName == "Juice boxes" || itemName == "Sand toy" || itemName == "Sunscreen bottles" || itemName == "Empty milk carton" || itemName == "Empty aluminium cans" || itemName == "Empty can of animal food"))
            {
            return true;
            }
            if (category == "paper" && (itemName == "Exhibit map" || itemName == "Empty roll of toilet paper"))
            {
            return true;
            }
            if (category == "glass" && (itemName == "Broken glass" || itemName == "Shattered glass" || itemName == "Empty glass jar of pesto" || itemName == "Glass bottles"))
            {
            return true;
            }
            if (category == "general waste" && (itemName == "Fishing nets" || itemName == "Bubble gums" || itemName == "Pair of socks with holes" || itemName == "Candy wrapper" || itemName == "Cigarette butts" || itemName == "Receipts and paper scraps" || itemName == "Old torn shoelaces" || itemName == "Cotton buds" || itemName == "Food wrappers" || itemName == "Wet wipes" || itemName == "Flip-flops" || itemName == "Old tent" || itemName == "Paper plates" || itemName == "Clothing" || itemName == "Plastic straw" || itemName == "Snack packaging" || itemName == "Plastic bags" || itemName == "Coffee cups" || itemName == "Broken sunglasses" || itemName == "Popped inflatable rafts" || itemName == "Beach ball" || itemName == "Abandoned beach towels" || itemName == "Polystyrene" || itemName == "Pizza box" || itemName == "Used tissue"))
            {
            return true;
            }
            if (category == "electronic waste" && (itemName == "Used batteries" || itemName == "Not working computer mouse" || itemName == "Cables" || itemName == "TV"))
            {
            return true;
            }
            if (category == "bio waste" && (itemName == "Food leftovers" || itemName == "Rotten banana" || itemName == "Egg shells"))
            {
            return true;
            }
            if (category == "other" && (itemName == "Used razor blades" || itemName == "Tire" || itemName == "Metal cleaning acid"))
            {
            return true;
            }
            return false;
            
        }
        
        public void CountPoints()
        {
            sum = 0;
            foreach (var category in items.Keys)
            {
                foreach (var item in items[category])
                {
                    if (CorrectlySorted(category, item.Key))
                
                {
                    sum += item.Value;
                }
                    else
                    {
                        sum -= item.Value;
                        
                    }
                }
            }
            Console.WriteLine($"Sum up of all the values together: {sum}");
        }
        public void CompostPoints()
        {
            int pointscompost = 0;
            foreach (var item in items["bio waste"])
            {
            if (CorrectlySorted("bio waste", item.Key))
            {
                pointscompost += item.Value; 
            }
            points += pointscompost * 2;
            }
        }
        public void CompostRemove()
        {
            foreach (var item in items["bio waste"].Keys)
            {
                items["bio waste"].Remove(item);
                sum = 0;
            }
        }
        public bool CheckEmptyBio()
        {
            if (items["bio waste"].Count() == 0)
            {
                return true;
            }
            return false;
        }
    }
}