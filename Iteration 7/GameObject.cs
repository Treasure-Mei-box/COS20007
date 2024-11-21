using System;
using Swin_Adventure;

namespace Iteration_7._1
{
    // The GameObject class represents an object in the game with a name, description, and identifiers.
    // It inherits from IdentifiableObject, allowing it to store multiple IDs.
    public class GameObject : IdentifiableObject
    {
        // Private fields for the description and name of the GameObject.
        private string _description;
        private string _name;

        // Constructor that initializes the GameObject with identifiers (IDs), a name, and a description.
        // The base constructor (from IdentifiableObject) is called to set the IDs.
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _description = desc;
            _name = name;
        }

        // Property to access the name of the GameObject.
        public string Name
        {
            get
            {
                return _name;
            }
        }

        // Property to get a short description of the GameObject, consisting of its name and first identifier (ID).
        public virtual string ShortDescription
        {
            get
            {
                return $"{_name} ({FirstID})"; // Format name with the first ID.
            }
        }

        // Virtual property to allow derived classes to override the full description.
        // By default, it returns the GameObject's description.
        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }

    }
}
