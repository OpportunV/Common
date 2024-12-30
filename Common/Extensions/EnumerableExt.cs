using System.Numerics;

namespace Common.Extensions;

public static class EnumerableExt
{
    public static TSource Product<TSource>(this IEnumerable<TSource> source) where TSource : INumber<TSource>
    {
        return source.Aggregate(TSource.MultiplicativeIdentity, (accumulate, number) => accumulate * number);
    }

    public static IEnumerable<TSource> Print<TSource>(this IEnumerable<TSource> source, string separator = "\n")
    {
        var list = source.ToList();
        if (list.Count == 0)
        {
            return list;
        }

        Console.WriteLine(string.Join(separator, list));

        return list;
    }
}