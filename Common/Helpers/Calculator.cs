using System.Numerics;

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
}