using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swin_Advanture;

namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        public LookCommand() :
            base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container;
            string _itemid;
            string error = "I don't know how to look like that.";

            if (text[0].ToLower() != "look")
                return error;

            switch (text.Length)
            {
                case 1:
                    _container = p;
                    _itemid = "location";
                    break;

                case 3:
                    if (text[1].ToLower() != "at")
                        return "What do you want to look at?";
                    _container = p;
                    _itemid = text[2];
                    break;

                case 5:
                    _container = FetchContainer(p, text[4]);
                    if (_container == null)
                        return "Could not find " + text[4];
                    _itemid = text[2];
                    break;

                default:
                    return error;
            }
            return LookAtIn(_itemid, _container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
                return container.Locate(thingId).FullDescription;

            return "Couldn't find " + thingId;
        }
    }
}