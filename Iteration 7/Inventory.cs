using System;
namespace Iteration_7._1
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }
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
        public void Put(Item item)
        {
            _items.Add(item);
        }
        public Item Take(string id)
        {
            Item item = Fetch(id);
            if (item == null)
            {
                _items.Remove(item);
            }
            return item;

        }

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
        public string ItemList
        {
            get
            {
                string itemList = "";
                foreach (Item item in _items)
                {
                    itemList += $"  {item.ShortDescription}\n";
                }
                return itemList;
            }
        }
    }
}


