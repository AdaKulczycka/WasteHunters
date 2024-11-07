using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteHunters
{
    public class CommandWords
    {
<<<<<<< HEAD
        public List<string> ValidCommands { get; } = new List<string> { "north", "east", "south", "west", "look", "back", "quit", "out", "help", "take", "trash", "inventory", "map","remove"};
=======
        public List<string> ValidCommands { get; } = new List<string> { "north", "east", "south", "west", "look", "back", "quit", "out", "help", "take", "trash", "inventory", "map", "remove"};
>>>>>>> 088fe25c5a82ae5f93be9424534ed78233c8c225

        public bool IsValidCommand(string command)
        {
            return ValidCommands.Contains(command);
        }
    }

}
