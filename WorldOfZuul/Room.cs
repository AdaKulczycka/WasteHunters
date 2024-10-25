namespace WorldOfZuul
{
    public class Room
    {
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set;}
        public string Trash { get; private set; }

        public Dictionary<string, Room> Exits { get; private set; } = new();
        public Room(string shortDesc, string longDesc, string trash)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            Trash = trash;
        }

        public void SetExits(Room? north, Room? east, Room? south, Room? west)
        {
            SetExit("north", north);
            SetExit("east", east);
            SetExit("south", south);
            SetExit("west", west);
        }

        public void SetExit(string direction, Room? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }
    }
}
