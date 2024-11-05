using System.Transactions;

using System.Security.Cryptography.X509Certificates;

namespace WasteHunters
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;
        private Inventory inventory;
        Random random = new Random();
        public List<string>? beachTrash;
        public Game()
        {
            inventory = new Inventory();

            CreateRooms();
        }

        private void CreateRooms()
        {
             Room? hallway = new("Hallway", "You are standing in the hallway of your little cozy home.\n To the north you see your bathroom.\n To the east you can exit your house to the City Center.\n To the south there is... nothing.\n To the west you see your kitchen.", new List<string>{"Pet food leftovers", "Shattered glass", "Old torn shoelaces"});
            Room? bathroom = new("Bathroom", "You are in the bathroom.\n To the north there is... nothing.\n To the east there is... nothing.\n To the south you see your hallway.\n To the west you can see your bedroom.", new List<string>{ "Cotton buds", "Used razor blades", "Empty tube of toothpaste", "Empty roll of toilet paper" });
            Room? bedroom = new("Bedroom", "You are in the bedroom.\n To the north there is... nothing.\n To the east you see your bathroom.\n To the south you see your kitchen.\n To the west there is... nothing." ,new List<string>{ "Pair of socks with holes", "Candy wrapper", "Not working computer mouse", "Used batteries" });
            Room? kitchen = new("Kitchen", "You are in the kitchen.\n To the north you see your bedroom.\n To the east you see your hallway.\n To the south you see your living room.\n To the west there is... nothing." ,new List<string>{ "Egg shells", "Rotten banana", "Empty milk carton", "Empty glass jar of pesto", "Empty can of animal food" });
            Room? livingRoom = new("Living room", "You are in the living room.\n To the north you see your kitchen.\n To the east there is... nothing.\n To the south there is... nothing.\n To the west there is... nothing." ,new List<string>{ "TV", "Pizza box", "Used tissue" });
            // restaurant instead of museum
            // store instead of school
            Room? cityCenter = new("City center", "You've entered the city center.\n To the north you see a factory.\n To the east you see the beach.\n To the south you see a mall.\n To the west you can enter your house into the hallway." ,new List<string>{ "Cigarette butts", "Empty aluminium cans", "Receipts and paper scraps" });
            Room? factory = new("Factory", "You've entered a factory.\n To the north you see a forest.\n To the east you see a beach.\n To the south you see the City Center.\n To the west you see a pond." ,new List<string>{ "Cables", "Polystyrene", "Metal cleaning acid" });
            Room? mall = new("Mall", "You've entered a mall.\n To the north you see the City Center.\n To the east you see a beach.\n To the south you see a beach.\n To the west you see a park." ,new List<string>{ "Plastic bottles", "Food wrappers", "Plastic wraps and boxes" });
            Room? park = new("Park", "You've entered a park.\n To the north there is... nothing.\n To the east you see a mall.\n To the south you see a beach.\n To the west you see a school." ,new List<string>{ "Bubble gums", "Bottle caps", "Broken glass" });
            Room? forest = new("Forest", "You've entered a forest.\n To the north you see a beach.\n To the east you see a beach.\n To the south you see a factory.\n To the west you see a waterfall." ,new List<string>{ "Tire", "Bottle caps", "Plastic bottles" });
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
                        if (currentRoom?.Garbage.Count() != 0)
                        {
                            currentTrash = string.Join(", ", currentRoom?.Garbage[random.Next(0, currentRoom.Garbage.Count())]);
                            Console.WriteLine($"Type 'take' if you want to pick {currentTrash} up");
                            if (Console.ReadLine()  == "take")
                            {
                                // pickup-currentTrash
                                TakeItem(currentTrash, RubbishPrices.RubbishValues[currentTrash]);
                                Console.WriteLine($"You picked up {currentTrash}");
                                currentRoom?.Garbage.Remove(currentTrash);
                            }
                        }
                        else 
                        {
                            Console.WriteLine("This room is does not have any trash left.");
                        }
                        break;

                    case "inventory":
                        inventory.ShowInventory();
                        break;

                    case "map":
                        PrintMap();
                        break;

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
            inventory.AddItem(itemName, RubbishPrices.RubbishValues[itemName]);
        }

        public void PrintMap()
        {
            Console.WriteLine("         ╔═══════╗    ╔═══════╗             ╔═══════╗             ╔═══════╗     ╔═══════╗");
            Console.WriteLine("         ║ BEACH ║════║ BEACH ║═════════════║ BEACH ║═════════════║ BEACH ║═════║ BEACH ║");
            Console.WriteLine("         ╚═══║═══╝    ╚═══║═══╝             ╚═══║═══╝             ╚═══║═══╝     ╚═══║═══╝");
            Console.WriteLine("         ╔═══║═══╗ ╔══════║═══════╗      ╔══════║═══════╗      ╔══════║═══════╗ ╔═══║═══╗");
            Console.WriteLine("         ║ BEACH ║═║   CLEARING   ║══════║   WATERFALL  ║══════║    FOREST    ║═║ BEACH ║");
            Console.WriteLine("         ╚═══║═══╝ ╚══════║═══════╝      ╚══════║═══════╝      ╚══════║═══════╝ ╚═══║═══╝");
            Console.WriteLine("         ╔═══║═══╗ ╔══════║═══════╗      ╔══════║═══════╗      ╔══════║═══════╗ ╔═══║═══╗");
            Console.WriteLine("         ║ BEACH ║═║ DUMPING YARD ║══════║     POND     ║══════║   FACTORY    ║═║ BEACH ║");
            Console.WriteLine("         ╚═══║═══╝ ╚══════║═══════╝      ╚══════════════╝      ╚══════║═══════╝ ╚═══║═══╝");
            Console.WriteLine("             ║            ║         ╔════════════════════════╗        ║             ║    ");
            Console.WriteLine("         ╔═══║═══╗ ╔══════║═══════╗ ║ Bedroom      Bathroom  ║ ╔══════║═══════╗ ╔═══║═══╗");
            Console.WriteLine("         ║ Beach ║═║  RESTAURANT  ║ ║ Kitchen      Hallway   ║═║  CITY CENTER ║═║ BEACH ║");
            Console.WriteLine("         ╚═══║═══╝ ╚══════║═══════╝ ║ Living room            ║ ╚══════║═══════╝ ╚═══║═══╝");
            Console.WriteLine("             ║            ║         ╚════════════════════════╝        ║             ║    ");
            Console.WriteLine("         ╔═══║═══╗ ╔══════║═══════╗      ╔══════════════╗      ╔══════║═══════╗ ╔═══║═══╗");
            Console.WriteLine("         ║ BEACH ║═║ GROCERY STORE║══════║     PARK     ║══════║    MALL      ║═║ BEACH ║");
            Console.WriteLine("         ╚═══║═══╝ ╚══════║═══════╝      ╚══════║═══════╝      ╚══════║═══════╝ ╚═══║═══╝");
            Console.WriteLine("         ╔═══║═══╗    ╔═══║═══╗             ╔═══║═══╗             ╔═══║═══╗     ╔═══║═══╗");
            Console.WriteLine("         ║ BEACH ║════║ BEACH ║═════════════║ BEACH ║═════════════║ BEACH ║═════║ BEACH ║");
            Console.WriteLine("         ╚═══════╝    ╚═══════╝             ╚═══════╝             ╚═══════╝     ╚═══════╝");

         }
        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the Waste Hunters game!");
            Console.WriteLine("It is an interactive and educational game based on the 12th SDG. \n(sustainable consumption and production patterns)\n");
            PrintHelp();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine("You are lost. You are alone. You wander");
            Console.WriteLine("around the city.");
            Console.WriteLine();
            Console.WriteLine("Navigate by typing 'north', 'south', 'east', 'west', or 'out' (if you are in the hallway).");
            Console.WriteLine("Type 'look' for more details.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'quit' to exit the game.");
            Console.WriteLine("Type 'trash' to show the trash in the current room");
            Console.WriteLine("Type 'take' to pick up the trash in the room");
            Console.WriteLine("Type 'inventory' to show the inventory");
        }
    }
}

// ADD INVENTORY SECTIONS : PLASTICS, HAZARDOUS, PAPER
// MAKE DICTIONARY WITH EXAMPLE HOW IT SHOULD BE SEPERATED, IF NOT CORRECT LOSE POINTS
// dicr1
// {
//     dict1
//     {
//         {plastic shit, 2312}
//     }
//     2
//     3
//     4
// }
