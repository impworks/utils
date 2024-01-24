using System;
using System.Collections.Generic;

namespace Impworks.Utils.Strings;

public static partial class StringExtensions
{
    /// <summary>
    /// Parses the value to a type using default parsers.
    /// Throws an exception if the value cannot be parsed.
    /// </summary>
    /// <param name="str">Source string.</param>
    /// <param name="parseFunc">Parser function that creates a value from the string.</param>
    public static T Parse<T>(this string str, Func<string, T> parseFunc = null)
    {
        if(str == null)
            throw new ArgumentNullException(nameof(str));

        var func = parseFunc ?? StringHelper.GetParseFunction<T>();
        return func(str);
    }

    /// <summary>
    /// Attempts to parse a string using the parse function.
    /// Returns the default value if an exception has been raised.
    /// </summary>
    /// <param name="str">Source string.</param>
    /// <param name="parseFunc">Parser function that creates a value from the string. Default parser is used for built-in types.</param>
    public static T TryParse<T>(this string str, Func<string, T> parseFunc = null)
    {
        var func = parseFunc ?? StringHelper.GetParseFunction<T>();

        try
        {
            if (str != null)
                return func(str);
        }
        catch
        {
            // do nothing
        }

        return default;
    }

    /// <summary>
    /// Converts a string with delimiter-separated value representations to a list of values.
    /// </summary>
    /// <param name="str">Splittable string.</param>
    /// <param name="separator">Sequence of characters that delimits values in the string. Defaults to a comma.</param>
    /// <param name="parseFunc">Parser function that creates a value from the string part. Default parser is used for built-in types.</param>
    public static IReadOnlyList<T> TryParseList<T>(this string str, string separator = ",", Func<string, T> parseFunc = null)
    {
        var result = new List<T>();

        if (str != null)
        {
            var parts = str.Split([separator], StringSplitOptions.RemoveEmptyEntries);
            var func = parseFunc ?? StringHelper.GetParseFunction<T>();

            foreach (var part in parts)
            {
                try
                {
                    result.Add(func(part));
                }
                catch
                {
                    // do nothing
                }
            }
        }

        return result;
    }
}