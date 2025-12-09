using System.Numerics;

namespace Common.Models;

public record Rect2d<T> where T : INumber<T>
{
    public T Area => (T.One + T.Abs(_corners[0].X - _corners[2].X)) * (T.One + T.Abs(_corners[0].Y - _corners[2].Y));

    public IEnumerable<Vector3<T>> Corners => _corners.AsEnumerable();

    public Vector3<T> Max => new(T.Max(_corners[0].X, _corners[2].X), T.Max(_corners[0].Y, _corners[2].Y), T.Zero);

    public Vector3<T> Min => new(T.Min(_corners[0].X, _corners[2].X), T.Min(_corners[0].Y, _corners[2].Y), T.Zero);

    private readonly List<Vector3<T>> _corners;

    public Rect2d(Vector3<T> corner1, Vector3<T> corner3)
    {
        _corners =
        [
            corner1, corner1 with { X = corner3.X }, corner3, corner1 with { Y = corner3.Y }
        ];
    }

    public bool Intersects(Line<T> line)
    {
        return line.Horizontal
            ? line.Start.Y > Min.Y && Max.Y > line.Start.Y && Max.X > line.Min.X && Min.X < line.Max.X
            : line.Start.X > Min.X && Max.X > line.Start.X && Max.Y > line.Min.Y && Min.Y < line.Max.Y;
    }
}