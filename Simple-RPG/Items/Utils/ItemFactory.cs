namespace Simple_RPG.Items.Utils;

public static class ItemFactory
{
    private static readonly Random Random = new();
    
    public static Item CreateRandomItem()
    {
        int itemType = Random.Next(2); // 0 = weapon, 1 = potion
        
        return itemType switch
        {
            0 => CreateRandomWeapon(),
            _ => CreateRandomPotion()
        };
    }
    
    private static WeaponItem CreateRandomWeapon()
    {
        int weaponType = Random.Next(2); // 0 = sword, 1 = axe
        
        string[] prefixes = { "Rusty", "Sharp", "Ancient", "Gleaming", "Enchanted" };
        string prefix = prefixes[Random.Next(prefixes.Length)];
        
        int minDmg = Random.Next(5, 15);
        int maxDmg = minDmg + Random.Next(5, 10);
        
        return weaponType switch
        {
            0 => new SwordItem(
                $"{prefix} Sword", 
                $"A {prefix.ToLower()} sword that does {minDmg}-{maxDmg} damage.",
                minDmg, 
                maxDmg
            ),
            _ => new AxeItem(
                $"{prefix} Axe", 
                $"A {prefix.ToLower()} axe that does {minDmg}-{maxDmg} damage.",
                minDmg, 
                maxDmg
            )
        };
    }
    
    private static HealthPotionItem CreateRandomPotion()
    {
        string[] sizes = { "Small", "Medium", "Large" };
        int sizeIndex = Random.Next(sizes.Length);
        int healAmount = (sizeIndex + 1) * 20; // Small = 20, Medium = 40, Large = 60
        
        return new HealthPotionItem(
            $"{sizes[sizeIndex]} Health Potion",
            $"Restores {healAmount} HP.",
            healAmount
        );
    }
}