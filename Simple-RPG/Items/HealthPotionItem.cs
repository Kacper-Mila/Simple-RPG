namespace Simple_RPG.Items;

using Simple_RPG.Interfaces;
using Simple_RPG.Entities;

public class HealthPotionItem : Item
{
    private int HealAmount { get; }

    public HealthPotionItem(string name, string description, int healAmount) 
        : base(name, description)
    {
        HealAmount = healAmount;
    }

    public override void Use(Entity target)
    {
        var healAction = new HealAction(HealAmount, target);
        int healedAmount = healAction.Execute();
        Console.WriteLine($"Healed for {healedAmount} HP!");
    }
}