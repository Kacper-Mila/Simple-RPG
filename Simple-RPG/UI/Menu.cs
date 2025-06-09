using Simple_RPG.Entities;

namespace Simple_RPG.UI;

public class Menu
{
    public static void DisplayTitle()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
   _____ _                 _          _____  _____   _____ 
  / ____(_)               | |        |  __ \|  __ \ / ____|
 | (___  _ _ __ ___  _ __ | | ___    | |__) | |__) | |  __ 
  \___ \| | '_ ` _ \| '_ \| |/ _ \   |  _  /|  ___/| | |_ |
  ____) | | | | | | | |_) | |  __/   | | \ \| |    | |__| |
 |_____/|_|_| |_| |_| .__/|_|\___|   |_|  \_\_|     \_____|
                    | |                                    
                    |_|                                    
");
        Console.ResetColor();
        Console.WriteLine("\nWelcome to the Simple RPG Game!\n");
    }

    public static string GetPlayerName()
    {
        DisplayTitle();
        Console.WriteLine("Before you start your adventure, tell me your name:");
        Console.Write("> ");
        
        string name;
        do
        {
            name = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(name))
                Console.Write("Your name cannot be empty. Please enter a valid name: ");
        } while (string.IsNullOrEmpty(name));
        
        return name;
    }

    public static PlayerEntity CreateNewPlayer()
    {
        string name = GetPlayerName();
        var player = new PlayerEntity(
            name,
            hp: 100, 
            attackPower: (Min: 5, Max: 10)
        );
        
        Console.Clear();
        Console.WriteLine($"Welcome, {player.Name}! Your adventure begins now...");
        Console.WriteLine("\nPress any key to start.");
        Console.ReadKey(true);
        
        return player;
    }
}