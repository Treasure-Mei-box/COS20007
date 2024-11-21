using System;
using Swin_Adventure;

namespace Iteration_7._1
{
    public class Inventory
    {
        // A private list to store the items in the inventory.
        private List<Item> _items;

        // Constructor initializes the inventory with an empty list of items.
        public Inventory()
        {
            _items = new List<Item>();
        }

        // Checks if an item with the specified ID exists in the inventory.
        public bool HasItem(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        // Adds an item to the inventory.
        public void Put(Item i)
        {
            _items.Add(i);
        }

        // Removes and returns an item from the inventory based on the specified ID.
        public Item Take(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id))
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }

        // Returns an item based on the specified ID without removing it from the inventory.
        public Item Fetch(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        // Property that returns a string listing all items in the inventory.
        public string ItemList
        {
            get
            {
                // If the inventory is empty, return "(nothing)"
                if (_items.Count == 0)
                {
                    return "(nothing)";
                }

                // Join all items into a formatted string
                return string.Join("\n", _items.Select(item => $" {item.Name} ({item.FirstID})"));
            }
        }
    }
}


