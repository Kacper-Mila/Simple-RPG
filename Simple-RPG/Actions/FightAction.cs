using Simple_RPG.Entities;
using Simple_RPG.Items;
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
        } while (key != ConsoleKey.A && key != ConsoleKey.H && key != ConsoleKey.I);
        
        switch (key)
        {
            case ConsoleKey.A: // Attack
                int damage = _player.Attack();
                _enemy.TakeDamage(damage);
                Console.WriteLine($"\nYou attack the {_enemy.Name} with your {_player.Inventory.EquippedWeapon.Name} for {damage} damage!");
                break;
                
            case ConsoleKey.H: // Use health potion from inventory
                // Find first health potion
                var potions = _player.Inventory.Items
                    .Select((item, index) => new { Item = item, Index = index })
                    .Where(x => x.Item is HealthPotionItem)
                    .ToList();
                
                if (potions.Any())
                {
                    _player.Inventory.UseItem(potions.First().Index);
                }
                else
                {
                    Console.WriteLine("\nYou don't have any health potions!");
                }
                break;
                
            case ConsoleKey.I: // Open inventory
                InventoryUI.Display(_player);
                // Don't change turns if player opened inventory
                _playerTurn = true;
                return;
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