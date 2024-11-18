using System;
using System.IO;
using System.Net.Http.Headers;
using System.Numerics;

namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Greeting + info
            string name, desc;
            string help = "-look\n\nGetting list of item:\n-look at me\n-look at bag\n\nGetting item description:\nlook at {item}\nlook at {item} in me\nlook at {item} in bag\n\n";
            Message greetings;
            greetings = new Message("Welcome to SwinAdventure\n\nHere are some helpful command:\n-look\n\nGetting list of item:\n-look at me\n-look at bag\n\nGetting item description:\nlook at {item}\nlook at {item} in me\nlook at {item} in bag");
            greetings.Print();
            Console.WriteLine("Press anything to continue...");
            Console.ReadLine();

            //Player setup
            Console.Write("\nSetting up player:\nPlayer Name: ");
            name = Console.ReadLine();
            Console.Write("Player Description: ");
            desc = Console.ReadLine();
            Player player = new Player(name, desc);

            // Create items
            Item sword = new(new string[] { "sword", "bronze" }, "a bronze Sword", "A sharp sword.");
            Item shovel = new(new string[] { "shovel", "metal" }, "a metal Shovel", "A heavy shovel.");
            Item gem = new(new string[] { "gem", "ruby" }, "a valuable gem", "A shiny gem.");
            Item diamond = new(new string[] { "diamond" }, "a big diamond", "A big shiny diamond");
            Item snake = new(new string[] { "snake" }, "a poisonous snake", "A small but poisonous snake");
            Item chair = new(new string[] { "chair" }, "a wooden chair", "A big wooden chair");

            // Create and setup bag
            Bags bag = new(new string[] { "bag", "cloth" }, "Backpack", "A cloth backpack.");
            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            player.Inventory.Put(bag);
            bag.Inventory.Put(diamond);

            // Create locations
            Locations lodge = new(new string[] { "lodge" }, "Cozy Lodge", "A cozy place to stay");
            Locations jungle = new(new string[] { "jungle" }, "Dangerous Jungle", "Hidden items are placed here");
            Locations desert = new(new string[] { "desert" }, "Dry Desert", "A deadly place for non-hunters");

            // Create paths with proper directions
            Paths northPath = new(new string[] { "north" }, "North Path", "A path leading north");
            Paths southPath = new(new string[] { "south" }, "South Path", "A path leading south");
            Paths eastPath = new(new string[] { "east" }, "East Path", "A path leading east");
            Paths westPath = new(new string[] { "west" }, "West Path", "A path leading west");

            // Set up path directions
            northPath.Direction = "north";
            southPath.Direction = "south";
            eastPath.Direction = "east";
            westPath.Direction = "west";

            // Connect locations through paths
            // From Jungle
            northPath.Destination = desert;  // Jungle to Desert (north)
            jungle.AddPath(northPath);

            eastPath.Destination = lodge;    // Jungle to Lodge (east)
            jungle.AddPath(eastPath);

            // From Desert
            southPath.Destination = jungle;  // Desert to Jungle (south)
            desert.AddPath(southPath);

            eastPath = new Paths(new string[] { "east" }, "East Path", "A path leading east");
            eastPath.Direction = "east";
            eastPath.Destination = lodge;    // Desert to Lodge (east)
            desert.AddPath(eastPath);

            // From Lodge
            westPath.Destination = jungle;   // Lodge to Jungle (west)
            lodge.AddPath(westPath);

            southPath = new Paths(new string[] { "south" }, "South Path", "A path leading south");
            southPath.Direction = "south";
            southPath.Destination = desert;  // Lodge to Desert (south)
            lodge.AddPath(southPath);

            // Set player's initial location and distribute items
            player.Location =lodge;
            lodge.Inventory.Put(chair);
            jungle.Inventory.Put(gem);
            desert.Inventory.Put(snake);
            desert.Inventory.Put(sword);  // Clone sword to avoid duplicate reference

            // Main game loop
            while (true)
            {
                Console.WriteLine("\nCommand: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    string[] execommand = input.ToLower().Split(' ');
                    if (execommand[0] == "quit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(new CommandProcessor().ExecuteCommand(player, execommand));
                    }
                }
            }
        }
    }
}