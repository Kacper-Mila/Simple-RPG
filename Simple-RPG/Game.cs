﻿using Simple_RPG.Entities;
using Simple_RPG.Maps;
using Simple_RPG.UI;
using Simple_RPG.Utils;

namespace Simple_RPG;

public sealed class Game
{
    private readonly Map _map = new Map(MapLoader.LoadMapFromFile("map1.txt"));
    private PlayerEntity _player;
    private bool _gameOver = false;

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
        while (!_gameOver)
        {
            Console.Clear();
            
            // Display player info above the map
            PlayerInfoUI.DisplayPlayerInfo(_player);
            
            Console.WriteLine("\nMove with arrow keys, I = inventory, Q = exit");
            
            _map.Draw();
            
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Q)
                break;

            bool continueGame = _map.MovePlayer(key, _player);
            
            if (!continueGame || !_player.IsAlive)
            {
                _gameOver = true;
            }
        }
        
        Console.Clear();
        if (_gameOver && !_player.IsAlive)
        {
            Console.WriteLine("You were defeated! Game Over.");
        }
        else
        {
            Console.WriteLine($"Thanks for playing, {_player.Name}!");
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
    }
}