using Iteration_7._1;
using System.Xml.Linq;
using Swin_Adventure;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        // Private fields to store the player's inventory and location.
        private Inventory _inventory;
        private Location _location;

        // Constructor to initialize the Player with a name and description.
        // The base constructor (from GameObject) is called to set the identifiers, name, and description.
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }


        // Locate method tries to find an object based on its ID.
        // First checks if the player's ID matches,
        // Then checks the player's inventory,
        // Finally checks the player's location.
        public GameObject Locate(string id)
        {
            if (AreYou(id))  // Check if the ID matches the player.
            {
                return this;
            }

            GameObject obj = _inventory.Fetch(id); // Check inventory 
            if (obj != null)
            {
                return obj;
            }

            // If not found in inventory and player has a location, check location
            if (_location != null)
            {
                obj = _location.Locate(id);
                return obj;
            }
            else
            {
                return null;
            }
        }


        // Override the FullDescription property to include the player's inventory and location in the description.
        public override string FullDescription
        {
            get
            {
                return $"You are {Name} ({base.FullDescription}).\nYou are carrying:\n{_inventory.ItemList}\nYou are in {_location.Name}.\n{Location.PathList}";
            }
        }

        // Property to access the player's inventory.
        public Inventory Inventory
        {
            get => _inventory;
        }

        // Property to access the player's current location
        public Location Location
        {
            get => _location;
            set => _location = value;
        }


        // Method to look at the current location
        public string Look()
        {
            if (_location == null)
            {
                return "You are nowhere!\n";
            }

            return _location.FullDescription;
        }

    }
}


