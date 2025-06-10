using Simple_RPG.Entities;
using Simple_RPG.UI;

namespace Simple_RPG.Interfaces;

public class FightAction
{
    private readonly PlayerEntity _player;
    private readonly EnemyEntity _enemy;
    private readonly Random _random = new();
    private bool _playerTurn = true;

    public FightAction(PlayerEntity player, EnemyEntity enemy)
    {
        _player = player;
        _enemy = enemy;
    }

    public bool ExecuteFight()
    {
        Console.Clear();
        FightUI.DrawFightStart(_enemy);
        
        while (_player.IsAlive && _enemy.IsAlive)
        {
            Console.Clear();
            FightUI.DrawFightScene(_player, _enemy);
            
            if (_playerTurn)
            {
                ProcessPlayerTurn();
            }
            else
            {
                ProcessEnemyTurn();
                // Small delay after enemy's turn
                Thread.Sleep(1500);
            }
            
            _playerTurn = !_playerTurn;
        }
        
        // End of fight
        Console.Clear();
        
        if (_player.IsAlive)
        {
            FightUI.DrawVictory(_enemy);
            return true; // Player won
        }
        else
        {
            FightUI.DrawDefeat();
            return false; // Player lost
        }
    }
    
    private void ProcessPlayerTurn()
    {
        FightUI.DrawPlayerOptions();
        
        ConsoleKey key;
        do
        {
            key = Console.ReadKey(true).Key;
        } while (key != ConsoleKey.A && key != ConsoleKey.H);
        
        switch (key)
        {
            case ConsoleKey.A: // Attack
                int damage = _player.Attack();
                _enemy.TakeDamage(damage);
                Console.WriteLine($"\nYou attack the {_enemy.Name} for {damage} damage!");
                break;
                
            case ConsoleKey.H: // Heal (if we implement inventory)
                int healAmount = 20; // Fixed amount, could use items later
                var healAction = new HealAction(healAmount, _player);
                int actualHeal = healAction.Execute();
                Console.WriteLine($"\nYou healed yourself for {actualHeal} HP!");
                break;
        }
        
        Thread.Sleep(1500);
    }
    
    private void ProcessEnemyTurn()
    {
        if (!_enemy.IsAlive) return; // Enemy already defeated
        
        int damage = _enemy.Attack();
        _player.TakeDamage(damage);
        
        Console.WriteLine($"\n{_enemy.Name} attacks you for {damage} damage!");
    }
}