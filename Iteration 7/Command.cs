using System;
using System.Numerics;
using Swin_Adventure;
using SwinAdventure;

namespace Iteration_7._1
{
    
    public abstract class Command : IdentifiableObject  // Inheritance: Command inherits from IdentifiableObject
    {

        public Command(string[] ids) : base(ids)  // Inheritance: Calling the constructor of IdentifiableObject (parent class)
        {
        }

        // Abstract method that must be implemented by any derived class
        // The derived class will specify the behavior of this command
        public abstract string Execute(Player p, string[] text);
    }
}

