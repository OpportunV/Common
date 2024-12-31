using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Common.Extensions;

public static class StringExt
{
    private static readonly Regex _numbers = new(@"-?\d+");
    private static readonly Regex _words = new(@"\w+");

    public static List<T> GetNumbers<T>(this string input) where T : INumber<T>
    {
        return _numbers.Matches(input).Select(match => T.Parse(match.Value, CultureInfo.InvariantCulture)).ToList();
    }

    public static List<string> GetWords(this string input)
    {
        return _words.Matches(input).Select(match => match.Value).ToList();
    }
}