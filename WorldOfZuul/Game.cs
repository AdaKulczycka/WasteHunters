using System.Transactions;

using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Formats.Asn1;
using System.Timers;

namespace WasteHunters
{
    public class Game
    {
        private SortingGuideBooklet guideBooklet;
        private Room? currentRoom;
        private Room? previousRoom;
        private Inventory inventory;
        private Map map;
        Random random = new Random();
        public List<string>? beachTrash;
        public System.Timers.Timer? myTimer = null;
        private SortingGuideBooklet sortingGuideBooklet;
        public Game()
        {
            guideBooklet = new SortingGuideBooklet();
            inventory = new Inventory();
            map = new Map();
            sortingGuideBooklet = new SortingGuideBooklet();
            CreateRooms();
        }
        public void ShowSortingTip(string itemName)
        {
            guideBooklet.ShowTip(itemName);
        }
        private void CreateRooms()
        {
            Room? hallway = new("Hallway", "You are standing in the hallway of your little cozy home.\n To the north you see your bathroom.\n To the east you can exit your house to the City Center.\n To the south there is... nothing.\n To the west you see your kitchen.", new List<string>{"Pet food leftovers", "Shattered glass", "Old torn shoelaces"});
            Room? bathroom = new("Bathroom", "You are in the bathroom.\n To the north there is... nothing.\n To the east there is... nothing.\n To the south you see your hallway.\n To the west you can see your bedroom.", new List<string>{ "Cotton buds", "Used razor blades", "Empty tube of toothpaste", "Empty roll of toilet paper" });
            Room? bedroom = new("Bedroom", "You are in the bedroom.\n To the north there is... nothing.\n To the east you see your bathroom.\n To the south you see your kitchen.\n To the west there is... nothing." ,new List<string>{ "Pair of socks with holes", "Candy wrapper", "Not working computer mouse", "Used batteries" });
            Room? kitchen = new("Kitchen", "You are in the kitchen.\n To the north you see your bedroom.\n To the east you see your hallway.\n To the south you see your living room.\n To the west there is... nothing." ,new List<string>{ "Egg shells", "Rotten banana", "Empty milk carton", "Empty glass jar of pesto", "Empty can of animal food" });
            Room? livingRoom = new("Living room", "You are in the living room.\n To the north you see your kitchen.\n To the east there is... nothing.\n To the south there is... nothing.\n To the west there is... nothing." ,new List<string>{ "TV", "Pizza box", "Used tissue" });

            Room? cityCenter = new("City center", "You've entered the city center.\n To the north you see a factory.\n To the east you see the beach.\n To the south you see a mall.\n To the west you can enter your house into the hallway." ,new List<string>{ "Cigarette butts", "Empty aluminium cans", "Receipts and paper scraps" });
            Room? factory = new("Factory", "You've entered a factory.\n To the north you see a forest.\n To the east you see a beach.\n To the south you see the City Center.\n To the west you see a pond." ,new List<string>{ "ATOMIC BOMB" }); //"Cables", "Polystyrene", "Metal cleaning acid"
            Room? mall = new("Mall", "You've entered a mall.\n To the north you see the City Center.\n To the east you see a beach.\n To the south you see a beach.\n To the west you see a park." ,new List<string>{ "Plastic bottles", "Food wrappers", "Plastic wraps and boxes" });
            Room? park = new("Park", "You've entered a park.\n To the north there is... nothing.\n To the east you see a mall.\n To the south you see a beach.\n To the west you see a school." ,new List<string>{ "Bubble gums", "Bottle caps", "Broken glass" });
            Room? forest = new("Forest", "As you look around, you see numerous trees struggling to thrive. The soil beneath them is dry, and their branches seem weak. There's a great way to \nreduce waste and help combat overproduction and overconsumption—composting! Would you like to start a compost to nourish the earth and give these \ntrees a chance to grow stronger? You've entered a forest.\n To the north you see a beach.\n To the east you see a beach.\n To the south you see a factory.\n To the west you see a waterfall." ,new List<string>{ "Tire", "Bottle caps", "Plastic bottles" });
            Room? waterfall = new("Waterfall", "You've entered a waterfall.\n To the north you see a beach.\n To the east you see a forest.\n To the south you see a pond.\n To the west you see a dumping yard." ,new List<string>{ "Wet wipes", "Empty aluminium cans", "Flip-flops" });
            Room? clearing = new("Clearing", "You've entered a clearing.\n To the north you see a beach.\n To the east you see a waterfall.\n To the south you see a dumping yard.\n To the west you see a beach." ,new List<string>{ "Old tent", "Broken glass", "Paper plates" });
            Room? pond = new("Pond", "You've entered a pond.\n To the north you see a waterfall.\n To the east you see a factory.\n To the south  you see... nothing.\n To the west you see a dumping yard." ,new List<string>{ "Empty aluminium cans", "Plastic straw", "Fishing nets" });
            Room? dumpingYard = new("Dumping yard", "You've entered a dumping yard.\n To the north you see a clearing.\n To the east you see a pond.\n To the south you see a museum.\n To the west you see a beach." ,new List<string>{"Nothing to see here"}); //Implement except this location, there is nothing to pick up here
            Room? groceryStore = new("Grocery store", "You've entered a grocery store.\n To the north you see a museum.\n To the east you see a park.\n To the south you see a beach.\n To the west you see a beach." /*yard?*/ ,new List<string>{ "Juice boxes", "Plastic bags", "Snack packaging" });
            Room? restaurant = new("Restaurant", "You've entered a restaurant.\n To the north you see a dumping yard.\n To the east you see... nothing.\n To the south you see a grocery store.\n To the west you see a beach." ,new List<string>{ "Food leftovers", "Glass bottles", "Empty aluminium cans" });
            // Need to update the long description of all the beaches below
            beachTrash = new List<string>{ "Plastic bottles", "Fishing nets", "Clothing", "Flip-flops", "Plastic straw", "Sand toy", "Beach ball", "Sunscreen bottles", "Popped inflatable rafts", "Abandoned beach towels", "Plastic wraps and boxes", "Cigarette butts" };
            Room? beachNorth1 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachNorth2 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachNorth3 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachEast1 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachEast2 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachEast3 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachEast4 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachSouth1 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachSouth2 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachSouth3 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachWest1 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachWest2 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachWest3 = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachWest4 = new("Beach", "You've entered a beach." ,beachTrash);
           
            Room? beachNorthEast = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachSouthEast = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachSouthWest = new("Beach", "You've entered a beach." ,beachTrash);
            Room? beachNorthWest = new("Beach", "You've entered a beach." ,beachTrash);


            //ALGORITHM FOR SETTING UP THE MOVEMENT IN BETWEEN THE ROOMS, DOESNT WORK, BECAUSE OF THE MOVEMENT IN BETWEEN
        //THE ROOMS OF THE APARTMENT, IDK 

        // var rooms = new Dictionary<string, Room>();
        // var coordinates = new Dictionary<(int X, int Y), Room>();

        // var roomDefinitions = new List<(string Name, int X, int Y)>
        // {
        //     // Row 1 (top row)
        //     ("beachNorthWest", 0, 6), ("beachNorth1", 1, 6), ("beachNorth2", 2, 6),
        //     ("beachNorth3", 3, 6), ("beachNorthEast", 4, 6),

        //     // Row 2
        //     ("beachWest1", 0, 5), ("clearing", 1, 5), ("waterfall", 2, 5),
        //     ("forest", 3, 5), ("beachEast1", 4, 5),

        //     // Row 3
        //     ("beachWest2", 0, 4), ("dumpingYard", 1, 4), ("pond", 2, 4),
        //     ("factory", 3, 4), ("beachEast2", 4, 4),

        //     // Row 4
        //     ("beachWest3", 0, 3), ("restaurant", 1, 3), ("kitchen", 2, 3),
        //     ("hallway", 3, 3), ("cityCenter", 4, 3), ("beachEast3", 5, 3),

        //     // Row 5
        //     ("beachWest4", 0, 2), ("groceryStore", 1, 2), ("park", 2, 2),
        //     ("mall", 3, 2), ("beachEast4", 4, 2),

        //     // Row 6 (bottom row)
        //     ("beachSouthWest", 0, 1), ("beachSouth1", 1, 1), ("beachSouth2", 2, 1),
        //     ("beachSouth3", 3, 1), ("beachSouthEast", 4, 1)
        // };

        // // Step 1: Populate the `rooms` and `coordinates`
        // foreach (var (name, x, y) in roomDefinitions)
        // {
        //     Room? room = name switch
        //     {
        //         "beachNorthWest" => beachNorthWest,
        //         "beachNorth1" => beachNorth1,
        //         "beachNorth2" => beachNorth2,
        //         "beachNorth3" => beachNorth3,
        //         "beachNorthEast" => beachNorthEast,
        //         "beachWest1" => beachWest1,
        //         "clearing" => clearing,
        //         "waterfall" => waterfall,
        //         "forest" => forest,
        //         "beachEast1" => beachEast1,
        //         "beachWest2" => beachWest2,
        //         "dumpingYard" => dumpingYard,
        //         "pond" => pond,
        //         "factory" => factory,
        //         "beachEast2" => beachEast2,
        //         "beachWest3" => beachWest3,
        //         "restaurant" => restaurant,
        //         "kitchen" => kitchen,
        //         "hallway" => hallway,
        //         "cityCenter" => cityCenter,
        //         "beachEast3" => beachEast3,
        //         "beachWest4" => beachWest4,
        //         "groceryStore" => groceryStore,
        //         "park" => park,
        //         "mall" => mall,
        //         "beachEast4" => beachEast4,
        //         "beachSouthWest" => beachSouthWest,
        //         "beachSouth1" => beachSouth1,
        //         "beachSouth2" => beachSouth2,
        //         "beachSouth3" => beachSouth3,
        //         "beachSouthEast" => beachSouthEast,
        //         _ => null
        //     };

        //     if (room != null)
        //     {
        //         rooms[name] = room;
        //         coordinates[(x, y)] = room;
        //     }
        // }

        // // Step 2: Set exits for each room
        // foreach (var ((x, y), room) in coordinates)
        // {
        //     Room? north = coordinates.GetValueOrDefault((x, y + 1));
        //     Room? east = coordinates.GetValueOrDefault((x + 1, y));
        //     Room? south = coordinates.GetValueOrDefault((x, y - 1));
        //     Room? west = coordinates.GetValueOrDefault((x - 1, y));

        //     // Restricting apartment rooms
        //     if (room == kitchen || room == bedroom || room == bathroom || room == livingRoom)
        //     {
        //         // Only connect these rooms to other apartment rooms
        //         north = (room == kitchen) ? bedroom : north;
        //         east = (room == kitchen) ? hallway : east;
        //         south = (room == bedroom) ? kitchen : south;
        //         west = (room == bathroom) ? bedroom : west;

        //         // Prevent direct exits to the outside
        //         if (room != hallway)
        //         {
        //             north = south = east = west = null;
        //         }
        //     }

        //     // Special case: Allow the hallway to connect to the city center
        //     if (room == hallway)
        //     {
        //         east = cityCenter;
        //     }

        //     // Set exits for the room
        //     room.SetExits(north, east, south, west);
        // }

            hallway.SetExits(bathroom, cityCenter, null, kitchen); // North, East, South, West
            bathroom.SetExits(null, null, hallway, bedroom);
            bedroom.SetExits(null, bathroom, kitchen, bathroom);
            kitchen.SetExits(bedroom, hallway, livingRoom, null);
            livingRoom.SetExits(kitchen, null, null, null);

            cityCenter.SetExits(factory, beachEast3, mall, hallway);

            factory.SetExits(forest, beachEast2, cityCenter, pond);

            forest.SetExits(beachNorth3, beachEast1, factory, waterfall);

            waterfall.SetExits(beachNorth2, forest, pond, clearing);

            clearing.SetExits(beachNorth1, waterfall, dumpingYard, beachWest1);

            pond.SetExits(waterfall, factory, null, dumpingYard);

            dumpingYard.SetExits(clearing, pond, restaurant, beachWest2);

            restaurant.SetExits(dumpingYard, null, groceryStore, beachWest3);

            groceryStore.SetExits(restaurant, park, beachWest4, beachSouth1);

            park.SetExits(null, mall, beachSouth2, groceryStore);

            mall.SetExits(cityCenter, beachEast4, beachSouth3, park);

            beachNorth1.SetExits(null, beachNorth2, clearing, beachNorthWest);
            beachNorth2.SetExits(null, beachNorth3, waterfall, beachNorth1);
            beachNorth3.SetExits(null, beachNorthEast, forest, beachNorth2);

            beachEast1.SetExits(beachNorthEast, null, beachEast2, forest);
            beachEast2.SetExits(beachEast1, null, beachEast3, factory);
            beachEast3.SetExits(beachEast2, null, beachEast4, cityCenter);
            beachEast4.SetExits(beachEast3, null, beachSouthEast, mall);

            beachSouth1.SetExits(groceryStore, beachSouth2, null, beachSouthWest);
            beachSouth2.SetExits(park, beachSouth3, null, beachSouth1);
            beachSouth3.SetExits(mall, beachSouthEast, null, beachSouth2);

            beachWest1.SetExits(beachNorthWest, clearing, beachWest2, null);
            beachWest2.SetExits(beachWest1, dumpingYard, beachWest3, null);
            beachWest3.SetExits(beachWest2, restaurant, beachWest4, null);
            beachWest4.SetExits(beachWest3, groceryStore, beachSouthWest, null);

            beachNorthWest.SetExits(null, beachNorth1, beachWest1, null);
            beachNorthEast.SetExits(null, null, beachEast1, beachNorth3);
            beachSouthEast.SetExits(beachEast4, null, null, beachSouth3);
            beachSouthWest.SetExits(beachEast4, beachSouth1, null, null);

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

                switch (command.Name)
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
                        if (currentRoom?.ShortDescription == "Hallway")
                        {
                            Move("east");
                        }
                        break;

                    case "trash":
                        if (currentRoom?.Garbage.Count() != 0)
                        {
                            currentTrash = string.Join(", ", currentRoom?.Garbage[random.Next(0, currentRoom.Garbage.Count())]);
                            Console.WriteLine($"Type 'take' if you want to pick {currentTrash} up");
                            if (Console.ReadLine() == "take")
                            {
                                Console.WriteLine($"Choose whether you want to put {currentTrash} it into paper, plastic, glass, general, electronic, bio or other");
                                string? choice = Console.ReadLine();
                                if (choice == "paper")
                                {
                                    TakeItemToPaper(currentTrash, RubbishPrices.RubbishValues[currentTrash]);
                                    Console.WriteLine($"You picked up {currentTrash}");
                                    currentRoom?.Garbage.Remove(currentTrash);
                                }
                                else if (choice == "plastic")
                                {
                                    TakeItemToPlastic(currentTrash, RubbishPrices.RubbishValues[currentTrash]);
                                    Console.WriteLine($"You picked up {currentTrash}");
                                    currentRoom?.Garbage.Remove(currentTrash);
                                }
                                else if (choice == "glass")
                                {
                                    TakeItemToGlass(currentTrash, RubbishPrices.RubbishValues[currentTrash]);
                                    Console.WriteLine($"You picked up {currentTrash}");
                                    currentRoom?.Garbage.Remove(currentTrash);
                                }
                                else if (choice == "general")
                                {
                                    TakeItemToGeneral(currentTrash, RubbishPrices.RubbishValues[currentTrash]);
                                    Console.WriteLine($"You picked up {currentTrash}");
                                    currentRoom?.Garbage.Remove(currentTrash);
                                }
                                else if (choice == "electronic")
                                {
                                    TakeItemToElectronic(currentTrash, RubbishPrices.RubbishValues[currentTrash]);
                                    Console.WriteLine($"You picked up {currentTrash}");
                                    currentRoom?.Garbage.Remove(currentTrash);
                                }
                                else if (choice == "bio")
                                {
                                    TakeItemToBioWaste(currentTrash, RubbishPrices.RubbishValues[currentTrash]);
                                    Console.WriteLine($"You picked up {currentTrash}");
                                    currentRoom?.Garbage.Remove(currentTrash);
                                }
                                else if (choice == "other")
                                {
                                    TakeItemToOther(currentTrash, RubbishPrices.RubbishValues[currentTrash]);
                                    Console.WriteLine($"You picked up {currentTrash}");
                                    currentRoom?.Garbage.Remove(currentTrash);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice, please choose between the following: paper, plastic, glass, general, electronic, bio or other");
                                }
                            }
                            if (currentTrash == "ATOMIC BOMB")
                            {
                                Console.WriteLine("The timer starts now!");
                                StartTimer();
                            }
                        }
                        else
                        {
                            Console.WriteLine("This room does not have any trash left.");
                        }
                        break;

                    case "inventory":
                        inventory.ShowInventory();
                        inventory.CountPoints();
                        break;

                    case "remove":
                        Console.WriteLine("Please specify the category (paper, plastic, glass, bio, electronic, general or other) of the item to remove:");
                        string? category = Console.ReadLine();

                        Console.WriteLine("Please specify the name of the item to remove:");
                        string? itemName = Console.ReadLine();

                        if (string.IsNullOrEmpty(itemName))
                        {
                            Console.WriteLine("Invalid item name.");
                            break;
                        }

        #pragma warning disable CS8604 // Possible null reference argument.
                        inventory.RemoveItem(category, itemName);
        #pragma warning restore CS8604 // Possible null reference argument.

                        StopAndDisposeTimer();
                        break;

                    case "map":
                        map.PrintMap();
                        break;

                    case "compost":
                        if (currentRoom?.ShortDescription != "Forest")
                        {
                            Console.WriteLine("This room does not look like a good place to start a compost");
                        }
                        else if (inventory.CheckEmptyBio())
                        {
                            Console.WriteLine("It looks like there are no items in your bio waste inventory");
                        }
                        else
                        {
                            inventory.CompostPoints();
                            inventory.CompostRemove();
                            Console.WriteLine("You just emptied your bio waste inventory and started a compost to help the trees grow.");
                            Console.WriteLine("If the compost only contained bio-waste you will have received double the points of the value of waste.");
                        }
                        break;

                    case "tip":
                        if (command.SecondWord != null)
                        {
                            ShowSortingTip(command.SecondWord);
                        }
                        else
                        {
                            Console.WriteLine("Specify an item to get sorting advice. Example: 'tip plastic bottle'.");
                        }
                        break;
                   
                }
            }

