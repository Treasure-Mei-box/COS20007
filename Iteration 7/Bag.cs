using System;
using System.Xml.Linq;
using Swin_Adventure;

namespace Iteration_7._1
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
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
                return $"In the {this.Name} you can see:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}