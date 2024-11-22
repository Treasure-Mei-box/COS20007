using System;
using Village;
namespace Village
{
    public class Crop
    {
        public string Name { get; set; }
        public string Stage { get; set; }

        // Constructor that accepts both Name and Stage
        public Crop(string name, string stage)
        {
            Name = name;
            Stage = stage;
        }
    }
  }

