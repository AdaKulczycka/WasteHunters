using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WasteHunters
{
    public class CommandWords
    {
        public List<string> ValidCommands { get; } = new List<string> { "n", "e", "s", "w", "look", "back", "quit", "o", "help", "take", "trash", "inventory", "map", "remove", "compost", "tip", "guide"};

        public bool IsValidCommand(string command)
        {
            return ValidCommands.Contains(command);
        }
    }

}
