using Simple_RPG.Entities;

namespace Simple_RPG.UI;

public class Menu
{
    private const int BoxWidth = 60;

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
        
        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent("Welcome to the Simple RPG Game!", centered: true);
        DrawBoxLine("╚", "═", "╝");
        Console.WriteLine();
    }

    public static string GetPlayerName()
    {
        DisplayTitle();
        
        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent("Before you start your adventure, tell me your name:", centered: true);
        DrawBoxLine("╚", "═", "╝");
        
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
        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent($"Welcome, {player.Name}!", centered: true);
        DrawBoxContent("Your adventure begins now...", centered: true);
        DrawBoxLine("╚", "═", "╝");
        
        Console.WriteLine("\nPress any key to start.");
        Console.ReadKey(true);
        
        return player;
    }
    
    // Helper methods for consistent UI drawing
    private static void DrawBoxLine(string left, string middle, string right)
    {
        Console.Write(left);
        Console.Write(new string(middle[0], BoxWidth - 2));
        Console.WriteLine(right);
    }

    private static void DrawBoxContent(string content, bool centered = false)
    {
        Console.Write("║ ");
        
        int contentMaxLength = BoxWidth - 4; // Available space for content

        if (centered)
        {
            // Make sure content isn't too long for centering
            if (content.Length > contentMaxLength)
            {
                content = content.Substring(0, contentMaxLength);
            }
            
            int padding = Math.Max(0, (contentMaxLength - content.Length) / 2);
            Console.Write(new string(' ', padding));
            Console.Write(content);

            // Calculate remaining space (accounting for odd length strings)
            int remainingSpace = Math.Max(0, contentMaxLength - content.Length - padding);
            Console.Write(new string(' ', remainingSpace));
        }
        else
        {
            // Left-aligned with padding for right edge
            if (content.Length > contentMaxLength)
            {
                // Truncate long text
                Console.Write(content.Substring(0, contentMaxLength));
            }
            else
            {
                Console.Write(content);
                Console.Write(new string(' ', contentMaxLength - content.Length));
            }
        }

        Console.WriteLine(" ║");
    }
}