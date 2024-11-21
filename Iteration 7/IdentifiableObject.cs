using System;
namespace Iteration_7._1
{
    public class IdentifiableObject
    {
        // a private field _identifiers, which is a List of strings.
        private List<string> _identifiers;

        // Constructor
        public IdentifiableObject(string[] idents)
        {
            // Initialize as new List
            _identifiers = new List<string>();
            foreach (string ident in idents)
            {
                _identifiers.Add(ident.ToLower());
            }
        }

        // Method
        public bool AreYou(string name)
        {
            foreach (string idents in _identifiers)
            {
                // Check 
                if (idents.ToLower() == name.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        // Property
        public string FirstID
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    // Return empty string if list is empty
                    return "";
                }
                else
                {
                    // Return the first element
                    return _identifiers.First();

                }
            }
        }

        // Method to convert to lowercase
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}


