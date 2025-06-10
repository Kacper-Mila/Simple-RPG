using Simple_RPG.Entities;

namespace Simple_RPG.Items;

public class Inventory
{
    private readonly List<Item> _items = new();
    private WeaponItem _equippedWeapon;
    private readonly PlayerEntity _owner;
    
    public WeaponItem EquippedWeapon => _equippedWeapon;
    public IReadOnlyList<Item> Items => _items.AsReadOnly();
    
    public Inventory(PlayerEntity owner)
    {
        _owner = owner;
        // Start with a basic sword
        _equippedWeapon = new SwordItem("Rusty Sword", "A basic rusty sword.", 5, 10);
        
        // Start with one health potion
        _items.Add(new HealthPotionItem("Small Health Potion", "Restores 20 HP.", 20));
    }
    
    public void AddItem(Item item)
    {
        if (item is WeaponItem weapon)
        {
            EquipWeapon(weapon);
        }
        else
        {
            _items.Add(item);
        }
    }
    
    public void EquipWeapon(WeaponItem weapon)
    {
        // If this weapon is already in inventory, remove it first
        if (_items.Contains(weapon))
        {
            _items.Remove(weapon);
        }
        
        // Update player's attack power based on the new weapon
        _owner.AttackPower = weapon.DamageRange;
        
        // Store the old weapon in inventory if we had one
        if (_equippedWeapon != null)
        {
            _items.Add(_equippedWeapon);
        }
        
        // Equip the new weapon
        _equippedWeapon = weapon;
        
        Console.WriteLine($"Equipped {weapon.Name}!");
    }
    
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }
    
    public void UseItem(int index)
    {
        if (index < 0 || index >= _items.Count) return;
        
        Item item = _items[index];
        item.Use(_owner);
        
        // Remove consumable items after use
        if (item is HealthPotionItem)
        {
            _items.RemoveAt(index);
        }
    }
}