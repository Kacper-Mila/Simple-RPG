using Simple_RPG.Entities;
using Simple_RPG.Items;

namespace Simple_RPG.UI;

public static class InventoryUI
{
    private const int BoxWidth = 50;

    public static void Display(PlayerEntity player)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent("INVENTORY", centered: true);
        DrawBoxLine("╠", "═", "╣");

        // Display equipped weapon
        string weaponName = player.Inventory.EquippedWeapon.Name;
        DrawBoxContent($"Equipped Weapon: {weaponName}");

        string damageText = $"Damage: {player.Inventory.EquippedWeapon.DamageRange.Min}-{player.Inventory.EquippedWeapon.DamageRange.Max}";
        DrawBoxContent(damageText);

        DrawBoxLine("╠", "═", "╣");
        DrawBoxContent("Items:");

        var items = player.Inventory.Items;
        if (items.Count == 0)
        {
            DrawBoxContent("[Empty]");
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                var itemDescription = items[i] is WeaponItem weaponItem ? 
                    $"{weaponItem.DamageRange.Min}-{weaponItem.DamageRange.Max}" :
                    $"{items[i].Description}";

                DrawBoxContent(
                        $"{i + 1}. {items[i].Name} ({itemDescription})",
                        centered: false
                    );
            }
        }

        DrawBoxLine("╚", "═", "╝");
        Console.ResetColor();

        Console.WriteLine("\nPress a number to use an item, or any other key to close inventory");

        var key = Console.ReadKey(true).Key;

        // Check if a number key was pressed
        if (key >= ConsoleKey.D1 && key <= ConsoleKey.D9)
        {
            int index = (int)key - (int)ConsoleKey.D1;
            if (index < items.Count)
            {
                player.Inventory.UseItem(index);
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
    }

    public static bool DisplayItemPickup(Item item)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        DrawBoxLine("╔", "═", "╗");
        DrawBoxContent("ITEM DISCOVERED!", centered: true);
        DrawBoxLine("╠", "═", "╣");
        DrawBoxContent(item.Name);
        DrawBoxContent(item.Description);

        if (item is WeaponItem weapon)
        {
            DrawBoxContent($"Damage: {weapon.DamageRange.Min}-{weapon.DamageRange.Max}");
        }
        else if (item is HealthPotionItem)
        {
            DrawBoxContent("Type: Consumable");
        }

        DrawBoxLine("╚", "═", "╝");
        Console.ResetColor();

        Console.WriteLine("\nDo you want to pick up this item? (Y/N)");

        ConsoleKey key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.Y && key != ConsoleKey.N);

        return key == ConsoleKey.Y;
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