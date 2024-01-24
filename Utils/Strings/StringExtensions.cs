using System;

namespace Impworks.Utils.Strings;

public static partial class StringExtensions
{
    /// <summary>
    /// Returns null if the string is null or empty.
    /// </summary>
    /// <param name="str">Checked string.</param>
    /// <param name="allowWhitespace">Flag indicating that strings with whitespace chars are considered non-empty.</param>
    /// <returns>Null if the string is empty/whitespaced, otherwise the string itself.</returns>
    public static string ValueOrNull(this string str, bool allowWhitespace = false)
    {
        var check = allowWhitespace
            ? (Func<string, bool>) string.IsNullOrEmpty
            : string.IsNullOrWhiteSpace;

        return check(str) ? null : str;
    }

    /// <summary>
    /// Checks if the two strings start with the same sequence.
    /// </summary>
    /// <param name="first">First string.</param>
    /// <param name="second">Second string.</param>
    /// <param name="comparisonLength">Number of characters to check.</param>
    /// <param name="ignoreCase">Flag for case-insensitive comparison.</param>
    public static bool StartsWithPart(this string first, string second, int comparisonLength, bool ignoreCase = false)
    {
        if (comparisonLength < 1)
            throw new ArgumentException("Comparison length must be at least 1", nameof(comparisonLength));

        if (first == null && second == null)
            return true;

        if (first == null || second == null)
            return false;

        if(comparisonLength > first.Length || comparisonLength > second.Length)
            return string.Compare(first, second, ignoreCase) == 0;

        var cmp = string.Compare(
            first,
            0,
            second,
            0,
            comparisonLength,
            ignoreCase
        );

        return cmp == 0;
    }

    /// <summary>
    /// Checks if the two strings end with the same sequence.
    /// </summary>
    /// <param name="first">First string.</param>
    /// <param name="second">Second string.</param>
    /// <param name="comparisonLength">Number of characters to check.</param>
    /// <param name="ignoreCase">Flag for case-insensitive comparison.</param>
    public static bool EndsWithPart(this string first, string second, int comparisonLength, bool ignoreCase = false)
    {
        if(comparisonLength < 1)
            throw new ArgumentException("Comparison length must be at least 1", nameof(comparisonLength));

        if(first == null && second == null)
            return true;

        if(first == null || second == null)
            return false;

        if(comparisonLength > first.Length || comparisonLength > second.Length)
            return string.Compare(first, second, ignoreCase) == 0;

        var cmp = string.Compare(
            first,
            first.Length - comparisonLength,
            second,
            second.Length - comparisonLength,
            comparisonLength,
            ignoreCase
        );

        return cmp == 0;
    }
}