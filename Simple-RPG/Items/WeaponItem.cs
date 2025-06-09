namespace Simple_RPG.Items;

public abstract class WeaponItem : Item
{
    public int Damage { get; }

    protected WeaponItem(string name, string description, int damage, int durability) : base(name, description)
    {
        Damage = damage;
    }
}