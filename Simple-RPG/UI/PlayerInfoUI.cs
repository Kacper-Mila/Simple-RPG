using Simple_RPG.Entities;

namespace Simple_RPG.UI;

public class PlayerInfoUI
{
    public static void DisplayPlayerInfo(PlayerEntity player)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine($"║ Player: {player.Name,-38} ║");
        Console.WriteLine($"║ HP: {player.HP}/{player.MaxHP,-38} ║");
        Console.Write("║ ");
        
        // Draw health bar
        DrawHealthBar(player.HP, player.MaxHP, 46);
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(CalculateSpacing(player.HP, player.MaxHP) + "║");
        Console.WriteLine($"║ Attack Power: {player.AttackPower.Min}-{player.AttackPower.Max,-30} ║");
        Console.WriteLine("╚════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
    }
    
    private static string CalculateSpacing(int currentHP, int maxHP)
    {
        int requiredPadding = 10 - (currentHP.ToString().Length + maxHP.ToString().Length + 3);
        return new string(' ', requiredPadding);
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
    }
}