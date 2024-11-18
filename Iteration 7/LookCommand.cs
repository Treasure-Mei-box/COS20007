using System;
using System.Numerics;

namespace Iteration_7._1
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container;
            string itemId;
            string itemString;

            if (text.Length != 1 && text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            else
            {
                if (text[0] != "look" && text[0] != "move")
                {
                    return "Error in look input";
                }
                else if (text.Length != 1 && text[1] != "at")
                {
                    return "What do you want to look at?";
                }
                if (text.Length == 5 && text[3] != "in")
                {
                    return "What do you wan to look in?";
                }
                if (text.Length == 1 && text[0] == "look")
                {
                    itemString = p.Locations.FullDescription;
                    return itemString;
                }
                else if (text.Length == 3)
                {
                    container = p;
                    itemId = text[2];
                }

                else
                {
                    container = FetchContainer(p, text[4]);
                    itemId = text[2];

                    if (container == null)
                    {
                        return "I can't find the " + text[4];
                    }
                }
                // itemId = text[2];

                if (container != null)
                {
                    return LookAtIn(itemId, container);
                }
            }
            return "I couldn't process your request.";
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject thing = container.Locate(thingId);
            if (thing == null)
            {
                return "I can't find the " + thingId;
            }
            else
            {
                return thing.FullDescription;
            }
        }

    }
}


