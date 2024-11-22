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

                // Prompt the player for the quantity to sell
                Console.WriteLine($"You have {selectedItem.Quantity} {selectedItem.Name}. How many would you like to sell?");
                int sellAmount = int.Parse(Console.ReadLine());

                // Validate the quantity
                if (sellAmount > 0 && sellAmount <= selectedItem.Quantity)
                {
                    int coinsEarned = sellAmount * 2; // Sell for 2 coins per item
                    Console.WriteLine($"You sold {sellAmount} {selectedItem.Name} for {coinsEarned} coins.");
                    player.Money += coinsEarned;
                    selectedItem.Quantity -= sellAmount;

                    // If the quantity reaches 0, remove the item from the inventory
                    if (selectedItem.Quantity == 0)
                    {
                        player.Inventory.Items.RemoveAt(cropChoice);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid crop choice.");
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

                // Prompt the player for the quantity to trade
                Console.WriteLine($"You have {selectedItem.Quantity} {selectedItem.Name}. How many would you like to trade for seeds?");
                int tradeAmount = int.Parse(Console.ReadLine());

                // Validate the quantity
                if (tradeAmount > 0 && tradeAmount <= selectedItem.Quantity)
                {
                    int seedAmount = tradeAmount / 2;  // For every 2 crops, the player gets 1 seed
                    Console.WriteLine($"You traded {tradeAmount} {selectedItem.Name} for {seedAmount} seeds.");
                    selectedItem.Quantity -= tradeAmount;

                    // If the quantity reaches 0, remove the item from the inventory
                    if (selectedItem.Quantity == 0)
                    {
                        player.Inventory.Items.RemoveAt(cropChoice);
                    }

                    player.Inventory.AddItem(new Item("Seed", seedAmount));
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid crop choice.");
            }
        }
    }
}
