using System;
using System.Collections.Generic;

namespace WasteHunters
{
    public class SortingGuideBooklet
    {
        private Dictionary<string, string> tips;

        public SortingGuideBooklet()
        {
            tips = new Dictionary<string, string>
            {
                { "Used razor blades", "Dispose of at hazardous waste points; do not throw in regular bins." },
                { "Used batteries", "Dispose of as e-waste." },
                { "Fishing nets", "Recycle through specialized programs for fishing gear if possible. Otherwise recycle as general waste." },
                { "Plastic bottles", "Recycle in the yellow bin or plastic recycling facilities." }, 
                { "Tire", "Take to tire recycling centers or facilities." }, 
                { "Shattered glass", "Dispose in the green glass bin, if safe; otherwise, hazardous waste." },
                { "Empty glass jar of pesto", "Recycle in the green glass bin after rinsing." },
                { "Not working computer mouse", "Recycle at e-waste collection points." },
                { "Plastic wraps and boxes", "Recycle in the yellow bin." }, 
                { "Broken glass", "Dispose in the green glass bin, if safe; otherwise, hazardous waste." },
                { "Empty aluminium cans", "Recycle in the yellow bin alongside plastic." },
                { "Bottle caps", "Recycle in the yellow bin; separate from bottles if possible." }, 
                { "Bubble gums", "Dispose in general waste bins; avoid littering." },
                { "Empty can of animal food", "Rinse and recycle in the yellow bin. "},
                { "Pair of socks with holes", "Dispose in textile recycling or if not possible, into general waste." },
                { "Candy wrapper", "Dispose in general waste bins." },
                { "Cigarette butts", "Dispose of in general waste bins; avoid littering." },
                { "Receipts and paper scraps", "Dispose in general waste bins; thermal paper is non-recyclable." },
                { "Empty roll of toilet paper", "Recycle in the blue paper bin." },
                { "Egg shells", "Compost them." },
                { "Rotten banana", "Compost it or dispose in organic waste bins." },
                { "Pet food leftovers", "Compost if possible or dispose in organic waste bins." },
                { "Old torn shoelaces", "Dispose in general waste or textile recycling if applicable." },
                { "Cotton buds", "Dispose in general waste; avoid flushing down the toilet." },
                { "Empty tube of toothpaste", "Recycle in the yellow bin if facilities accept it." }, 
                { "Empty milk carton", "Recycle in the yellow bin." }, 
                { "Food wrappers", "Dispose in general waste bins." },
                { "Wet wipes", "Dispose in general waste; avoid flushing." },
                { "Flip-flops", "Dispose in general waste or recycle through specialized programs." },
                { "Old tent", "Donate if reusable; otherwise, dispose in general waste." },
                { "Paper plates", "Dispose in general waste or compost if not coated with plastic." },
                { "Clothing", "Donate if reusable; otherwise, general waste if textile recycling isn't available." },
                { "Plastic straw", "Dispose in general waste; avoid single-use plastics." },
                { "Juice boxes", "Recycle in the yellow bin after rinsing." }, 
                { "Plastic bags", "Dispose in general waste." }, 
                { "Snack packaging", "Dispose in general waste bins." },
                { "Coffee cups", "Dispose of the cup in general waste." },
                { "Exhibit map", "Recycle in the blue paper bin." },
                { "Broken sunglasses", "Recycle into general waste." },
                { "Sand toy", "Recycle as plastic." }, 
                { "Beach ball", "Dispose in general waste" },
                { "Sunscreen bottles", "Rinse and recycle in the yellow bin if possible." }, 
                { "Popped inflatable rafts", "Dispose in general waste or recycle through specialized programs." },
                { "Abandoned beach towels", "Donate if clean; otherwise, dispose in general waste." },
                { "Cables", "Recycle at e-waste collection points." },
                { "Polystyrene", "Dispose in general waste; difficult to recycle." },
                { "Metal cleaning acid", "Dispose at hazardous waste collection points." },
                { "TV", "Recycle at e-waste facilities or return to a seller offering recycling." },
                { "Pizza box", "Greasy parts go to general waste." },
                { "Used tissue", "Dispose in general waste" },
                { "Food leftovers", "Compost if possible or dispose in organic waste bins." },
                { "Glass bottles", "Recycle in the green glass bin." },
                { "ATOMIC BOMB", "Contact international authorities immediately; do not attempt to dispose of yourself!" }
            };
        }
        public void ShowTip(string itemName)
        {
            if (tips.ContainsKey(itemName))
            {
                Console.WriteLine(itemName + " : " + tips[itemName]);
            }
            else
            {
                Console.WriteLine("No tip found for: " + itemName);
            }
        }
    }
}