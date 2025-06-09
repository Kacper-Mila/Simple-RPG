namespace Simple_RPG.UI;

public static class Colors
{
    public static readonly string Red = "\x1b[31m";
    public static readonly string Green = "\x1b[32m";
    public static readonly string Yellow = "\x1b[33m";
    public static readonly string Blue = "\x1b[34m";
    public static readonly string Magenta = "\x1b[35m";
    public static readonly string Cyan = "\x1b[36m";
    public static readonly string White = "\x1b[37m";
    public static readonly string Reset = "\x1b[0m";

    public static string Colorize(string text, string color)
    {
        return $"{color}{text}{Reset}";
    }
}