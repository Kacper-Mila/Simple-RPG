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
        Console.WriteLine("This is a weapon and must be equipped first.");
    }
}