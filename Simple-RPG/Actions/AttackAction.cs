namespace Simple_RPG.Interfaces;

public class AttackAction((int Min, int Max) attackPower) : IAction<int>
{
    public int Execute()
    {
        var random = new Random();
        return random.Next(attackPower.Min, attackPower.Max + 1);
    }

    public string Description()
    {
        return "Attack with power between " + attackPower.Min + " and " + attackPower.Max + ".";
    }
}