using System;
using Village;
namespace Village
{
    public class Game
    {
        private Player player;
        private Forest forest;
        private Village village;

        public Game()
        {
            player = new Player();  // Initialize the Player
            forest = new Forest();
            village = new Village();
        }

        public void Start()
        {
            // Ask the player to input their name at the start
            Console.WriteLine("Welcome to Village Boss! Please enter your name:");
            player.Name = Console.ReadLine();

            Console.WriteLine($"\nHello, {player.Name}! Let's begin the adventure.");
            player.Health = 100;
            player.Money = 100;  // Starting money
            player.Location = "Home";  // Initial location

            while (true)
            {
                // Display player information at the top of the screen
                DisplayPlayerInfo();

                Console.WriteLine("\nChoose your action:");
                Console.WriteLine("1. Go to Home");
                Console.WriteLine("2. Go to Garden");
                Console.WriteLine("3. Go to Forest");
                Console.WriteLine("4. Go to Village");
                Console.WriteLine("5. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Home();
                        break;
                    case "2":
                        Garden();
                        break;
                    case "3":
                        Forest();
                        break;
                    case "4":
                        Village();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void DisplayPlayerInfo()
        {
            Console.Clear(); // Clear the screen before displaying player info
            Console.WriteLine("===== Player Information =====");
            Console.WriteLine($"Name: {player.Name} | Health: {player.Health} | Money: {player.Money} | Location: {player.Location}");
            Console.WriteLine("Inventory:");
            player.ShowInventory();
            Console.WriteLine("==============================");
        }

        private void Home()
        {
            player.Location = "Home";
            Console.WriteLine("\nYou are at home.");
        }

        private void Garden()
        {
            player.Location = "Garden";
            Console.WriteLine("\nYou are in the garden. Here are your crops:");

            while (true)
            {
                player.Garden.ShowCrops(); // Display the crops in the garden

                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Plant Crop");
                Console.WriteLine("2. Water Crops");
                Console.WriteLine("3. Check Crop Stages");
                Console.WriteLine("4. Harvest Crops");
                Console.WriteLine("5. Return to Home");

                string gardenChoice = Console.ReadLine();
                switch (gardenChoice)
                {
                    case "1":
                        player.Garden.PlantCrop(player);
                        break;
                    case "2":
                        player.Garden.WaterCrops(player);
                        break;
                    case "3":
                        player.Garden.CheckCropStage(player);
                        break;
                    case "4":
                        player.Garden.HarvestCrop(player);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void Forest()
        {
            player.Location = "Forest";
            Console.WriteLine("\nYou are in the forest.");

            // Random animal encounter every time the player enters the forest
            forest.RandomAnimalEncounter(player);

            Console.WriteLine("\nYou can choose to:");
            Console.WriteLine("1. Collect Wood");
            Console.WriteLine("2. Search for a Mystery Box");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                forest.CollectWood(player);
            }
            else if (choice == "2")
            {
                forest.FindMysteryBox(player);
            }
            else
            {
                Console.WriteLine("Invalid choice. You decide to leave the forest.");
            }
        }

        private void Village()
        {
            player.Location = "Village";
            village.Trade(player);
        }
    }
}


