using System;
using Village;
namespace Village
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Money { get; set; }
        public string Location { get; set; }
        public Inventory Inventory { get; set; }
        public Garden Garden { get; set; }  // Adding the Garden property

        public Player()
        {
            Inventory = new Inventory();
            Garden = new Garden();  // Initialize Garden
        }

        // This will display the inventory items
        public void ShowInventory()
        {
            if (Inventory.Items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                foreach (var item in Inventory.Items)
                {
                    Console.WriteLine($"{item.Name} x{item.Quantity}");
                }
            }
        }
    }
}


