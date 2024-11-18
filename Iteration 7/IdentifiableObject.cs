using System;
namespace Iteration_7._1
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (string ident in idents)
            {
                _identifiers.Add(ident.ToLower());
            }
        }
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                // return _identifiers.First();
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

    }
}


