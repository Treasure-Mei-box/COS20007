using System;
using System.Xml.Linq;

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
            if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else if (AreYou(id))
            {
                return this;
            }
            else return null;
        }
        public override string FullDescription
        {
            get
            {
                return $"In the {Name} you can see:\n{inventory.ItemList}";
            }

        }

        public Inventory inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
