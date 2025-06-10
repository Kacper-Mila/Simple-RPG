namespace Simple_RPG.Utils;

public static class MapLoader
{
    public static string[] LoadMapFromFile(string mapName)
    {
        var modifiedPath = "Maps/maps/" + mapName;
        if (File.Exists(modifiedPath)) return File.ReadAllLines(modifiedPath);
        Console.WriteLine("Map file not found.");
        return [];

    }
}