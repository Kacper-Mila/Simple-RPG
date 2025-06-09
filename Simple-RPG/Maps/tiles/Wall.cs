namespace Simple_RPG.Maps.fields;

public class Wall : MapTile
{
    public override char Symbol => '#';
    public override bool IsWalkable => false;
}