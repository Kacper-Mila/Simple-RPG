namespace Simple_RPG.Entities;

public class PlayerEntity : Entity
{
    public PlayerEntity(string name, int hp, (int Min, int Max) attackPower) : base(name, hp, attackPower)
    {
    }
}