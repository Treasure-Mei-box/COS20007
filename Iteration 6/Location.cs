using System;
using System.Xml.Linq;
using Swin_Adventure;

namespace Swin_Advanture
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        public Location(string name, string desc) : base(new string[]
        { "location" , name}, name, desc)
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
            else
            {
                return null;
            }
        }
        public override string FullDescription
        {
            get
            {
                return $"\nYou are at {Name}.\nItems at this location:\n{Inventory.ItemList}";
            }
        }
        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}
