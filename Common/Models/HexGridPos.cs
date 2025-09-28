namespace Common.Models;

/// <summary>
/// Implements flat-top grid cube coordinates.
/// See <a href="https://www.redblobgames.com/grids/hexagons/"/>
/// </summary>
public record HexGridPos(int X, int Y, int Z)
{
    public static HexGridPos Zero { get; } = new(0, 0, 0);

    public static HexGridPos Up { get; } = new(0, 1, -1);

    public static HexGridPos RightUp { get; } = new(1, 0, -1);

    public static HexGridPos RightDown { get; } = new(1, -1, 0);

    public static HexGridPos Down { get; } = new(0, -1, 1);

    public static HexGridPos LeftDown { get; } = new(-1, 0, 1);

    public static HexGridPos LeftUp { get; } = new(-1, 1, 0);

    public int Length => DistanceTo(Zero);

    public int DistanceTo(HexGridPos other)
    {
        return (Math.Abs(X - other.X) + Math.Abs(Y - other.Y) + Math.Abs(Z - other.Z)) / 2;
    }

    public static HexGridPos operator +(HexGridPos pos, HexGridPos other)
    {
        return new HexGridPos(pos.X + other.X, pos.Y + other.Y, pos.Z + other.Z);
    }

    public static HexGridPos operator -(HexGridPos pos)
    {
        return new HexGridPos(-pos.X, -pos.Y, -pos.Z);
    }

    public static HexGridPos operator -(HexGridPos pos, HexGridPos other)
    {
        return new HexGridPos(pos.X - other.X, pos.Y - other.Y, pos.Z - other.Z);
    }
}