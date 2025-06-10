using Simple_RPG.Entities;

namespace Simple_RPG.UI;

public static class FightUI
{
    private const int BoxWidth = 50;

    public static void DrawFightStart(EnemyEntity enemy)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
  ______      _  _    _   _  _______
 |  ____|    (_)| |  | | | ||__   __|
 | |__ __ _   _ | |__| |_| |   | |
 |  __/ _` | | ||  __  |_  _|  | |
 | | | (_| | | || |  | | | |   | |
 |_|  \__, | |_||_|  |_| |_|   |_|
       __/ |
      |___/
");
        Console.ResetColor();

        Console.WriteLine($"\nA wild {enemy.Name} appears!");
        Console.WriteLine(enemy.AsciiArt);

        Console.WriteLine("\nPress any key to start the battle...");
        Console.ReadKey(true);
    }

    public static void DrawFightScene(PlayerEntity player, EnemyEntity enemy)
    {
        // Draw player info
        PlayerInfoUI.DisplayPlayerInfo(player);

        // Draw enemy
        Console.ForegroundColor = ConsoleColor.Red;
        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent($"{enemy.Name} - HP: {enemy.HP}/{enemy.MaxHP}");

        // Draw the ASCII art for the enemy
        string[] artLines = enemy.AsciiArt.Split('\n');
        foreach (string line in artLines)
        {
            if (!string.IsNullOrWhiteSpace(line))
                DrawBoxContent(line);
        }

        // Draw health bar for enemy
        Console.Write("║ Health: ");
        DrawHealthBar(enemy.HP, enemy.MaxHP, BoxWidth - 11);
        Console.WriteLine(" ║");

        DrawBoxLine("╚", "═", "╝");
        Console.ResetColor();
    }

    public static void DrawPlayerOptions()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent("YOUR TURN", centered: true);
        DrawBoxLine("╠", "═", "╣");
        DrawBoxContent("[A] Attack");
        DrawBoxContent("[H] Heal");
        DrawBoxLine("╚", "═", "╝");
        Console.ResetColor();

        Console.WriteLine("Choose your action: ");
    }

    public static void DrawVictory(EnemyEntity enemy)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
__   __  ___   _______  _______  _______  ______    __   __  __
|  | |  ||   | |       ||       ||       ||    _ |  |  | |  ||  |
|  |_|  ||   | |       ||_     _||   _   ||   | ||  |  |_|  ||  |
|       ||   | |       |  |   |  |  | |  ||   |_||_ |       ||  |
|       ||   | |      _|  |   |  |  |_|  ||    __  ||       ||__|
 |     | |   | |     |_   |   |  |       ||   |  | | |     |  __ 
  |___|  |___| |_______|  |___|  |_______||___|  |_|  |___|  |__|
");
        Console.ResetColor();

        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent($"You defeated the {enemy.Name}!", centered: true);
        DrawBoxLine("╚", "═", "╝");

        Console.WriteLine("\nPress any key to continue your adventure...");
        Console.ReadKey(true);
    }

    public static void DrawDefeat()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
   _____                         ____                 
  / ____|                       / __ \                
 | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ 
 | | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|
 | |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   
  \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   
");
        Console.ResetColor();

        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent("You have been defeated!", centered: true);
        DrawBoxLine("╚", "═", "╝");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);
    }

    private static void DrawHealthBar(int currentHP, int maxHP, int barLength)
    {
        int filledParts = (int)Math.Ceiling((double)currentHP / maxHP * barLength);

        Console.ForegroundColor = ConsoleColor.Green;
        if (currentHP < maxHP * 0.7 && currentHP >= maxHP * 0.4)
            Console.ForegroundColor = ConsoleColor.Yellow;
        else if (currentHP < maxHP * 0.4)
            Console.ForegroundColor = ConsoleColor.Red;

        for (int i = 0; i < filledParts; i++)
            Console.Write("█");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        for (int i = filledParts; i < barLength; i++)
            Console.Write("░");

        // Reset to the color of the surrounding box
        Console.ForegroundColor = ConsoleColor.Red;
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

        if (centered)
        {
            int padding = (BoxWidth - 4 - content.Length) / 2;
            Console.Write(new string(' ', padding));
            Console.Write(content);

            // Calculate remaining space (accounting for odd length strings)
            int remainingSpace = BoxWidth - 4 - content.Length - padding;
            Console.Write(new string(' ', remainingSpace));
        }
        else
        {
            // Left-aligned with padding for right edge
            int contentMaxLength = BoxWidth - 4;

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