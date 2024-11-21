using System;
using System.Collections.Generic;
using Swin_Adventure;
using System.Xml.Linq;
using Iteration_7._1;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<GamePath> _paths;

        public Location(string name, string desc) : base(new string[] { name }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<GamePath>();
        }

        public GameObject Locate(string id)
        {
            // Check if the current location matches the ID
            if (AreYou(id))
            {
                return this;
            }

            // Check for a path that matches the direction or destination name
            foreach (GamePath p in _paths)
            {
                // Match direction (FirstID) or destination name
                if (p.FirstID.Equals(id, StringComparison.OrdinalIgnoreCase) ||
                    p.Destination.Name.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    return p;
                }
            }

            // If no path matches, check the inventory
            return _inventory.Fetch(id);
        }


        public string PathList
        {
            get
            {
                if (_paths.Count == 0)
                {
                    return "There are no available paths.\n";
                }

                string list = "Available paths: ";

                for (int i = 0; i < _paths.Count; i++)
                {
                    // Use FirstID for direction and Destination.Name for the name of the destination
                    if (i == _paths.Count - 1)
                    {
                        list += _paths[i].FirstID + " (" + _paths[i].Destination.Name + ").";
                    }
                    else
                    {
                        list += _paths[i].FirstID + " (" + _paths[i].Destination.Name + "), ";
                    }
                }

                return list;
            }
        }


        public override string ShortDescription
        {
            get
            {
                return " " + base.FullDescription;
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"\nYou are in {Name}.\n{base.FullDescription}\nIn this place you can see:\n{_inventory.ItemList}\n{PathList}";
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
        }

        // Method to add a path to this location
        public void AddPath(GamePath path)
        {
            _paths.Add(path);
        }

    }
}




