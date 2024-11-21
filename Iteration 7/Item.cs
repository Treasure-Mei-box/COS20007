using System;
namespace Iteration_7._1
{
    public class Item : GameObject
    {
        // Constructor to initialize an Item object.
        // Calls the base class constructor to initialize the identifiers, name, and description.
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            // The constructor doesn't need to add anything extra for now, 
            // as all relevant properties are initialized via the base class.
        }
    }
}
