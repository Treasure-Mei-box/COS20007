using System;
namespace Iteration_7._1
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Locations _locations;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();

        }
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
            else if (_locations != null)
            {
                return _locations.Locate(id);
            }
            else
            {
                return null;
            }


            //return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return $"You are {Name},{base.FullDescription}\nYou are carrying:\n" + _inventory.ItemList;
            }
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public Locations Locations
        {
            get
            {
                return _locations;
            }
            set
            {
                _locations = value;
            }
        }
    }
}


