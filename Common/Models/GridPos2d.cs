﻿using Common.Extensions;
using Common.Helpers;

namespace Common.Models;

public record GridPos2d(int Row, int Col)
{
    public static GridPos2d Zero { get; } = new(0, 0);

    public static GridPos2d One { get; } = new(1, 1);

    public static GridPos2d Right { get; } = new(0, 1);

    public static GridPos2d Down { get; } = new(1, 0);

    public static GridPos2d Left { get; } = new(0, -1);

    public static GridPos2d Up { get; } = new(-1, 0);

    public static GridPos2d RightUp { get; } = Right + Up;

    public static GridPos2d RightDown { get; } = Right + Down;

    public static GridPos2d LeftUp { get; } = Left + Up;

    public static GridPos2d LeftDown { get; } = Left + Down;

    public IEnumerable<GridPos2d> AdjacentAll()
    {
        return Adjacent(Directions2d.All);
    }

    public IEnumerable<GridPos2d> AdjacentSide()
    {
        return Adjacent(Directions2d.Side);
    }

    public IEnumerable<GridPos2d> AdjacentDiag()
    {
        return Adjacent(Directions2d.Diag);
    }

    public IEnumerable<IEnumerable<GridPos2d>> AdjacentAll(int rows, int cols, int length)
    {
        return Adjacent(rows, cols, length, Directions2d.All);
    }

    public IEnumerable<IEnumerable<GridPos2d>> AdjacentDiag(int rows, int cols, int length)
    {
        return Adjacent(rows, cols, length, Directions2d.Diag);
    }

    public IEnumerable<IEnumerable<GridPos2d>> AdjacentSide(int rows, int cols, int length)
    {
        return Adjacent(rows, cols, length, Directions2d.Side);
    }

    public bool IsInside(int rows, int cols)
    {
        return Row >= 0 && Row < rows && Col >= 0 && Col < cols;
    }

    public int ManhattanTo(GridPos2d other)
    {
        return Math.Abs(Row - other.Row) + Math.Abs(Col - other.Col);
    }

    public static GridPos2d operator *(GridPos2d pos2d, int other)
    {
        return new GridPos2d(pos2d.Row * other, pos2d.Col * other);
    }

    public static GridPos2d operator +(GridPos2d pos2d, GridPos2d other)
    {
        return new GridPos2d(pos2d.Row + other.Row, pos2d.Col + other.Col);
    }

    public static GridPos2d operator +(GridPos2d pos2d, int other)
    {
        return new GridPos2d(pos2d.Row + other, pos2d.Col + other);
    }

    public static GridPos2d operator -(GridPos2d pos2d, GridPos2d other)
    {
        return new GridPos2d(pos2d.Row - other.Row, pos2d.Col - other.Col);
    }

    public static GridPos2d operator -(GridPos2d pos2d, int other)
    {
        return new GridPos2d(pos2d.Row - other, pos2d.Col - other);
    }

    public static GridPos2d operator -(GridPos2d pos2d)
    {
        return new GridPos2d(-pos2d.Row, -pos2d.Col);
    }

    public override string ToString()
    {
        return $"({Row}, {Col})";
    }

    public static GridPos2d Parse(string gridPos2dString)
    {
        var numbers = gridPos2dString.GetNumbers<int>();
        if (numbers.Count != 2)
        {
            throw new ArgumentException($"Invalid amount of values '{gridPos2dString}'");
        }

        return new GridPos2d(numbers[0], numbers[1]);
    }

    private IEnumerable<IEnumerable<GridPos2d>> Adjacent(int rows, int cols, int length,
        IEnumerable<GridPos2d> directions)
    {
        foreach (var dir in directions)
        {
            var endPos = this + dir * (length - 1);

            if (!endPos.IsInside(rows, cols))
            {
                continue;
            }

            yield return Enumerable.Range(0, length).Select(i => this + dir * i);
        }
    }

    private IEnumerable<GridPos2d> Adjacent(IEnumerable<GridPos2d> directions)
    {
        return directions.Select(dir => this + dir);
    }
}