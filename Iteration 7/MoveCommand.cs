using System;
using System.Numerics;

namespace Iteration_7._1
{
    public class MoveCommand : Command
    {
        /* public Move() : base(new string[] { "leave", "head", "go", "move" })
         {
         }
        */
        public MoveCommand(string[] ids) : base(ids)
        {
            AddIdentifier("move");
            AddIdentifier("go");
            AddIdentifier("leave");
            AddIdentifier("head");
        }
        public override string Execute(Player player, string[] text)
        {
            /*if (text.Length > 2)
            {
                return "How to move like that?";
            }
            else if (text[0] != "leave" && text[0] != "head" && text[0] != "go" && text[0] != "move")
            {
                return "Error!";
            }
            else if (text.Length == 1)
            {
                return "Where to move?";
            }
            else
            {
                string direction = text[1];
                if(player.Locate(direction) is Path p)
                {
                    player.Move_to_path(p);
                    return $"You head towards {p.Name}. You have arrived in {p.Locations.Name}";
                }
                return "Error!";
            }*/
            string message = "How to move like that?";
            string _moveDirection;

            switch (text.Length)
            {
                case 1:
                    return "Where do you want to move?";

                case 2:
                    _moveDirection = text[1].ToLower();
                    break;

                case 3:
                    _moveDirection = text[2].ToLower();
                    break;

                default:
                    return message;

            }
            if (!AreYou(text[0]))
            {
                return message;
            }

            GameObject? path = player.Locations.GetPath(_moveDirection);
            if (path != null)
            {
                try
                {
                    (path as Path).Move(player);
                }
                catch
                {
                    return $"Cannot find the {path.Name} ";
                }
                return $"You have moved to the {player.Locations.Name}.\n " + player.Locations.FullDescription;
            }
            else
            {
                return message;
            }
        }
    }
}