            Console.WriteLine("Thank you for playing Wastehunters!");
        }

        private void Move(string direction)
        {
            if (currentRoom?.Exits.ContainsKey(direction) == true)
            {
                previousRoom = currentRoom;
                currentRoom = currentRoom?.Exits[direction];

                if (currentRoom != null)
                {
                    NPCs(currentRoom);
                }
            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
            }
        }
        private bool forestVisited = false;
        private bool groceryStoreVisited = false;
        private bool pondVisited = false;
        private void NPCs (Room room)
        {
            if (room.ShortDescription == "Forest" && !forestVisited)
            {
                Console.WriteLine("Do you want to interact with Old man in the forest?");
                Console.WriteLine("*Type 'yes' to interact*");
                Console.WriteLine("*Press 'Enter' to skip*");
                forestVisited = true;
                string? input = Console.ReadLine()?.ToLower();
                if (input == "yes")
                {
                Console.WriteLine("Old man: Oh hi there.");
                Console.ReadKey(true);
                Console.WriteLine("Have you ever heard of compost?");
                Console.ReadKey(true);
                Console.WriteLine("It's a mix of ingredients used as a fertilizer made to improve the soil. And you know what the great thing is?");
                Console.ReadKey(true);
                Console.WriteLine("You can make compost from waste such as food scraps, organic byproducts and the like!");
                Console.ReadKey(true);
                Console.WriteLine("That way you not only help the plants grow but also reduce organic waste, which is a pretty big deal since it accounts for a rather significant part of trash in landfills.");
                Console.ReadKey(true);
                Console.WriteLine("It also combats climate change, as it reduces the amount of greenhouse gasses entering the atmosphere, tcomphe benefits are just crazy!");
                Console.ReadKey(true);
                Console.WriteLine("By the way, by typing in the 'compost' command you can get rid of the 'bio' part of your inventory and help the plants in this forest. Maybe I will even give you some extra points for that!");
                inventory.ExtraPoints();
                
                
                }
            }
            if (room.ShortDescription == "Grocery store" && !groceryStoreVisited)
            {
                Console.WriteLine("Do you want to interact with Cashier at the grocery store?");
                Console.WriteLine("*Type 'yes' to interact*");
                Console.WriteLine("*Press 'Enter' to skip*");
                groceryStoreVisited = true;
                string? input = Console.ReadLine()?.ToLower();
                if (input == "yes")
            {
                Console.WriteLine("Cashier: Hey, long time no see!");
                Console.ReadKey(true);
                Console.WriteLine("Heard you're cleaning up the city a bit, good job! You know, I've read recently that plastic can take up to a 1000 years to decompose in landfills.");
                Console.ReadKey(true);
                Console.WriteLine("And even then it doesn't just disappear, it just breaks down into smaller pieces - microplastics, that can spread into soil and water.");
                Console.ReadKey(true);
                Console.WriteLine("That way it contaminates ecosystems and enter the food chain, affecting both wildlife and people. Horrible. Really motivates me to recycle more.");
                Console.ReadKey(true);
                Console.WriteLine("Speaking of recycling, some guys just littered all over the floor over there. The line is so long though so I'm stuck at the cash register...");
                Console.ReadKey(true);
                Console.WriteLine("I'd really appreciate it if you could help collect the rubbish");
                Console.ReadKey(true);
                Console.WriteLine("*You get 50 extra points for interacting with the Cashier*");
                inventory.ExtraPoints();
                
                }
            }
                if (room.ShortDescription == "Pond" && !pondVisited)
            {
                Console.WriteLine("Do you want to interact with Common Toad at the pond?");
                Console.WriteLine("*Type 'yes' to interact*");
                Console.WriteLine("*Press 'Enter' to skip*");
                pondVisited = true;
                string? interact = Console.ReadLine()?.ToLower();
                if (interact == "yes")
            {
                Console.WriteLine("Common Toad: Pshhh, can you hear me?");
                Console.ReadKey(true);
                Console.WriteLine("This pond has gotten really contaminated lately. It's getting hard to live here now!");
                Console.ReadKey(true);
                Console.WriteLine("Did you know that waste affects the water quality, making it more toxic and essentially poisoning the aquatic life?");
                Console.ReadKey(true);
                Console.WriteLine("Living beings in polluted water are also put at risk of ingesting trash or getting entangled.");
                Console.ReadKey(true);
                Console.WriteLine("I'd really appreciate it if you could clean this pond up a little.");
                Console.ReadKey(true);
                Console.WriteLine("*You get 50 extra points for interacting with the Common Toad*");
                inventory.ExtraPoints();
            }
                
            }
                if (room.ShortDescription == "Dumping yard")
            {
                Console.WriteLine("Do you wish to recycle the trash in your inventory and get points in return? This will end the game.");
                Console.WriteLine("*Type 'yes' or 'no'");
                string? answer = Console.ReadLine()?.ToLower();
                if (answer == "yes")
                    {
                        inventory.Recycle();
                        Console.WriteLine("Thank you for playing Wastehunters!");
                        Environment.Exit(0);
                    }
            }
        }
                
        

        private void TakeItemToPaper(string itemName, int value)
        {
            inventory.AddItemToPaper(itemName, RubbishPrices.RubbishValues[itemName]);
        }
        private void TakeItemToPlastic(string itemName, int value)
        {
            inventory.AddItemToPlastic(itemName, RubbishPrices.RubbishValues[itemName]);
        }
        private void TakeItemToGlass(string itemName, int value)
        {
            inventory.AddItemToGlass(itemName, RubbishPrices.RubbishValues[itemName]);
        }
        private void TakeItemToGeneral(string itemName, int value)
        {
            inventory.AddItemToGeneral(itemName, RubbishPrices.RubbishValues[itemName]);
        }
        private void TakeItemToElectronic(string itemName, int value)
        {
            inventory.AddItemToElectronic(itemName, RubbishPrices.RubbishValues[itemName]);
        }
        private void TakeItemToBioWaste(string itemName, int value)
        {
            inventory.AddItemToBioWaste(itemName, RubbishPrices.RubbishValues[itemName]);
        }
        private void TakeItemToOther(string itemName, int value)
        {
            inventory.AddItemToOther(itemName, RubbishPrices.RubbishValues[itemName]);
        }
        private void StartTimer()
        {
            if (myTimer == null)
            {
                myTimer = new System.Timers.Timer(5000); // 5 seconds timer
                myTimer.Elapsed += OnTimerElapsed;
                myTimer.Start();
            }
        }
        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void StopAndDisposeTimer()
        {
        if (myTimer != null)
            {
                myTimer.Stop();
                myTimer.Dispose(); // Dispose of the timer
                myTimer = null; // Set the timer to null to prevent further use
            }
        } 
        //vlad
        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the Waste Hunters game!");
            Console.WriteLine("It is an interactive and educational game based on the 12th SDG. \n(sustainable consumption and production patterns)\n");
            Console.WriteLine("You woke up from a beautiful dream, where you had a vision of how the island of Zool once looked liked. You decide that this dream is a sign and that you are encouraged to save the island from all the trash there is. That is how you become a Waste Hunter.");
            PrintHelp();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("You are lost. You are alone. You wander");
            Console.WriteLine("around the city.");
            Console.WriteLine();
            Console.WriteLine("Navigate by typing");
            
            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'north', 'south', 'east', 'west', or 'out'");
            Console.ResetColor();
            Console.WriteLine(" (if you are in the hallway).");

            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'look'");
            Console.ResetColor();
            Console.WriteLine(" for more details.");

            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'back'");
            Console.ResetColor();
            Console.WriteLine(" to go to the previous room.");

            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'help'");
            Console.ResetColor();
            Console.WriteLine(" to print this message again.");

            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'quit'");
            Console.ResetColor();
            Console.WriteLine(" to exit the game.");

            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'trash'");
            Console.ResetColor();
            Console.WriteLine(" to show the trash in the current room.");

            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'take'");
            Console.ResetColor();
            Console.WriteLine(" to pick up the trash in the room.");

            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'inventory'");
            Console.ResetColor();
            Console.WriteLine(" to show the inventory.");
            Console.Write("test");

            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'tip'");
            Console.ResetColor();
            Console.WriteLine(" To show you a tip for recycling a specific item.");

            // Console.WriteLine("You are lost. You are alone. You wander");
            // Console.WriteLine("around the city.");
            // Console.WriteLine();
            // Console.WriteLine("Navigate by typing 'north', 'south', 'east', 'west', or 'out' (if you are in the hallway).");
            // Console.WriteLine("Type 'look' for more details.");
            // Console.WriteLine("Type 'back' to go to the previous room.");
            // Console.WriteLine("Type 'help' to print this message again.");
            // Console.WriteLine("Type 'quit' to exit the game.");
            // Console.WriteLine("Type 'trash' to show the trash in the current room");
            // Console.WriteLine("Type 'take' to pick up the trash in the room");
            // Console.WriteLine("Type 'inventory' to show the inventory");
        }
    }
}

//NPCs talking about specific trash doing shit to specific environment
//Special items to give special points or superpowers
//Crafting objects from the trash in the inventory
// MAKE DICTIONARY WITH EXAMPLE HOW IT SHOULD BE SEPERATED, IF NOT CORRECT LOSE POINTS

// Sorting Guide Booklet
// When collected, this booklet provides hints or tips about the correct sorting categories for different trash items. 
// This could either reveal hints about items you’ve already collected or help with new, more challenging trash types.

// Compost in forest/park
// special inventory for compost, and option to dump it in the forest for extra points

// create a string list of inventory categories to easy access

// do algorithm for the setexits, do list of lists so that it doesnt look like shit
// [
//     [
//         Beach, Beach, Beach, ...
//     ],
//     [
//         Beach, Clearing, ...
//     ]
// ]
// pasp
