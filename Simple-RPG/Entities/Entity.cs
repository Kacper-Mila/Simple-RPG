using Simple_RPG.Interfaces;

namespace Simple_RPG.Entities;

/// <summary>
/// Represents a base class for all entities in the game.
/// </summary>
public abstract class Entity
{
    private readonly Guid _id = Guid.NewGuid();
    public string Name { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public (int Min, int Max) AttackPower { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    /// <param name="guid">Unique identifier of the Entity</param>
    /// <param name="name">The name of the entity.</param>
    /// <param name="hp">The initial health points of the entity.</param>
    /// <param name="attackPower">The attack power range of the entity.</param>
    protected Entity(string name, int hp, (int Min, int Max) attackPower)
    {
        Name = name;
        HP = hp;
        MaxHP = hp;
        AttackPower = attackPower;
    }
    
    private Guid Id => _id;
    
    /// <summary>
    /// Reduces the entity's health points by the specified damage amount.
    /// </summary>
    /// <param name="damage">The amount of damage to apply.</param>
    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;
    }
    
    /// <summary>
    /// Gets a value indicating whether the entity is alive.
    /// </summary>
    public bool IsAlive => HP > 0;

    /// <summary>
    /// Calculates and returns a random attack value within the entity's attack power range.
    /// </summary>
    /// <returns>A random attack value.</returns>
    public int Attack()
    {
        var attack = new AttackAction(AttackPower);
        return attack.Execute();
    }
}