namespace Common.Extensions;

public static class CollectionExt
{
    public static void Rotate<T>(this IList<T> data, int k)
    {
        var n = data.Count;
        if (k < 0)
        {
            k = n + k;
        }

        data.Reverse(0, n - 1);
        data.Reverse(0, k - 1);
        data.Reverse(k, n - 1);
    }

    public static void Reverse<T>(this IList<T> data, int start, int end)
    {
        while (start < end)
        {
            (data[start], data[end]) = (data[end], data[start]);
            start++;
            end--;
        }
    }
}