using Simple_RPG.Entities;

namespace Simple_RPG.UI;

public class PlayerInfoUI
{
    private const int BoxWidth = 50;

    public static void DisplayPlayerInfo(PlayerEntity player)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent($"Player: {player.Name}");
        DrawBoxContent($"HP: {player.HP}/{player.MaxHP}");
        
        // Draw health bar
        Console.Write("║ ");
        DrawHealthBar(player.HP, player.MaxHP, BoxWidth - 4);
        Console.WriteLine(" ║");
        
        DrawBoxContent($"Attack Power: {player.AttackPower.Min}-{player.AttackPower.Max}");
        DrawBoxLine("╚", "═", "╝");
        Console.ResetColor();
        Console.WriteLine();
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
            
        Console.ForegroundColor = ConsoleColor.Cyan;
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