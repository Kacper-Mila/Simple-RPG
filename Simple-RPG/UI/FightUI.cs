using Simple_RPG.Entities;

namespace Simple_RPG.UI;

public static class FightUI
{
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
        Console.WriteLine($"{enemy.Name} - HP: {enemy.HP}/{enemy.MaxHP}");
        Console.WriteLine(enemy.AsciiArt);
        
        // Draw health bar for enemy
        Console.Write("Health: ");
        DrawHealthBar(enemy.HP, enemy.MaxHP, 30);
        Console.WriteLine();
        Console.ResetColor();
    }
    
    public static void DrawPlayerOptions()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n===== Your Turn =====");
        Console.WriteLine("[A] Attack");
        Console.WriteLine("[H] Heal");
        Console.WriteLine("Choose your action: ");
        Console.ResetColor();
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
        
        Console.WriteLine($"\nYou defeated the {enemy.Name}!");
        Console.WriteLine("Press any key to continue your adventure...");
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
        
        Console.WriteLine("\nYou have been defeated!");
        Console.WriteLine("Press any key to exit...");
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
    }
}