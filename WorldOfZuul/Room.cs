namespace WasteHunters
{
    public class Room
    {
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set;}
        public List<string> Garbage { get; private set; }

        public Dictionary<string, Room> Exits { get; private set; } = new();
        public Room(string shortDesc, string longDesc, List<string> garbage)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            Garbage = garbage;
        }

        public void SetExits(Room? north, Room? east, Room? south, Room? west)
        {
            SetExit("n", north);
            SetExit("e", east);
            SetExit("s", south);
            SetExit("w", west);
        }

        public void SetExit(string direction, Room? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }
    }
}
