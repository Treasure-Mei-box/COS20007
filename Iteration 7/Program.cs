using System;

namespace Iteration_7._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name;
            string description;
            Player player;
            Locations locations;


            Console.WriteLine("Welcome to Swin Adventure!");
            Console.WriteLine("Enter Player Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Player's Description: ");
            description = Console.ReadLine();
            player = new Player(name, description);


            Item sword = new(new string[] { "sword", "bronze" }, "a bronze Sword", "A sharp sword.");
            Item shovel = new(new string[] { "shovel", "metal" }, "a metal Shovel", "A heavy shovel.");
        
            player.Inventory.Put(sword);
            player.Inventory.Put(shovel);


            Bag bag = new Bag(new string[] { "bag" }, "bag", "This is a cloth bag.");
            player.Inventory.Put(bag);

            Item diamond = new Item(new string[] { "diamond" }, "diamonds", " This is my diamond.");
            bag.inventory.Put(diamond);

            Item chair = new Item(new string[] { "chair " }, "chair ", " This is a wooden chair.");
            Locations mylodge = new Locations(new string[] { "mylodge" }, "mylodge", "My Lodge");
            mylodge.inventory.Put(chair);
            player.Locations = mylodge;

            Item snake = new Item(new string[] { "snake" }, "snake", " A small but poisonous snake.");
            Locations dessert = new Locations(new string[] { "dessert " }, "dessert ", "A hot and dry dessert");
            dessert.inventory.Put(snake);

            Locations jungle = new Locations(new string[] { " jungle" }, " jungle", "A dark jungle");
            Item gem = new Item(new string[] { " gem" }, " gem", " Hidden gem can be found.");
            jungle.inventory.Put(gem);

            Locations garden = new Locations(new string[] { " garden" }, " garden", "A harvestable garden");
            Item crop = new Item(new string[] { "crop" }, " crop", "Harvestable crops");
            garden.inventory.Put(crop);

            Path lodgeTogarden = new Path(new string[] { "east", "e" }, "Door to Garden","Travel to garden", garden);
            Path gardenToLodge = new Path(new string[] { "west", "w" }, "Door to Lodge","Travel to Lodge", mylodge);
            Path jungleTogarden = new Path(new string[] { "north", "n" }, "Path to Garden", "Travel back to garden", garden);
            Path gardenToJungle = new Path(new string[] { "south", "s" }, "Path to Jungle", "Travel to Jungle" , jungle);
            Path lodgeToJungle = new Path(new string[] { "west", "w" }, "Path to Jungle", "Travel to path" , jungle);
            Path jungleTodessert = new Path(new string[] { "south", "s" }, "Path to Desert", "Travel to dessert" , dessert);
            Path desertToJungle = new Path(new string[] { "north", "n" }, "Path to Jungle", "Travel to dessert", jungle); // Reverse path

            // Add paths to locations 
            mylodge.AddPath(lodgeTogarden);  // Lodge to Garden (East)
            garden.AddPath(gardenToLodge);   // Garden to Lodge (West)
            jungle.AddPath(jungleTogarden);  // Jungle to Garden (North)
            garden.AddPath(gardenToJungle);  // Garden to Jungle (South)
            mylodge.AddPath(lodgeToJungle);  // Lodge to Jungle (West)
            jungle.AddPath(jungleTodessert);  // Jungle to Desert (South)
            dessert.AddPath(desertToJungle);  // Desert to Jungle (North)

            bool quit = false;
            string command;
            LookCommand look = new LookCommand();
            MoveCommand move = new MoveCommand(new string[] { "move", "go", "leave", "head" });

            while (!quit)
            {
                Console.WriteLine("Enter a command: ");
                command = Console.ReadLine();

                if (command == "quit")
                {
                    quit = true;
                }
                else if (command.StartsWith("move") || command.StartsWith("go") || command.StartsWith("leave") || command.StartsWith("head"))
                {
                    Console.WriteLine(move.Execute(player, command.Split(" ")));
                }
                else
                {
                    Console.WriteLine(look.Execute(player, command.Split(" ")));
                }
            }
        }
    }
}


