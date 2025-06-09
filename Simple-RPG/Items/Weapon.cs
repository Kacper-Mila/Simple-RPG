namespace Simple_RPG.Items;

public abstract class Weapon : Item
{
    public int Damage { get; }

    protected Weapon(string name, string description, int damage, int durability) : base(name, description)
    {
        Damage = damage;
    }
}