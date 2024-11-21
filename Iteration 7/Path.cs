using Iteration_7._1;
using Swin_Adventure;

namespace SwinAdventure
{
    public class GamePath : GameObject
    {
        private Location _source;
        private Location _destination;
        private bool _isLocked;

        public GamePath(string[] ids, string name, string description, Location source, Location destination, bool isLocked = false) : base(ids, name, description)
        {
            _source = source;
            _destination = destination;
            _isLocked = isLocked;

            AddIdentifier(destination.Name);

            _source.AddPath(this);
        }


        public Location Destination => _destination;
        public Location Source => _source;

        public bool IsLocked
        {
            get => _isLocked;
            set => _isLocked = value;
        }

        // Method to move player through the path
        public string Move(Player player)
        {
            if (_isLocked)
            {
                return "This path is locked. You cannot go that way.";
            }

            if (player.Location != _source)
            {
                return "You cannot go that way from here.";
            }

            player.Location = _destination;
            return $"You move {FirstID} to {_destination.Name}." + _destination.FullDescription;
        }
    }
}




