namespace Common.Extensions;

public static class SpanExt
{
    public static (T max, int index) MaxWithIndex<T>(this ReadOnlySpan<T> span, int start, int end)
        where T : IEquatable<T>, IComparable<T>
    {
        if (span.Length < start || span.Length < end)
        {
            throw new ArgumentException("Span length is smaller than start or end");
        }

        if (start >= end)
        {
            throw new ArgumentException("Start is greater or equal to end");
        }

        var max = span[start];
        var index = start;
        for (var i = start; i < end; i++)
        {
            var current = span[i];
            if (current.CompareTo(max) > 0)
            {
                max = current;
                index = i;
            }
        }

        return (max, index);
    }

    public static (T max, int index) MaxWithIndex<T>(this ReadOnlySpan<T> span) where T : IEquatable<T>, IComparable<T>
    {
        return span.MaxWithIndex(0, span.Length);
    }
}