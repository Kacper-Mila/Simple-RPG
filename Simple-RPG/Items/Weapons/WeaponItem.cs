using Simple_RPG.Entities;

namespace Simple_RPG.Items;

public abstract class WeaponItem : Item
{
    public (int Min, int Max) DamageRange { get; }

    protected WeaponItem(string name, string description, int minDamage, int maxDamage) 
        : base(name, description)
    {
        DamageRange = (Min: minDamage, Max: maxDamage);
    }
    
    public override void Use(Entity target)
    {
        if (target is PlayerEntity player)
        {
            player.Inventory.EquipWeapon(this);
        }
        else
        {
            Console.WriteLine("This weapon can only be equipped by a player.");
        }
    }
}