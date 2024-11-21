using System;
using Iteration_7._1;
using Swin_Adventure;
using SwinAdventure;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Greeting and Player Creation
            Console.WriteLine("Welcome to SwinAdventure!");

            // Player's name
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "NewPlayer";
            }

            // Player's description
            Console.Write("Enter a description for your player: ");
            string playerDescription = Console.ReadLine();
            if (string.IsNullOrEmpty(playerDescription))
            {
                playerDescription = "No description provided.";
            }

            // Create Locations
            Location mylodge = new Location("mylodge", "My cozy Lodge.");
            Location dessert = new Location("dessert ", "A hot and dry dessert.");
            Location jungle = new Location(" jungle", "A dark jungle.");

            // Create paths between locations
            GamePath mylodgetojungle = new GamePath(new string[] { "north", "jungle" }, "A Cozy lodge with minimalist style", "A dark and cool jungle where plenty of tall trees ", mylodge, jungle);
            GamePath jungletodessert = new GamePath(new string[] { "south", "dessert" }, "A dark and cool jungle where plenty of tall trees", "A very hot and dry dessert.", jungle, dessert);
            GamePath mylodgetodessert = new GamePath(new string[] { "east", "dessert" }, "A Cozy lodge with minimalist style", "A very hot and dry dessert..", mylodge, dessert);
            GamePath dessertomylodge = new GamePath(new string[] { "west", "mylodge" }, "A very hot and dry dessert..", "A Cozy lodge with minimalist style", dessert, mylodge);


            // Add items to locations
            Item chair = new Item(new string[] { "chair" }, "a wooden chair", "A big wooden chair even suitable for sleeping");
            Item snake = new Item(new string[] { "snake" }, "a snake", "A small green snake but poisonous.");
            Item gem = new Item(new string[] { "gem" }, "a gem", "A shiny gem can be found if you are lucky");

            // Add items to the appropriate locations
            mylodge.Inventory.Put(chair);
            dessert.Inventory.Put(snake);
            jungle.Inventory.Put(gem);

            // Create and add player's initial items
            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "A rusty shovel with a worn handle.");
            Item sword = new Item(new string[] { "sword" }, "a bronze sword", "A finely crafted steel sword with an ornate hilt.");

            // Create Player
            Player player = new Player(playerName, playerDescription);

            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);

            // Create and add bag
            Bag bag = new Bag(new string[] { "bag" }, "a cloth bag", "A small brown cloth bag.");
            player.Inventory.Put(bag);
            Item bottle = new Item(new string[] { "bottle" }, "a small water bottle", "A small water bottle with full of water");
            bag.Inventory.Put(bottle);

            // Set initial location
            player.Location = mylodge;

            // Create command
            LookCommand lookCommand = new LookCommand();
            MoveCommand moveCommand = new MoveCommand();


            // Display initial state and commands
            Console.WriteLine("\nGame started!");
            Console.WriteLine("Available commands:");
            Console.WriteLine("- 'look' : Look around your current location");
            Console.WriteLine("- 'look at [item]' : Examine an item");
            Console.WriteLine("- 'look at [item] in [container]' : Look at an item in a container");
            Console.WriteLine("- 'inventory' : Check your inventory");
            Console.WriteLine("\nMovement commands:");
            Console.WriteLine("Use any of the following to move in a specific direction:");
            Console.WriteLine("- 'move [direction]'");
            Console.WriteLine("- 'go [direction]'");
            Console.WriteLine("- 'head [direction]'");
            Console.WriteLine("Example: 'move jungle', 'go dessery', 'head mylodge'.");
            Console.WriteLine("- 'quit' or 'exit' : Exit the game");

            Console.WriteLine($"{player.Location.FullDescription}");
            Console.WriteLine("What would you like to do?");


            while (true)
            {
                Console.Write("Enter command: ");
                string input = Console.ReadLine().ToLower();

                // Exit the game if the input is empty or "quit"
                if (string.IsNullOrEmpty(input) || input == "quit" || input == "exit") break;

                string[] commandWords = input.Split(' ');
                string keyword = commandWords[0];

                // Use conditional statements to determine which command to execute
                if (keyword == "look" || keyword == "inventory")
                {
                    string result = lookCommand.Execute(player, commandWords);
                    Console.WriteLine(result);
                }
                else if (keyword == "move" || keyword == "go" || keyword == "head")
                {
                    string result = moveCommand.Execute(player, commandWords);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("\nUnknown command. Valid options are 'look' or 'move', 'go', 'head'.");
                }
            }
            Console.WriteLine("\nThanks for playing SwinAdventure!");
        }
    }
}