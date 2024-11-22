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

        // Find a mystery box in the forest
        public void FindMysteryBox(Player player)
        {
            int boxContent = random.Next(1, 4);  // 1 = Wood, 2 = Seeds, 3 = Coins

            switch (boxContent)
            {
                case 1:
                    int woodAmount = random.Next(5, 10);
                    Console.WriteLine($"You found a mystery box containing {woodAmount} wood!");
                    player.Inventory.AddItem(new Item("Wood", woodAmount));
                    break;
                case 2:
                    int seedAmount = random.Next(1, 5);
                    Console.WriteLine($"You found a mystery box containing {seedAmount} seeds!");
                    player.Inventory.AddItem(new Item("Seed", seedAmount));
                    break;
                case 3:
                    int coinAmount = random.Next(10, 50);
                    Console.WriteLine($"You found a mystery box containing {coinAmount} coins!");
                    player.Money += coinAmount;
                    break;
                default:
                    Console.WriteLine("You found nothing in the mystery box.");
                    break;
            }
        }

        // Random animal encounter in the forest
        public void RandomAnimalEncounter(Player player)
        {
            int encounterChance = random.Next(1, 11); // 1 in 10 chance of encountering an animal

            if (encounterChance <= 3) // 30% chance
            {
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
            else
            {
                Console.WriteLine("You did not encounter any animals.");
            }
        }
    }
}

