using System;
using Village;
namespace Village
{
    public class Animal
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Animal(int type)
        {
            switch (type)
            {
                case 1:
                    Name = "Tiger";
                    Health = 50;
                    break;
                case 2:
                    Name = "Bear";
                    Health = 60;
                    break;
                case 3:
                    Name = "Snake";
                    Health = 30;
                    break;
                default:
                    Name = "Unknown";
                    Health = 0;
                    break;
            }
        }

        // Simulate an animal attack on the player
        public void Attack(Player player)
        {
            Random rand = new Random();
            int damage = rand.Next(5, 15);
            player.Health -= damage;
            Console.WriteLine($"{Name} attacks you for {damage} damage.");
        }
    }
}

