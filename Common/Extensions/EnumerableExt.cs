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

    public static IEnumerable<(T, T)> DoubleIteration<T>(this IEnumerable<T> enumerable) where T : IEquatable<T>
    {
        var array = enumerable as T[] ?? enumerable.ToArray();
        for (var i = 0; i < array.Length; i++)
        {
            var first = array[i];
            for (var j = 0; j < array.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var second = array[j];
                yield return (first, second);
            }
        }
    }
}