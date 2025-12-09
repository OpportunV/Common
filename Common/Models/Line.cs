using System.Numerics;

namespace Common.Models;

public record Line<T> where T : INumber<T>
{
    public Vector3<T> End { get; init; }

    public bool Horizontal { get; init; }

    public Vector3<T> Max => new(T.Max(Start.X, End.X), T.Max(Start.Y, End.Y), T.Zero);

    public Vector3<T> Min => new(T.Min(Start.X, End.X), T.Min(Start.Y, End.Y), T.Zero);

    public Vector3<T> Start { get; init; }

    public Line(Vector3<T> start, Vector3<T> end)
    {
        Start = start;
        End = end;
        Horizontal = Start.Y == End.Y;
    }
}