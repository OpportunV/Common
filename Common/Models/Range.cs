﻿using System.Numerics;

namespace Common.Models;

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

    public bool EndsBefore(Range<T> other)
    {
        return End < other.End;
    }
}