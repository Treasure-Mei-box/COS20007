using System;
using System.Numerics;
using Iteration_7._1;
using SwinAdventure;

namespace Swin_Adventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            // If no direction is specified, show available paths
            if (text.Length < 2)
            {
                return $"\nMove where? Available paths: {player.Location.PathList}";
            }

            // Get the direction or location the player wants to move to
            string directionOrLocation = text[1];

            // Attempt to locate the path by either direction or location name
            GamePath path = player.Location.Locate(directionOrLocation) as GamePath;

            // If path doesn't exist or player is in wrong location, return an error
            if (path == null)
            {
                return $"\nThere is no path in that direction. \n{player.Location.PathList}";
            }

            // Move the player and return the result
            return $"\n{path.Move(player)}";
        }
    }
}




