using System;
namespace Iteration_7._1
{
    // Interface that represents objects that can "have an inventory"
    public interface IHaveInventory
    {
        // This method allows a container (such as a player or a bag) to locate an object by its ID
        // It is a form of aggregation because the container "holds" (aggregates) other objects, and we can search for them by ID
        public GameObject Locate(string id); // Aggregation: container holds GameObjects (items) 

        // Property to get the name of the container
        public string Name  // Composition: The container object owns its name as part of its identity
        {
            get;
        }
    }
}
