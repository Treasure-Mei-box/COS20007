using System;
using System.Numerics;

namespace Iteration_7._1
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids)
        {
        }

        public abstract string Execute(Player p, string[] text);


    }
}

