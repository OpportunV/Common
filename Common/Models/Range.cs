using System.Numerics;

namespace Common.Models;

/// <summary>
/// Represents a range that has start and end indexes.
/// Start is inclusive, end is exclusive.
/// </summary>
/// <typeparam name="T">Type of the range item. Must implement <see cref="INumber{T}"/></typeparam>
public record Range<T> where T : INumber<T>
{
    public T Start { get; }

    public T End { get; }

    public T Length { get; }

    public bool Ascending { get; }

    public Range(T start, T end)
    {
        Start = start;
        End = end;
        Ascending = End > Start;
        Length = End - Start;
    }

    public IEnumerable<T> Enumerate()
    {
        for (var i = Start; i < End; i++)
        {
            yield return i;
        }
    }

    public Range<T> Intersection(Range<T> other)
    {
        return new Range<T>(T.Max(Start, other.Start), T.Min(End, other.End));
    }

    public bool StartsBefore(Range<T> other)
    {
        return Start < other.Start;
    }

    public bool Intersects(Range<T> other)
    {
        return T.Max(Start, other.Start) < T.Min(End, other.End);
    }

    public bool EndsBefore(Range<T> other)
    {
        return End < other.End;
    }

    public bool Contains(T item)
    {
        return Start <= item && item <= End;
    }

    public Range<T> Union(Range<T> other)
    {
        if (!Intersects(other))
        {
            throw new ArgumentException("Cannot get a union of two ranges with no intersection.");
        }

        return new Range<T>(T.Min(Start, other.Start), T.Max(End, other.End));
    }
}