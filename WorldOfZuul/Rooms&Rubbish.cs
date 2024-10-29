using System.Collections.Generic;

namespace WorldOfZuul
{
    public static class Rubbish
    {
        public static Dictionary<string, List<string>> RubbishByLocation { get; } = new Dictionary<string, List<string>>
        {
            { "Bathroom", new List<string> { "cotton buds", "used razor blades", "empty tube of toothpaste", "empty roll of toilet paper" } },
            { "Kitchen", new List<string> { "egg shells", "rotten banana", "empty milk carton", "empty glass jar of pesto", "empty can of animal food" } },
            { "Bedroom", new List<string> { "pair of socks with holes", "candy wrapper", "not working computer mouse", "used batteries" } },
            { "Hallway", new List<string> { "pet food leftovers", "shattered glass", "old torn shoelaces" } },
            { "Garage", new List<string> { "oil bottles", "dirty rags", "broken tools" } },
            { "City centre", new List<string> { "cigarette butts", "empty aluminium cans", "receipts and paper scraps" } },
            { "Factory", new List<string> { "cables", "polystyrene", "metal cleaning acid" } },
            { "Mall", new List<string> { "plastic bottles", "food wrappers", "plastic wraps and boxes" } },
            { "Park", new List<string> { "bubble gums", "bottle caps", "broken glass" } },
            { "Forest", new List<string> { "tires", "bottle caps", "plastic bottles" } },
            { "Waterfall", new List<string> { "wet wipes", "cans", "flip-flops" } },
            { "Clearing", new List<string> { "old tent", "broken glass", "paper plates" } },
            { "Pond", new List<string> { "empty aluminium cans", "plastic straw", "fishing nets" } },
            { "Recycling yard", new List<string>() },
            { "School", new List<string> { "juice boxes", "exam papers", "pen" } },
            { "Museum", new List<string> { "coffee cups", "exhibit maps", "cans" } },
            { "Beach", new List<string> { "plastic bottles", "fishing nets", "clothing", "flip-flops", "straw", "sand toy", "beach ball", "sunscreen bottles", "popped inflatable rafts", "abandoned beach towels", "plastic wraps and boxes", "cigarette butts" } }
        };
    }
}
