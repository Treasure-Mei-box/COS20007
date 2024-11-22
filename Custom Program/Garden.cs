using System;
using Village;
namespace Village
{
    public class Garden
    {
        public List<Crop> Crops { get; set; }

        public Garden()
        {
            Crops = new List<Crop>();
        }

        // Plant a crop in the garden
        public void PlantCrop(Player player)
        {
            Console.WriteLine("Which crop would you like to plant?");
            Console.WriteLine("1. Tomato");
            Console.WriteLine("2. Carrot");
            Console.WriteLine("3. Corn");

            string choice = Console.ReadLine();
            Crop newCrop = null;

            switch (choice)
            {
                case "1":
                    newCrop = new Crop("Tomato", "Planted");
                    break;
                case "2":
                    newCrop = new Crop("Carrot", "Planted");
                    break;
                case "3":
                    newCrop = new Crop("Corn", "Planted");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Crops.Add(newCrop);
            Console.WriteLine($"{newCrop.Name} has been planted.");
        }

        // Water the crops to improve their growth stage
        public void WaterCrops(Player player)
        {
            if (Crops.Count == 0)
            {
                Console.WriteLine("No crops to water.");
                return;
            }

            Console.WriteLine("Which crop would you like to water?");
            for (int i = 0; i < Crops.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Crops[i].Name} - Stage: {Crops[i].Stage}");
            }

            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int cropIndex) && cropIndex > 0 && cropIndex <= Crops.Count)
            {
                Crop selectedCrop = Crops[cropIndex - 1];
                if (selectedCrop.Stage == "Harvested")
                {
                    Console.WriteLine($"{selectedCrop.Name} is already harvested.");
                }
                else if (selectedCrop.Stage == "Planted")
                {
                    selectedCrop.Stage = "Growing";
                    Console.WriteLine($"You watered {selectedCrop.Name}. It is now growing.");
                }
                else if (selectedCrop.Stage == "Growing")
                {
                    selectedCrop.Stage = "Mature";
                    Console.WriteLine($"You watered {selectedCrop.Name}. It is now mature.");
                }
                else
                {
                    Console.WriteLine($"{selectedCrop.Name} is already mature.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        // Check the growth stages of the crops
        public void CheckCropStage(Player player)
        {
            if (Crops.Count == 0)
            {
                Console.WriteLine("You have no crops planted.");
                return;
            }

            Console.WriteLine("Here are the current stages of your crops:");
            foreach (var crop in Crops)
            {
                Console.WriteLine($"{crop.Name}: {crop.Stage}");
            }
        }

        // Harvest crops that are mature
        public void HarvestCrop(Player player)
        {
            if (Crops.Count == 0)
            {
                Console.WriteLine("No crops to harvest.");
                return;
            }

            Console.WriteLine("Which crop would you like to harvest?");
            for (int i = 0; i < Crops.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Crops[i].Name} - Stage: {Crops[i].Stage}");
            }

            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int cropIndex) && cropIndex > 0 && cropIndex <= Crops.Count)
            {
                Crop selectedCrop = Crops[cropIndex - 1];
                if (selectedCrop.Stage == "Mature")
                {
                    Console.WriteLine($"You harvested {selectedCrop.Name}!");
                    player.Inventory.AddItem(new Item(selectedCrop.Name, 1));
                    Crops.Remove(selectedCrop);  // Remove the harvested crop
                }
                else
                {
                    Console.WriteLine($"{selectedCrop.Name} is not yet mature.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        // Show all crops in the garden
        public void ShowCrops()
        {
            if (Crops.Count == 0)
            {
                Console.WriteLine("No crops in the garden.");
            }
            else
            {
                foreach (var crop in Crops)
                {
                    Console.WriteLine($"Crop: {crop.Name}, Stage: {crop.Stage}");
                }
            }
        }
    }
}


