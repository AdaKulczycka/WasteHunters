namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;

        public Game()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            Room? hallway = new("Hallway", "You are staying in the hallway of your little cozy home. To the ......");
            Room? bathroom = new("Bathroom", "You are in the bathroom");
            Room? bedroom = new("Bedroom", "You are in the bedroom");
            Room? kitchen = new("Kitchen", "You are in the kitchen");
            Room? livingRoom = new("livingRoom", "You are in the livingRoom");

            Room? cityCenter = new("City center", "You've entered a city center");
            Room? factory = new("Factory", "You've entered a factory.");
            Room? mall = new("Mall", "You've entered a mall.");
            Room? park = new("Park", "You've entered a park.");
            Room? forest = new("Forest", "You've entered a forest");
            Room? waterfall = new("Waterfall", "You've entered a waterfall");
            Room? clearing = new("Clearing", "You've entered a clearing");
            Room? pond = new("Pond", "You've entered a pond");
            Room? dumpingYard = new("Dumping yard", "You've entered a dumping yard.");
            Room? school = new("School", "You've entered a school yard");
            Room? museum = new("Museum", "You've entered a museum");
            Room? beach = new("Beach", "You've entered a beach");



            hallway.SetExits(bathroom, cityCenter, null, kitchen); // North, East, South, West
            bathroom.SetExits(null, bedroom, hallway, null);
            bedroom.SetExits(null, null, kitchen, bathroom);
            kitchen.SetExits(bedroom, null, livingRoom, hallway);
            livingRoom.SetExits(kitchen, null, null, null);

            cityCenter.SetExits(factory, beach, mall, beach);

            factory.SetExits(forest, pond, cityCenter, beach);

            forest.SetExits(beach, beach, factory, waterfall);

            waterfall.SetExits(beach, forest, pond, clearing);

            clearing.SetExits(beach, beach, dumpingYard, pond);

            pond.SetExits(waterfall, dumpingYard, null, factory);

            dumpingYard.SetExits(clearing, beach, museum, pond);

            museum.SetExits(dumpingYard, null, school, beach);

            school.SetExits(museum, park, beach, beach);

            park.SetExits(null, school, beach, mall);

            mall.SetExits(cityCenter, park, beach, beach);
            currentRoom = bedroom;
        }

        public void Play()
        {
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
            Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            Console.WriteLine("Type 'look' for more details.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'quit' to exit the game.");
        }
    }
}
