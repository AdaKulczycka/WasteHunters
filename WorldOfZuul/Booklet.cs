namespace WasteHunters
{
    public class SortingGuideBooklet
    {
        private Dictionary<string, string> tips;

        public SortingGuideBooklet()
        {
            tips = new Dictionary<string, string>
            {
                { "UsedRazorBlades", "Dispose of at hazardous waste points; do not throw in regular bins." },
                { "UsedBatteries", "Dispose of as e-waste." },
                { "FishingNets", "Recycle through specialized programs for fishing gear if possible. Otherwise recycle as general waste." },
                { "PlasticBottles", "Recycle in the yellow bin or plastic recycling facilities." }, 
                { "Tire", "Take to tire recycling centers or facilities." }, 
                { "ShatteredGlass", "Dispose in the green glass bin, if safe; otherwise, hazardous waste." },
                { "EmptyGlassJarofPesto", "Recycle in the green glass bin after rinsing." },
                { "NotworkingComputerMouse", "Recycle at e-waste collection points." },
                { "PlasticWrapsAndBoxes", "Recycle in the yellow bin." }, 
                { "BrokenGlass", "Dispose in the green glass bin, if safe; otherwise, hazardous waste." },
                { "EmptyAluminiumCans", "Recycle in the yellow bin alongside plastic." },
                { "BottleCaps", "Recycle in the yellow bin; separate from bottles if possible." }, 
                { "BubbleGums", "Dispose in general waste bins; avoid littering." },
                { "EmptyCanOfAnimalFood", "Rinse and recycle in the yellow bin. "},
                { "PairOfSocksWithHoles", "Dispose in textile recycling or if not possible, into general waste." },
                { "CandyWrapper", "Dispose in general waste bins." },
                { "CigaretteButts", "Dispose of in general waste bins; avoid littering." },
                { "ReceiptsAndPaperScraps", "Dispose in general waste bins; thermal paper is non-recyclable." },
                { "EmptyRollOfToiletPaper", "Recycle in the blue paper bin." },
                { "EggShells", "Compost them." },
                { "RottenBanana", "Compost it or dispose in organic waste bins." },
                { "PetFoodLeftovers", "Compost if possible or dispose in organic waste bins." },
                { "OldTornShoelaces", "Dispose in general waste or textile recycling if applicable." },
                { "CottonBuds", "Dispose in general waste; avoid flushing down the toilet." },
                { "EmptyTubeOfToothpaste", "Recycle in the yellow bin if facilities accept it." }, 
                { "EmptyMilkCarton", "Recycle in the yellow bin." }, 
                { "FoodWrappers", "Dispose in general waste bins." },
                { "WetWipes", "Dispose in general waste; avoid flushing." },
                { "Flip-flops", "Dispose in general waste or recycle through specialized programs." },
                { "OldTent", "Donate if reusable; otherwise, dispose in general waste." },
                { "PaperPlates", "Dispose in general waste or compost if not coated with plastic." },
                { "Clothing", "Donate if reusable; otherwise, general waste if textile recycling isn't available." },
                { "PlasticStraw", "Dispose in general waste; avoid single-use plastics." },
                { "JuiceBoxes", "Recycle in the yellow bin after rinsing." }, 
                { "PlasticBags", "Dispose in general waste." }, 
                { "SnackPackaging", "Dispose in general waste bins." },
                { "CoffeeCups", "Dispose of the cup in general waste." },
                { "ExhibitMap", "Recycle in the blue paper bin." },
                { "BrokenSunglasses", "Recycle into general waste." },
                { "SandToy", "Recycle as plastic." }, 
                { "BeachBall", "Dispose in general waste" },
                { "SunscreenBottles", "Rinse and recycle in the yellow bin if possible." }, 
                { "PoppedInflatableRafts", "Dispose in general waste or recycle through specialized programs." },
                { "AbandonedBeachTowels", "Donate if clean; otherwise, dispose in general waste." },
                { "Cables", "Recycle at e-waste collection points." },
                { "Polystyrene", "Dispose in general waste; difficult to recycle." },
                { "MetalCleaningAcid", "Dispose at hazardous waste collection points." },
                { "TV", "Recycle at e-waste facilities or return to a seller offering recycling." },
                { "PizzaBox", "Greasy parts go to general waste." },
                { "UsedTissue", "Dispose in general waste" },
                { "FoodLeftovers", "Compost if possible or dispose in organic waste bins." },
                { "GlassBottles", "Recycle in the green glass bin." },
                { "ATOMICBOMB", "Contact international authorities immediately; do not attempt to dispose of yourself!" }
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