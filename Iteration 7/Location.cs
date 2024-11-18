using System;
namespace Iteration_7._1
{
    public class Locations : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        List<Path> _path = new List<Path>();
        public Locations(string[] idents, string name, string description) : base(new string[] { "room", "here" }, name, description)
        {
            _inventory = new Inventory();
        }

        public void AddPath(Path path)
        {
            _path.Add(path);
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
            /*  else if (_path.Count >= 1)
              {
                  foreach (Path path in _path)
                  {
                      if (path.AreYou(id))
                      {
                          return path;
                      }
                  }
                  return null;
              }
              else
              {
                  return _inventory.Fetch(id);
              }*/
        }

        public Path? GetPath(string direction)
        {
            foreach (Path path in _path)
            {
                if (path.AreYou(direction))
                {
                    return path;
                }
            }
            return null;
        }
        public override string FullDescription
        {
            get
            {
                return $"You are in {Name} {base.FullDescription}\n In this room you can see:\n" + _inventory.ItemList;
            }
        }
        public Inventory inventory
        {
            get
            {
                return _inventory;
            }
        }
        public Item FetchItem(string id)
        {
            return _inventory.Fetch(id);
        }
    }
}


