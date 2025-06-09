namespace Simple_RPG.Maps;

public abstract class MapTile
{
    public abstract char Symbol { get; }
    public virtual bool IsWalkable => true;
}