namespace Simple_RPG.Interfaces;

using Simple_RPG.Entities;

public class HealAction(int healAmount, Entity target) : IAction<int>
{
    private readonly Entity _target = target ?? throw new ArgumentNullException(nameof(target));

    public int Execute()
    {
        int healedAmount = Math.Min(healAmount, _target.MaxHP - _target.HP);
        _target.HP += healedAmount;
        return healedAmount;
    }

    public string Description()
    {
        return $"Heals for {healAmount} HP.";
    }
}