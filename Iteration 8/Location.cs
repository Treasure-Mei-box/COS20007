using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Locations : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Dictionary<string, Paths> _paths;

        // Constructor
        public Locations(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new Dictionary<string, Paths>();
        }

        // Locate method to find objects by id
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else
            {
                return null;
            }
        }

        // Full description for location including items and paths
        public override string FullDescription
        {
            get
            {
                string result = "You are in " + Name + ", " + base.FullDescription + ".";
                result += "\nItems in this place: " + _inventory.ItemList();

                if (_paths.Count > 0)
                {
                    result += "\nAvailable Paths:";
                    foreach (Paths p in _paths.Values)
                    {
                        result += $"\t{p.Direction} - {p.Destination.Name}\n";
                    }
                }

                return result;
            }
        }

        // Inventory property
        public Inventory Inventory => _inventory;

        // Method to add paths to the location
        public void AddPath(Paths path)
        {
            _paths[path.Direction] = path;
        }

        // Method to get a specific path by direction
        public Paths GetPath(string direction)
        {
            if (_paths.ContainsKey(direction))
            {
                return _paths[direction];
            }
            else
            {
                return null;
            }
        }
    }
}
