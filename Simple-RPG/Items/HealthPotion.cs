namespace Simple_RPG.Items;

using Simple_RPG.Interfaces;
using Simple_RPG.Entities;

public class HealthPotion(string name, string description, int healAmount) : Item(name, description)
{
    private int HealAmount { get; } = healAmount;

    public override void Use<T>(Entity target)
    {
            var healAction = new Heal(HealAmount, target);
            healAction.Execute();
            return;

    }
}