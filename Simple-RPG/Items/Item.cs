using Simple_RPG.Entities;

namespace Simple_RPG.Items;

public abstract class Item
{
    public string Name { get; }
    public string Description { get; }

    protected Item(string name, string description)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Uses the item on a target entity.
    /// </summary>
    /// <param name="target">The target to use the item on.</param>
    public abstract void Use(Entity target);
}