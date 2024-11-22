using System;
using Village;
namespace Village
{
    public class Inventory
    {
        public List<Item> Items { get; set; }

        public Inventory()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            var existingItem = Items.Find(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
    }
}