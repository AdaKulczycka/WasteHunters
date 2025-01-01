namespace WasteHunters
{
    public class Command
    {
        public string Name { get; }
        public string? SecondWord { get; } 

        public Command(string name, string? secondWord = null)
        {
            Name = name;
            SecondWord = secondWord;
        }
    }
}
