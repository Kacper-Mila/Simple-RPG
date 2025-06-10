using Simple_RPG.Items;

namespace Simple_RPG.Entities;

public class PlayerEntity : Entity
{
    public Inventory Inventory { get; }
    
    public PlayerEntity(string name, int hp, (int Min, int Max) attackPower) 
        : base(name, hp, attackPower)
    {
        Inventory = new Inventory(this);
    }
}