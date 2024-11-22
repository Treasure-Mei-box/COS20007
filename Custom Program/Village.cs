using System;
using Village;
namespace Village
{
    public class Village
    {
        public void Trade(Player player)
        {
            Console.WriteLine("\nWelcome to the village shop!");
            Console.WriteLine("You can trade your crops for seeds or sell them for coins.");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Sell Crops");
            Console.WriteLine("2. Trade Crops for Seeds");
            Console.WriteLine("3. Exit Village");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SellCrops(player);
                    break;
                case "2":
                    TradeCropsForSeeds(player);
                    break;
                case "3":
                    Console.WriteLine("Leaving the village.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void SellCrops(Player player)
        {
            if (player.Inventory.Items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty! You have no crops to sell.");
                return;
            }

            Console.WriteLine("Which crop would you like to sell?");
            for (int i = 0; i < player.Inventory.Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.Inventory.Items[i].Name} x{player.Inventory.Items[i].Quantity}");
            }

            int cropChoice = int.Parse(Console.ReadLine()) - 1;
            if (cropChoice >= 0 && cropChoice < player.Inventory.Items.Count)
            {
                Item selectedItem = player.Inventory.Items[cropChoice];
                int sellAmount = selectedItem.Quantity * 2; // Sell for 2 coins per item
                Console.WriteLine($"You sold {selectedItem.Quantity} {selectedItem.Name} for {sellAmount} coins.");
                player.Money += sellAmount;
                player.Inventory.Items.RemoveAt(cropChoice);
            }
        }

        private void TradeCropsForSeeds(Player player)
        {
            if (player.Inventory.Items.Count == 0)
            {
                Console.WriteLine("You have no crops to trade.");
                return;
            }

            Console.WriteLine("Which crop would you like to trade for seeds?");
            for (int i = 0; i < player.Inventory.Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.Inventory.Items[i].Name} x{player.Inventory.Items[i].Quantity}");
            }

            int cropChoice = int.Parse(Console.ReadLine()) - 1;
            if (cropChoice >= 0 && cropChoice < player.Inventory.Items.Count)
            {
                Item selectedItem = player.Inventory.Items[cropChoice];
                int seedAmount = selectedItem.Quantity / 2;  // For every 2 crops, the player gets 1 seed
                Console.WriteLine($"You traded {selectedItem.Quantity} {selectedItem.Name} for {seedAmount} seeds.");
                selectedItem.Quantity = 0;  // Remove the traded crop
                player.Inventory.AddItem(new Item("Seed", seedAmount));
            }
        }
    }
}

