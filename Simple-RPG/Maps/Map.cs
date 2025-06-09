using Simple_RPG.Maps.fields;
using Simple_RPG.UI;

namespace Simple_RPG.Maps;

public class Map
{
    private MapTile[,] grid;
    private int width;
    private int height;

    private int playerX;
    private int playerY;

    public Map(string[] rawMap)
    {
        height = rawMap.Length;
        width = rawMap.Max(line => line.Length);
        grid = new MapTile[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char c = (x < rawMap[y].Length) ? rawMap[y][x] : ' ';

                switch (c)
                {
                    case '#':
                        grid[y, x] = new Wall();
                        break;
                    case '.':
                        grid[y, x] = new Empty();
                        break;
                    case 'E':
                        grid[y, x] = new EnemyTile();
                        break;
                    case '!':
                        grid[y, x] = new ItemTile();
                        break;
                    case 'P':
                        grid[y, x] = new Empty();
                        playerX = x;
                        playerY = y;
                        break;
                    default:
                        grid[y, x] = new VoidTile();
                        break;
                }
            }
        }
    }

    public void Draw()
    {
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                if (x == playerX && y == playerY)
                    Console.Write(Colors.Colorize("P", Colors.Yellow));
                else
                    if (grid[y, x] is EnemyTile)
                        Console.Write(Colors.Colorize("E", Colors.Red));
                    else if (grid[y, x] is ItemTile)
                        Console.Write(Colors.Colorize("!", Colors.Magenta));
                    else
                        Console.Write(grid[y, x].Symbol);
            }
            Console.WriteLine();
        }
    }

    public void MovePlayer(ConsoleKey key)
    {
        var newX = playerX;
        var newY = playerY;

        switch (key)
        {
            case ConsoleKey.UpArrow: newY--; break;
            case ConsoleKey.DownArrow: newY++; break;
            case ConsoleKey.LeftArrow: newX--; break;
            case ConsoleKey.RightArrow: newX++; break;
        }

        if (!IsWalkable(newX, newY)) return;
        playerX = newX;
        playerY = newY;
    }

    private bool IsWalkable(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height)
            return false;

        return grid[y, x].IsWalkable;
    }
}
