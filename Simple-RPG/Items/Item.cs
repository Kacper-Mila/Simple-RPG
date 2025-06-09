using Simple_RPG.Entities;

namespace Simple_RPG.Items;

public abstract class Item(string name, string description)
{
    public string Name { get; } = name;
    public string Description { get; } = description;

    /// <summary>
    /// Uses the item on a target of type T.
    /// </summary>
    /// <typeparam name="T">The type of the target.</typeparam>
    /// <param name="target">The target to use the item on.</param>
    public abstract void Use<T>(Entity target) where T : class;
}