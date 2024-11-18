using System;
using System.Numerics;

namespace Iteration_7._1
{
    public class Path : GameObject
    {
        private Locations _locations;
        bool _locked;
        public Path(string[] idents, string name, string desc, Locations locations) : base(idents, name, desc)
        {
            _locations = locations;
        }

        public string Move(Player player)
        {
            if (Locations != null)
            {
                player.Locations = Locations;
                return $"You have moved to {Locations.Name}";
            }
            return "The path lead to nowhere.";
        }

        public Locations Locations
        {
            get
            {
                return _locations;
            }
        }


    }
}
