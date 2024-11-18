using System;
namespace Iteration_7._1
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id);

        public string Name
        {
            get;
        }

    }
}
