using System.Numerics;
using Common.Models;

namespace Common.Helpers;

public static class Calculator
{
    public static T Lcm<T>(T a, T b) where T : INumber<T>
    {
        return a * b / Gcd(a, b);
    }

    public static T Gcd<T>(T a, T b) where T : INumber<T>
    {
        while (true)
        {
            if (T.IsZero(b))
            {
                return a;
            }

            (a, b) = (b, a % b);
        }
    }

    /// <summary>
    /// Calculates polygon's area using
    /// <a href="https://11011110.github.io/blog/2021/04/17/picks-shoelaces.html">Shoelace (Gauss) formula.</a>
    /// </summary>
    /// <param name="corners">Ordered vertexes of the polygon.</param>
    /// <returns>Polygon's area.</returns>
    public static long PolygonArea(List<GridPos2d> corners)
    {
        var area = 0L;
        foreach (var (prev, cur) in corners.Zip(corners[1..].Append(corners[0])))
        {
            area += (long)(cur.Row - prev.Row) * (cur.Col + prev.Col) / 2;
        }

        return Math.Abs(area);
    }

    /// <summary>
    /// Calculates amount of the integer points inside a polygon using
    /// <a href="https://11011110.github.io/blog/2021/04/17/picks-shoelaces.html">Pick's formula.</a>
    /// </summary>
    /// <param name="area">Total polygon's area.</param>
    /// <param name="boundary">Amount of points on the polygon's boundary.</param>
    /// <returns>Amount of the integer points inside a polygon</returns>
    public static long PolygonInteriorPoints(long area, long boundary)
    {
        return area - boundary / 2 + 1;
    }

    /// <summary>
    /// Combines <see cref="PolygonArea"/> and <see cref="PolygonInteriorPoints"/>
    /// to get the total amount of the polygon's integer points. 
    /// </summary>
    /// <param name="corners">Ordered vertexes of the polygon.</param>
    /// <param name="boundary">Amount of points on the polygon's boundary.</param>
    /// <returns>Total amount of the polygon's integer points</returns>
    public static long PolygonTotalPoints(List<GridPos2d> corners, long boundary)
    {
        var area = PolygonArea(corners);
        var interior = PolygonInteriorPoints(area, boundary);
        return interior + boundary;
    }
}