using System;
using Iteration_7._1;
using Swin_Adventure;
using SwinAdventure;

namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        // Constructor to initialize the LookCommand with the keyword "look"
        public LookCommand() : base(new string[] { "look" }) // Inheriting from Command class
        {
        }

        // Override Execute method to implement the behavior of the "look" command
        public override string Execute(Player p, string[] text)
        {


            // If the first word in the input is "inventory", return the player's full description (inventory in this case)
            if (text[0] == "inventory")
            {
                return $"\n{p.FullDescription}";
            }

            // If the player types "look" (no extra text), show the current location
            if (text.Length == 1 && text[0] == "look")
            {
                return p.Location.FullDescription;
            }

            // If the first word is not "look", return the custom error message
            if (text[0] != "look")
            {
                return "\nError in look input";
            }

            // Check the length of the command
            if (text.Length != 3 && text.Length != 5)
            {
                return "\nI don't know how to look like that";
            }

            // The second word must always be "at" to specify what the player is looking at
            if (text[1] != "at")
            {
                return "\nWhat do you want to look at?";
            }

            // If there are 5 words, the 4th word should be "in" (to indicate looking inside a container)
            if (text.Length == 5 && text[3] != "in")
            {
                return "\nWhat do you want to look in?";
            }

            IHaveInventory container;  // Association: LookCommand interacts with an IHaveInventory object
            string itemId = text[2];
            // If the command has 3 words, look at an item in the player's inventory (Association: Player has Inventory)
            if (text.Length == 3)
            {
                container = p as IHaveInventory;  // Player is considered as an IHaveInventory (Aggregation)
                if (container == null)
                {
                    return "\nYou don't have any inventory to look in.";
                }

                // Look at the item inside the container
                return LookAtIn(itemId, container);
            }

            // If the command has 5 words, the player is looking at an item inside another container
            if (text.Length == 5)
            {
                string containerId = text[4];  // The 5th word represents the container (aggregation relationship)
                container = FetchContainer(p, containerId);  // Fetch the container, which may or may not be a part of the player's inventory
                if (container == null)
                {
                    return $"\nI cannot find the {containerId}";
                }

                // Look at the item inside the container
                return LookAtIn(itemId, container);  // Composition: Item located inside a container and viewed by the player
            }

            // Return a generic error message if none of the conditions above match
            return "\nInvalid look command format.";
        }

        //  Function to fetch a container (either the player or another object)
        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            // If the player is the container (i.e., the player is the one being looked at), return the player object
            if (p.AreYou(containerId))
            {
                return p;
            }

            // Try to locate another container object by its ID (e.g., a bag or chest)
            GameObject obj = p.Locate(containerId);
            return obj as IHaveInventory;
        }

        // Function to look at an item inside a container (player's inventory or other container)
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            // Locate the item inside the container by its ID
            var item = container.Locate(thingId);  // Association: Container has a list of items, and we try to locate one

            // If the item is not found, return an error message
            if (item == null)
            {
                return $"\nI cannot find the {thingId}";
            }

            return $"\n{item.FullDescription}";
        }
    }
}





