using System;
using Village;

namespace Village
{
    public class Forest
    {
        private Random random = new Random();

        // Collect wood from the forest
        public void CollectWood(Player player)
        {
            int woodAmount = random.Next(5, 15);
            Console.WriteLine($"You collected {woodAmount} wood.");
            player.Inventory.AddItem(new Item("Wood", woodAmount));
        }

        // Find a mystery box in the forest with multiple items
        public void FindMysteryBox(Player player)
        {
            int numItems = random.Next(1, 4);  // Number of items in the mystery box (1 to 3 items)
            Console.WriteLine("You found a mystery box! It contains:");

            for (int i = 0; i < numItems; i++)
            {
                int boxContent = random.Next(1, 6);  // 1-5 = Wood, Seeds, Coins, Food, or Tools

                switch (boxContent)
                {
                    case 1:
                        int woodAmount = random.Next(5, 10);
                        Console.WriteLine($"- {woodAmount} wood!");
                        player.Inventory.AddItem(new Item("Wood", woodAmount));
                        break;
                    case 2:
                        int seedAmount = random.Next(1, 5);
                        Console.WriteLine($"- {seedAmount} seeds!");
                        player.Inventory.AddItem(new Item("Seed", seedAmount));
                        break;
                    case 3:
                        int coinAmount = random.Next(10, 50);
                        Console.WriteLine($"- {coinAmount} coins!");
                        player.Money += coinAmount;
                        break;
                    case 4:
                        int foodAmount = random.Next(1, 3);
                        Console.WriteLine($"- {foodAmount} food items!");
                        player.Inventory.AddItem(new Item("Food", foodAmount));
                        break;
                    case 5:
                        Console.WriteLine("- A tool (Shovel)!");
                        player.Inventory.AddItem(new Item("Tool", 1));  // Assume 1 tool per box
                        break;
                    default:
                        Console.WriteLine("You found nothing in the mystery box.");
                        break;
                }
            }
        }

        // Random animal encounter in the forest
        public void RandomAnimalEncounter(Player player)
        {
            // Make sure we encounter an animal each time the player enters the forest
            Animal animal = new Animal(random.Next(1, 4)); // Random animal (Tiger, Bear, Snake)
            Console.WriteLine($"A wild {animal.Name} appears!");

            // Combat options: Fight or Run
            Console.WriteLine("You have two options:");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run");

            string combatChoice = Console.ReadLine();

            if (combatChoice == "1")
            {
                animal.Attack(player); // Animal attacks the player

                if (player.Health <= 0)
                {
                    Console.WriteLine("You were defeated by the animal!");
                    Environment.Exit(0); // End the game if the player dies
                }
            }
            else
            {
                Console.WriteLine("You ran away from the animal.");
            }
        }
    }
}
