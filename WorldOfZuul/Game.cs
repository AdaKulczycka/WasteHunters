// using System.Transactions;

using System.Security.Cryptography.X509Certificates;

namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;
        private Inventory inventory;
        Random random = new Random();
        public Game()
        {
            inventory = new Inventory();

            CreateRooms();
        }

        private void CreateRooms()
        {
            // Room? bathroom = new("Bathroom", "You are in the bathroom", new List<string>{"cotton buds", "used razor blades", "empty tube of toothpaste", "empty roll of toilet paper"});
            // Room? hallway = new("Hallway", "You are staying in the hallway of your little cozy home. To the ......", new List<string>{"pet food leftovers", "shattered glass", "old torn shoelaces"});
            // currentRoom = bathroom;
            // trash = new List<string>{currentRoom.Trash[random.Next(0, currentRoom.Trash.Count())]};

            Room? hallway = new("Hallway", "You are standing in the hallway of your little cozy home.\n To the north you see your bathroom.\n To the east you can exit your house to the City Center.\n To the south there is... nothing.\n To the west you see your kitchen.", new List<string>{"pet food leftovers", "shattered glass", "old torn shoelaces"});
            Room? bathroom = new("Bathroom", "You are in the bathroom.\n To the north there is... nothing.\n To the east there is... nothing.\n To the south you see your hallway.\n To the west you can see your bedroom.", new List<string>{ "cotton buds", "used razor blades", "empty tube of toothpaste", "empty roll of toilet paper" });
            Room? bedroom = new("Bedroom", "You are in the bedroom.\n To the north there is... nothing.\n To the east you see your bathroom.\n To the south you see your kitchen.\n To the west there is... nothing." ,new List<string>{ "pair of socks with holes", "candy wrapper", "not working computer mouse", "used batteries" });
            Room? kitchen = new("Kitchen", "You are in the kitchen.\n To the north you see your bedroom.\n To the east you see your hallway.\n To the south you see your living room.\n To the west there is... nothing." ,new List<string>{ "egg shells", "rotten banana", "empty milk carton", "empty glass jar of pesto", "empty can of animal food" });
            Room? livingRoom = new("Living room", "You are in the living room.\n To the north you see your kitchen.\n To the east there is... nothing.\n To the south there is... nothing.\n To the west there is... nothing." ,new List<string>{ "tv", "pizza box", "tissue" });

            Room? cityCenter = new("City center", "You've entered the city center.\n To the north you see a factory.\n To the east you see the beach.\n To the south you see a mall.\n To the west you can enter your house into the hallway." ,new List<string>{ "cigarette butts", "empty aluminium cans", "receipts and paper scraps" });
            Room? factory = new("Factory", "You've entered a factory.\n To the north you see a forest.\n To the east you see a beach.\n To the south you see the City Center.\n To the west you see a pond." ,new List<string>{ "cables", "polystyrene", "metal cleaning acid" });
            Room? mall = new("Mall", "You've entered a mall.\n To the north you see the City Center.\n To the east you see a beach.\n To the south you see a beach.\n To the west you see a park." ,new List<string>{ "plastic bottles", "food wrappers", "plastic wraps and boxes" });
            Room? park = new("Park", "You've entered a park.\n To the north there is... nothing.\n To the east you see a mall.\n To the south you see a beach.\n To the west you see a school." ,new List<string>{ "bubble gums", "bottle caps", "broken glass" });
            Room? forest = new("Forest", "You've entered a forest.\n To the north you see a beach.\n To the east you see a beach.\n To the south you see a factory.\n To the west you see a waterfall." ,new List<string>{ "tires", "bottle caps", "plastic bottles" });
            Room? waterfall = new("Waterfall", "You've entered a waterfall.\n To the north you see a beach.\n To the east you see a forest.\n To the south you see a pond.\n To the west you see a dumping yard." ,new List<string>{ "wet wipes", "cans", "flip-flops" });
            Room? clearing = new("Clearing", "You've entered a clearing.\n To the north you see a beach.\n To the east you see a waterfall.\n To the south you see a dumping yard.\n To the west you see a beach." ,new List<string>{ "old tent", "broken glass", "paper plates" });
            Room? pond = new("Pond", "You've entered a pond.\n To the north you see a waterfall.\n To the east you see a factory.\n To the south  you see... nothing.\n To the west you see a dumping yard." ,new List<string>{ "empty aluminium cans", "plastic straw", "fishing nets" });
            Room? dumpingYard = new("Dumping yard", "You've entered a dumping yard.\n To the north you see a clearing.\n To the east you see a pond.\n To the south you see a museum.\n To the west you see a beach." ,new List<string>{"Nothing to see here"}); //Implement except this location, there is nothing to pick up here
            Room? school = new("School", "You've entered a school.\n To the north you see a museum.\n To the east you see a park.\n To the south you see a beach.\n To the west you see a beach." /*yard?*/ ,new List<string>{ "juice boxes", "exam papers", "pen" });
            Room? museum = new("Museum", "You've entered a museum.\n To the north you see a dumping yard.\n To the east you see... nothing.\n To the south you see a school.\n To the west you see a beach." ,new List<string>{ "coffee cups", "exhibit maps", "cans" });
            Room? beach = new("Beach", "You've entered a beach." ,new List<string>{ "plastic bottles", "fishing nets", "clothing", "flip-flops", "straw", "sand toy", "beach ball", "sunscreen bottles", "popped inflatable rafts", "abandoned beach towels", "plastic wraps and boxes", "cigarette butts" });


            hallway.SetExits(bathroom, cityCenter, null, kitchen); // North, East, South, West
            bathroom.SetExits(null, null, hallway, bedroom);
            bedroom.SetExits(null, bathroom, kitchen, bathroom);
            kitchen.SetExits(bedroom, hallway, livingRoom, null);
            livingRoom.SetExits(kitchen, null, null, null);

            cityCenter.SetExits(factory, beach, mall, hallway);

            factory.SetExits(forest, beach, cityCenter, pond);

            forest.SetExits(beach, beach, factory, waterfall);

            waterfall.SetExits(beach, forest, pond, clearing);

            clearing.SetExits(beach, waterfall, dumpingYard, beach);

            pond.SetExits(waterfall, factory, null, dumpingYard);

            dumpingYard.SetExits(clearing, pond, museum, beach);

            museum.SetExits(dumpingYard, null, school, beach);

            school.SetExits(museum, park, beach, beach);

            park.SetExits(null, mall, beach, school);

            mall.SetExits(cityCenter, beach, beach, park);
            currentRoom = hallway;
        }
        public void Play()
        {
            String currentTrash;
            Parser parser = new();

            PrintWelcome();

            bool continuePlaying = true;
            while (continuePlaying)
            {
                Console.WriteLine(currentRoom?.ShortDescription);
                Console.Write("> ");

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a command.");
                    continue;
                }

                Command? command = parser.GetCommand(input);

                if (command == null)
                {
                    Console.WriteLine("I don't know that command.");
                    continue;
                }

                switch(command.Name)
                {
                    case "look":
                        Console.WriteLine(currentRoom?.LongDescription);
                        break;

                    case "back":
                        if (previousRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            currentRoom = previousRoom;
                        break;
                    
                    case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(command.Name);
                        break;

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    case "out":
                        if (currentRoom?.ShortDescription == "Hallway" )
                        {
                            Move("east");
                        }
                        break;
                    case "trash":
                        currentTrash = string.Join(", ", currentRoom?.Garbage[random.Next(0, currentRoom.Garbage.Count())]);
                        Console.WriteLine($"Type 'take' if you want to pick {currentTrash} up");
                        if (Console.ReadLine()  == "take")
                        {
                            // pickup-currentTrash
                            TakeItem(currentTrash, 0);
                            Console.WriteLine($"You picked up {currentTrash}");
                            currentRoom?.Garbage.Remove(currentTrash);
                        }
                        break;

                    case "inventory":
                        inventory.ShowInventory();
                        break;
                        
                    // case "take":
                    //     TakeItem(command.Name, 0);

                    //     break;

                    default:
                        Console.WriteLine("I don't know what command.");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing World of Zuul!");
        }

        private void Move(string direction)
        {
            if (currentRoom?.Exits.ContainsKey(direction) == true)
            {
                previousRoom = currentRoom;
                currentRoom = currentRoom?.Exits[direction];
            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
            }
        }

        private void TakeItem(string itemName, int value)
        {
            inventory.AddItem(itemName, 0);
        }
        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the World of Zuul!");
            Console.WriteLine("World of Zuul is a new, incredibly boring adventure game.");
            PrintHelp();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("You are lost. You are alone. You wander");
            Console.WriteLine("around the university.");
            Console.WriteLine();
            Console.WriteLine("Navigate by typing 'north', 'south', 'east', 'west', or 'out' (if you are in the hallway).");
            Console.WriteLine("Type 'look' for more details.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'quit' to exit the game.");
            Console.WriteLine("Type 'trash' to show the trash in the current room");

        }
    }
}
