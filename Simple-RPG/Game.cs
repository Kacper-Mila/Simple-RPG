using Simple_RPG.Entities;
using Simple_RPG.Maps;
using Simple_RPG.UI;
using Simple_RPG.Utils;

namespace Simple_RPG;

public sealed class Game
{
    private readonly Map _map = new Map(MapLoader.LoadMapFromFile("map1.txt"));
    private PlayerEntity _player;

    public Game()
    {
        // Player will be initialized in Start()
    }

    public void Start()
    {
        _player = Menu.CreateNewPlayer();
        Console.CursorVisible = false;
        GameLoop();
    }

    private void GameLoop()
    {
        while (true)
        {
            Console.Clear();
            
            // Display player info above the map
            PlayerInfoUI.DisplayPlayerInfo(_player);
            
            // Draw the map
            _map.Draw();
            
            Console.WriteLine("\nMove with arrow keys, Q = exit");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Q)
                break;

            _map.MovePlayer(key);
        }
        
        Console.Clear();
        Console.WriteLine($"Thanks for playing, {_player.Name}!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
    }
}